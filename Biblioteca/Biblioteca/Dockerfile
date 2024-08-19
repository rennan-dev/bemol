# Etapa 1: Construção da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Definir o diretório de trabalho
WORKDIR /app

# Copiar o arquivo .csproj e restaurar as dependências
COPY Biblioteca.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet build -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "Biblioteca.dll"]
