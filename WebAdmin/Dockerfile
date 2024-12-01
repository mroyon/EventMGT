# Use the official .NET SDK image based on bullseye-slim for building
FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy .csproj files first to leverage Docker caching
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

# Install dependencies (including ICU, locales, and other libraries)
RUN apt-get update && apt-get install -y \
    libicu-dev \
    locales \
    ca-certificates \
    libssl-dev \
    wget \
    gnupg \
    libgdiplus \
    libc6-dev \
    libx11-dev \
    libfontconfig1 \
    libfreetype6 \
    unzip \
    && rm -rf /var/lib/apt/lists/*

# Ensure the latest version of libgdiplus is installed (this might help with rendering issues)
RUN apt-get update && apt-get install -y libgdiplus

# Generate the locales (en_US.UTF-8 and bn_BD.UTF-8)
RUN locale-gen en_US.UTF-8 \
    && locale-gen bn_BD.UTF-8

# Set environment variables for .NET runtime to use the desired locales and disable invariant mode
ENV LANG en_US.UTF-8
ENV LANGUAGE en_US.UTF-8
ENV LC_ALL en_US.UTF-8
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Disable certain GDI+ features that might cause issues
ENV DOTNET_SYSTEM_DRAWING_USE_GDI=false

# Restore the project dependencies
RUN dotnet restore "./WebAdmin/WebAdmin.csproj"

# Copy the remaining application files and build the project
COPY . . 
WORKDIR "/src/WebAdmin"
RUN dotnet build "./WebAdmin.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust

# Publish the app to /app/publish directory
FROM build AS publish
RUN dotnet publish "./WebAdmin.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Runtime image based on the .NET ASP.NET base image based on bullseye-slim
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS final
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
# Install libgdiplus in the final runtime image
RUN apt-get update && apt-get install -y \
    libgdiplus \
    libc6-dev \
    libx11-dev \
    libfontconfig1 \
    libfreetype6 \
    x11-utils \
    fontconfig \
    openssl \
    && rm -rf /var/lib/apt/lists/*

# Add i386 architecture for Wine
RUN dpkg --add-architecture i386

# Add WineHQ repository
RUN apt-get update && \
    apt-get install -y wget gnupg2 software-properties-common && \
    wget -nc https://dl.winehq.org/wine-builds/winehq.key && \
    apt-key add winehq.key && \
    add-apt-repository 'deb https://dl.winehq.org/wine-builds/debian/ bullseye main'

# Install Wine Stable
RUN apt-get update && apt-get install -y --install-recommends winehq-stable
# Set working directory for the app
WORKDIR /app

# Copy the published files from the previous stage
COPY --from=publish /app/publish .

# Expose the necessary ports
EXPOSE 5001

# Entry point to run the application using .NET directly
ENTRYPOINT ["dotnet", "WebAdmin.dll"]
