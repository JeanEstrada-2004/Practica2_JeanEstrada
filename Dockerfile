FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Practica2_JeanEstrada.csproj", "./"]
RUN dotnet restore "Practica2_JeanEstrada.csproj"
COPY . .
RUN dotnet publish "Practica2_JeanEstrada.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Practica2_JeanEstrada.dll"]
