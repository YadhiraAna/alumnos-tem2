# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar toda la solución
COPY . .

# Publicar el proyecto principal
RUN dotnet publish API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer puertos (opcional si usas Render, pero útil para local)
EXPOSE 80
EXPOSE 443

# Ejecutar directamente el proyecto publicado
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
