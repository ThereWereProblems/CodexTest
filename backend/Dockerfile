FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY MyPrivateDrive.API/*.csproj MyPrivateDrive.API/
RUN dotnet restore MyPrivateDrive.API/MyPrivateDrive.API.csproj
COPY MyPrivateDrive.API/ MyPrivateDrive.API/
RUN dotnet publish MyPrivateDrive.API/MyPrivateDrive.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MyPrivateDrive.API.dll"]
