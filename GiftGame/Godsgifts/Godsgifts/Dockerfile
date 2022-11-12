FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Godsgifts/Godsgifts.csproj", "Godsgifts/"]
RUN dotnet restore "Godsgifts/Godsgifts.csproj"
COPY . .
WORKDIR "/src/Godsgifts"
RUN dotnet build "Godsgifts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Godsgifts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Godsgifts.dll"]
