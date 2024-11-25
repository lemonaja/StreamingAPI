# Use uma imagem do SDK do .NET como base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos do projeto
COPY . ./

# Restaurar dependências e compilar o projeto
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Criar uma imagem menor apenas com o runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definir a porta exposta
EXPOSE 80

# Definir o comando de inicialização
ENTRYPOINT ["dotnet", "StreamingAPI.dll"]
