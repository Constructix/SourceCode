FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LoggingWebAPI/LoggingWebAPI.csproj", "LoggingWebAPI/"]
RUN dotnet restore "LoggingWebAPI/LoggingWebAPI.csproj"
COPY . .
WORKDIR "/src/LoggingWebAPI"
RUN dotnet build "LoggingWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoggingWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoggingWebAPI.dll"]