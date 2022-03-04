#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Ekmob.Technical.Customer/Ekmob.Technical.Customer.csproj", "Services/Ekmob.Technical.Customer/"]
COPY ["Common/Ekmob.Technical.Common/Ekmob.Technical.Common.csproj", "Common/Ekmob.Technical.Common/"]
RUN dotnet restore "Services/Ekmob.Technical.Customer/Ekmob.Technical.Customer.csproj"
COPY . .
WORKDIR "/src/Services/Ekmob.Technical.Customer"
RUN dotnet build "Ekmob.Technical.Customer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ekmob.Technical.Customer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ekmob.Technical.Customer.dll"]
