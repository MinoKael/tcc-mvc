# Estágio 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MeuTccMvc.csproj", "."]
RUN dotnet restore "./MeuTccMvc.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MeuTccMvc.csproj" -c Release -o /app/build

# Estágio 2: Publicação da aplicação
FROM build AS publish
RUN dotnet publish "MeuTccMvc.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Estágio 3: Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeuTccMvc.dll"]