# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos de proyecto y restaura dependencias
COPY *.sln .
COPY NewsPortal/*.csproj ./NewsPortal/
RUN dotnet restore

# Copia el resto del código y publica
COPY NewsPortal/. ./NewsPortal/
WORKDIR /app/NewsPortal
RUN dotnet publish -c Release -o out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/NewsPortal/out ./

# Puerto por defecto para ASP.NET Core
EXPOSE 80

# Comando de inicio
ENTRYPOINT ["dotnet", "NewsPortal.dll"]
