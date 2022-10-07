#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["demoForSerilogElk31/demoForSerilogElk31.csproj", "demoForSerilogElk31/"]
RUN dotnet restore "demoForSerilogElk31/demoForSerilogElk31.csproj"
COPY . .
WORKDIR "/src/demoForSerilogElk31"
RUN dotnet build "demoForSerilogElk31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForSerilogElk31.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForSerilogElk31.dll"]