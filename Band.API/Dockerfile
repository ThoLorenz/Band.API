FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5555


FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY Band.API/Band.API.csproj Band.API/
RUN dotnet restore Band.API/Band.API.csproj
COPY . .
WORKDIR /src/Band.API
RUN dotnet build Band.API.csproj -c Release -o /app
FROM build AS publish
RUN dotnet publish Band.API.csproj -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Band.API.dll"]
