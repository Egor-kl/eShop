FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Email/Email.API/Email.API.csproj", "Services/Email/Email.API/"]
RUN dotnet restore "Services/Email/Email.API/Email.API.csproj"
COPY . .
WORKDIR "/src/Services/Email/Email.API"
RUN dotnet build "Email.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Email.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Email.API.dll"]