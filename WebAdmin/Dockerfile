# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app 
EXPOSE 5001 443

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["WebAdmin/WebAdmin.csproj", "WebAdmin/"]
COPY ["AppConfig/AppConfig.csproj", "AppConfig/"]
COPY ["BDO/BDO.csproj", "BDO/"]
COPY ["CLL/CLL.csproj", "CLL/"]
COPY ["BFC/BFC.csproj", "BFC/"]
COPY ["BFO/BFO.csproj", "BFO/"]
COPY ["DAC/DAC.csproj", "DAC/"]
COPY ["IDAC/IDAC.csproj", "IDAC/"]
COPY ["IBFO/IBFO.csproj", "IBFO/"]
COPY ["Web.Api.Infrastructure/Web.Api.Infrastructure.csproj", "Web.Api.Infrastructure/"]
COPY ["Web.Core.Frame/Web.Core.Frame.csproj", "Web.Core.Frame/"]
RUN dotnet restore "./WebAdmin/WebAdmin.csproj"
COPY . .
WORKDIR "/src/WebAdmin"
RUN dotnet build "./WebAdmin.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
# Install dependencies (including ICU and locales package)
RUN apt-get update && apt-get install -y \
    libicu-dev \
    locales \
    && rm -rf /var/lib/apt/lists/*

# Generate the locales (en_US.UTF-8 and bn_BD.UTF-8)
RUN locale-gen en_US.UTF-8 \
    && locale-gen bn_BD.UTF-8
# Directly set the locale environment variables
ENV LANG=en_US.UTF-8
ENV LANGUAGE=en_US.UTF-8
ENV LC_ALL=en_US.UTF-8
# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAdmin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#used to store uploaded files
RUN mkdir -p /app/wwwroot/uploads
EXPOSE 5001/tcp
ENTRYPOINT ["dotnet", "WebAdmin.dll"]