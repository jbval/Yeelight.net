using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("YeelightInfo")]
public class YeelightInfoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string _targetIp;
    private readonly int _targetPort;

    public YeelightInfoController(IConfiguration configuration)
    {
        _configuration = configuration;
        _targetIp = _configuration.GetValue<string>("Yeelight:Ip");
        _targetPort = _configuration.GetValue<int>("Yeelight:Port");
    }

    [HttpGet]
    [Route("/PowerOff")]
    public async Task<YeelightInfo> PowerOff(CancellationToken cancellationToken)
    {
        IList<YeelightInfo> responseEntities = new List<YeelightInfo>();
        responseEntities = await SendCommandAsync("set_power", new List<object> { "off", "smooth", 500 }, cancellationToken);
        return responseEntities.FirstOrDefault(r => r.Result.Any());
    }
    [HttpGet]
    [Route("/PowerOn")]
    public async Task<YeelightInfo> PowerOn(CancellationToken cancellationToken)
    {
        IList<YeelightInfo> responseEntities = new List<YeelightInfo>();
        responseEntities = await SendCommandAsync("set_power", new List<object> { "on", "smooth", 500 }, cancellationToken);
        return responseEntities.FirstOrDefault(r => r.Result.Any() || r.Params.Any());
    }

    private async Task<IList<YeelightInfo>> SendCommandAsync(string methodName, IList<object> commandParams, CancellationToken cancellationToken)
    {
        System.Console.WriteLine("Start SendCommand");

        var responseEntities = new List<YeelightInfo>();
        using (TcpClient listener = new TcpClient(_targetIp, _targetPort))
        {
            var command = new YeelightCommand
            {
                Id = 1,
                Method = methodName,
                MethodParams = commandParams
            };

            var commandText = System.Text.Json.JsonSerializer.Serialize(command);

            var bytes = Encoding.ASCII.GetBytes(commandText + "\r\n");
            listener.NoDelay = true;
            using (NetworkStream s = listener.GetStream())

            {
                s.Socket.Blocking = false;


                System.Console.WriteLine("Listening");

                while (responseEntities is null || !responseEntities.Any())
                {

                    var sb = new StringBuilder(string.Empty);

                    // Declare the callback.  Need to do that so that
                    // the closure captures it.
                    AsyncCallback callback = null;
                    bool stringReceived = false;
                    byte[] buffer = new byte[100];
                    // Assign the callback.
                    callback = ar =>
                    {
                        // Call EndRead.
                        int bytesRead = listener.Client.EndReceive(ar);
                        // Process the bytes here.
                        var rs = Encoding.ASCII.GetString(buffer, 0, buffer.Length).Replace("\0", "");
                        sb.Append(rs);
                        // Determine if you want to read again.  If not, return.
                        if (rs.Contains("\n"))
                        {
                            stringReceived = true;
                            return;
                        }
                        buffer = new byte[100];
                        // Read again.  This callback will be called again.
                        listener.Client.BeginReceive(buffer, 0, 100, SocketFlags.Partial, callback, null);
                    };

                    // Trigger the initial read.
                    listener.Client.BeginReceive(buffer, 0, 100, SocketFlags.Partial, callback, null);



                    Thread.Sleep(200);

                    var sw = new StreamWriter(s);
                    sw.AutoFlush = true;
                    await sw.WriteLineAsync(commandText);

                    while (!stringReceived)
                    {
                        Thread.Sleep(200);
                    }

                    var responseString = sb.ToString();

                    responseEntities.Add(System.Text.Json.JsonSerializer.Deserialize<YeelightInfo>(
                                                                 responseString,
                                                                   new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }

                                                          ));

                }

            }
        }

        return responseEntities;
    }
}