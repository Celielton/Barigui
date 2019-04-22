FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Barigui2.Service/Barigui2.Service.csproj Barigui2.Service/
COPY Barigui.Core/Barigui.Core.csproj Barigui.Core/
RUN dotnet restore Barigui2.Service/Barigui2.Service.csproj
COPY . .
WORKDIR /src/Barigui2.Service
RUN dotnet build Barigui2.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Barigui2.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Barigui2.Service.dll"]
