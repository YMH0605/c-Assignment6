#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
ENV ""

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HRMAPI/HRMAPI.csproj", "HRMAPI/"]
RUN dotnet restore "HRMAPI/HRMAPI.csproj"
COPY . .
WORKDIR "/src/HRMAPI"
RUN dotnet build "HRMAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRMAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRMAPI.dll"]
