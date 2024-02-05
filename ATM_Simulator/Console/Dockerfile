FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LabWork5/LabWork5.csproj", "LabWork5/"]
RUN dotnet restore "LabWork5/LabWork5.csproj"
COPY . .
WORKDIR "/src/LabWork5"
RUN dotnet build "LabWork5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LabWork5.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LabWork5.dll"]
