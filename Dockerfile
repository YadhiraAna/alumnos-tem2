# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar todo el código
COPY . ./

# Publicar la API que está en la carpeta API_Estudiantes_Test
RUN dotnet publish API_Estudiantes_Test/API_Estudiantes_Test.csproj -c Release -o /app/out

# Etapa final: imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar lo publicado
COPY --from=build /app/out .

# Exponer puertos
EXPOSE 80
EXPOSE 443

# Ejecutar la API
ENTRYPOINT ["dotnet", "API_Estudiantes_Test.dll"]
