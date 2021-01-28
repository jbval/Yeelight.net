using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Models
{
    /// <summary>
    /// Commande à envoyer au dispositif
    /// </summary>
    public class YeelightCommand
    {
        /// <summary>
        /// 
        /// </summary>Id Yeelight
        [JsonPropertyName("id")]
        public int Id { get; set; }
        /// <summary>
        /// Methode à appeler
        /// </summary>
        [JsonPropertyName("method")]
        public string Method { get; set; }
        /// <summary>
        /// Paramètres
        /// </summary>
        [JsonPropertyName("params")]
        public IList<object> MethodParams { get; set; } = new List<object>();
    }
}