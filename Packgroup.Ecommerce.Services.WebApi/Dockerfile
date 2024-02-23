#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Packgroup.Ecommerce.Services.WebApi/Packgroup.Ecommerce.Services.WebApi.csproj", "Packgroup.Ecommerce.Services.WebApi/"]
COPY ["Packgroup.Ecommerce.Aplication.DTO/Packgroup.Ecommerce.Aplication.DTO.csproj", "Packgroup.Ecommerce.Aplication.DTO/"]
COPY ["Packgroup.Ecommerce.Aplication.Interface/Packgroup.Ecommerce.Aplication.Interface.csproj", "Packgroup.Ecommerce.Aplication.Interface/"]
COPY ["Packgroup.Ecommerce.Transversal.Commin/Packgroup.Ecommerce.Transversal.Common.csproj", "Packgroup.Ecommerce.Transversal.Commin/"]
COPY ["Packgroup.Ecommerce.Aplication.Main/Packgroup.Ecommerce.Aplication.Main.csproj", "Packgroup.Ecommerce.Aplication.Main/"]
COPY ["Packgroup.Ecommerce.Domain.Entity/Packgroup.Ecommerce.Domain.Entity.csproj", "Packgroup.Ecommerce.Domain.Entity/"]
COPY ["Packgroup.Ecommerce.Domain.Interface/Packgroup.Ecommerce.Domain.Interface.csproj", "Packgroup.Ecommerce.Domain.Interface/"]
COPY ["Packgroup.Ecommerce.Domain.Core/Packgroup.Ecommerce.Domain.Core.csproj", "Packgroup.Ecommerce.Domain.Core/"]
COPY ["PackGroup.Ecommerce.Infrastructura.Interface/PackGroup.Ecommerce.Infrastructura.Interface.csproj", "PackGroup.Ecommerce.Infrastructura.Interface/"]
COPY ["Packgroup.Ecommerce.Infraestructura.Data/Packgroup.Ecommerce.Infraestructura.Data.csproj", "Packgroup.Ecommerce.Infraestructura.Data/"]
COPY ["Packgroup.Ecommerce.Infraestructura.Repository/Packgroup.Ecommerce.Infraestructura.Repository.csproj", "Packgroup.Ecommerce.Infraestructura.Repository/"]
COPY ["Packgroup.Ecommerce.Transversal.Logging/Packgroup.Ecommerce.Transversal.Logging.csproj", "Packgroup.Ecommerce.Transversal.Logging/"]
COPY ["Packgroup.Ecommerce.Transversal.Mapper/Packgroup.Ecommerce.Transversal.Mapper.csproj", "Packgroup.Ecommerce.Transversal.Mapper/"]
RUN dotnet restore "Packgroup.Ecommerce.Services.WebApi/Packgroup.Ecommerce.Services.WebApi.csproj"
COPY . .
WORKDIR "/src/Packgroup.Ecommerce.Services.WebApi"
RUN dotnet build "Packgroup.Ecommerce.Services.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Packgroup.Ecommerce.Services.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Packgroup.Ecommerce.Services.WebApi.dll"]