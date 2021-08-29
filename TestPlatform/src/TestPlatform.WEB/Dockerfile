#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TestPlatform.WEB/TestPlatform.WEB.csproj", "src/TestPlatform.WEB/"]
COPY ["src/TestPlatform.BLL/TestPlatform.BLL.csproj", "src/TestPlatform.BLL/"]
COPY ["src/TestPlatform.Common/TestPlatform.Common.csproj", "src/TestPlatform.Common/"]
COPY ["src/TestPlatform.DAL/TestPlatform.DAL.csproj", "src/TestPlatform.DAL/"]
RUN dotnet restore "src/TestPlatform.WEB/TestPlatform.WEB.csproj"
COPY . .
WORKDIR "/src/src/TestPlatform.WEB"
RUN dotnet build "TestPlatform.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestPlatform.WEB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestPlatform.WEB.dll"]