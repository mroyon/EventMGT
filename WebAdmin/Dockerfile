# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 443


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
RUN dotnet dev-certs https --trust
# Install dependencies (including ICU and locales package)
RUN apt-get update && apt-get install -y \
    libicu-dev \
    locales \
    && rm -rf /var/lib/apt/lists/*

# Generate the locales you need (en_US.UTF-8 and bn_BD.UTF-8)
RUN locale-gen en_US.UTF-8 \
    && locale-gen bn_BD.UTF-8

#RUN apt-get update && apt-get install -y wget

#RUN wget https://drive.usercontent.google.com/uc?id=1ATnHqnglHl85NXksk7dLu2Z3losM0OKu&export=download --no-check-certificate -O
#RUN wget --no-check-certificate -O script.sql "https://drive.google.com/uc?id=1ATnHqnglHl85NXksk7dLu2Z3losM0OKu&export=download"

#RUN mv script.sql /tmp/script.sql

# Directly set the locale environment variables
ENV ASPNETCORE_URLS=http://0.0.0.0:5001
ENV LANG=en_US.UTF-8
ENV LANGUAGE=en_US.UTF-8
ENV LC_ALL=en_US.UTF-8

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WebAdmin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

#EXPOSE 5001
# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WebAdmin.dll"]