FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RehseBlazor.csproj", "."]
RUN dotnet restore "RehseBlazor.csproj"
COPY . .
RUN dotnet build "RehseBlazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RehseBlazor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RehseBlazor.dll"]

