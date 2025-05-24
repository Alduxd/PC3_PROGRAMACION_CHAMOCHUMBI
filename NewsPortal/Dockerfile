# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos de proyecto y restaura dependencias
COPY ../*.sln ./
COPY ./*.csproj ./
RUN dotnet restore

# Copia el resto del código y publica
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "NewsPortal.dll"]
