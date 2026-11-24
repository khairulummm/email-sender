# ======================
# Base Image: ASP.NET Runtime
# ======================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

# avoid tzdata prompts
ENV DEBIAN_FRONTEND=noninteractive

# Set Timezone
RUN apt-get update && apt-get install -y tzdata
ENV TZ=Asia/Jakarta
RUN dpkg-reconfigure --frontend noninteractive tzdata

# Set default port for Kestrel
ARG PORT=8000
ENV ASPNETCORE_HTTP_PORTS=${PORT}

WORKDIR /app
EXPOSE ${PORT}

# ======================
# Build Image: .NET SDK
# ======================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ENV DEBIAN_FRONTEND=noninteractive

ARG PROJECT_PATH
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY . .

RUN dotnet restore "${PROJECT_PATH}"
RUN dotnet build "${PROJECT_PATH}" -c ${BUILD_CONFIGURATION} -o /app/build

# ======================
# Publish Stage
# ======================
FROM build AS publish
ARG PROJECT_PATH
ARG BUILD_CONFIGURATION=Release

# RUN dotnet publish "${PROJECT_PATH}" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false
RUN dotnet publish "$PROJECT_PATH" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

# ======================
# Final Runtime Image
# ======================
FROM base AS final
ARG PROJECT_DLL
ARG ASPNETCORE_ENVIRONMENT=Development

ENV FINAL_PROJECT_DLL=${PROJECT_DLL}
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
ENV DOTNET_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT

WORKDIR /app
COPY --from=publish /app/publish .

# Debug step to verify correct DLL exists
RUN echo "DLL to be executed at runtime: ${FINAL_PROJECT_DLL}" && ls -lh

ENTRYPOINT ["sh", "-c", "dotnet $FINAL_PROJECT_DLL"]