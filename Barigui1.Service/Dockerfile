FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Barigui1.Service/Barigui1.Service.csproj Barigui1.Service/
COPY Barigui.Core/Barigui.Core.csproj Barigui.Core/
RUN dotnet restore Barigui1.Service/Barigui1.Service.csproj
COPY . .
WORKDIR /src/Barigui1.Service
RUN dotnet build Barigui1.Service.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Barigui1.Service.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Barigui1.Service.dll"]
