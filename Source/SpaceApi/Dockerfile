FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SpaceApi/SpaceApi.csproj", "SpaceApi/"]
RUN dotnet restore "SpaceApi/SpaceApi.csproj"
COPY . .
WORKDIR "/src/SpaceApi"
RUN dotnet build "SpaceApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaceApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "SpaceApi.dll"]