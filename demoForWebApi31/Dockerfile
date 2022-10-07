#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["demoForWebApi31/demoForWebApi31.csproj", "demoForWebApi31/"]
RUN dotnet restore "demoForWebApi31/demoForWebApi31.csproj"
COPY . .
WORKDIR "/src/demoForWebApi31"
RUN dotnet build "demoForWebApi31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForWebApi31.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForWebApi31.dll"]