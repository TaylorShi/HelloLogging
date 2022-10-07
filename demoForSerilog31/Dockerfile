#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["demoForSerilog31/demoForSerilog31.csproj", "demoForSerilog31/"]
RUN dotnet restore "demoForSerilog31/demoForSerilog31.csproj"
COPY . .
WORKDIR "/src/demoForSerilog31"
RUN dotnet build "demoForSerilog31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForSerilog31.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForSerilog31.dll"]