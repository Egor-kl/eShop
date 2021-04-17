FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/Email/Email/Email.csproj", "Services/Email/Email/"]
RUN dotnet restore "Services/Email/Email/Email.csproj"
COPY . .
WORKDIR "/src/Services/Email/Email"
RUN dotnet build "Email.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Email.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Email.dll"]