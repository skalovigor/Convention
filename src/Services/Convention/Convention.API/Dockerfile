#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Convention/Convention.API/Convention.API.csproj", "Convention.API/"]
COPY ["Services/Convention/Convention.BLL/Convention.BLL.csproj", "Convention.BLL/"]
COPY ["Services/Convention/Convention.DAL/Convention.DAL.csproj", "Convention.DAL/"]
COPY ["Services/Convention/Convention.Domain/Convention.Domain.csproj", "Convention.Domain/"]
COPY ["Services/Convention/Convention.Contracts/Convention.Contracts.csproj", "Convention.Contracts/"]
COPY ["Shared/Convention.Common/Convention.Common.csproj", "Shared/Convention.Common/"]
RUN dotnet restore "Convention.API/Convention.API.csproj"
COPY . .
WORKDIR "/src/Services/Convention/Convention.API"
RUN dotnet build "Convention.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Convention.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Convention.API.dll"]