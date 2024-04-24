FROM mongo:latest

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["ProgressAcademy.Data.csproj", "ProgressAcademy/"]
RUN dotnet restore "ProgressAcademy.Data.csproj"

COPY . .
WORKDIR "/src/ProgressAcademy.Data"
RUN dotnet build "src/ProgressAcademy.Data/ProgressAcademy.Data.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/ProgressAcademy.Data/ProgressAcademy.Data.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

EXPOSE 27017

CMD ["mongod", "--bind_ip_all", "--port", "27017"]

ENTRYPOINT ["dotnet", "ProgressAcademy.Data.dll"]