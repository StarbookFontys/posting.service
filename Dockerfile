#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["posting-service/posting-service.csproj", "posting-service/"]
RUN dotnet restore "posting-service/posting-service.csproj"
COPY . .
RUN dotnet build "posting-service/posting-service.csproj" -c Release -o /app/build
WORKDIR "/src"

FROM build AS publish
RUN dotnet publish "posting-service/posting-service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "posting-service.dll"]