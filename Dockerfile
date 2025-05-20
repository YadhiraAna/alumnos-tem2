# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos los archivos del proyecto
COPY . .

# Publicar solo el proyecto principal de la API
RUN dotnet publish "API_Estudiantes_Test.csproj" -c Release -o /app/out

# Etapa de ejecución final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copiar los artefactos publicados desde la etapa de compilación
COPY --from=build /app/out .

# Exponer los puertos (Render usa 10000+ internamente, pero igual se exponen 80 y 443)
EXPOSE 80
EXPOSE 443

# Iniciar la API especificando el nombre correcto del DLL
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
