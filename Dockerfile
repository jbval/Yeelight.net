FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 6400


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY *.csproj ./
#COPY . .
RUN dotnet restore
#"YeelightWeb.net.csproj"
COPY . .
RUN dotnet build "YeelightWeb.net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YeelightWeb.net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:6400
ENTRYPOINT ["dotnet", "YeelightWeb.net.dll"]
