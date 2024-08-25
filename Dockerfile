# Create a stage for building the application.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

COPY . /source

WORKDIR /source/src/presentation/web-api

# Install Entity Framework Core tools
RUN dotnet tool install --global dotnet-ef

# Ensure the tools are available on the PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Add the wait-for-db.sh script
COPY wait-for-db.sh /wait-for-db.sh
RUN chmod +x /wait-for-db.sh

# This is the architecture you’re building for, which is passed in by the builder.
ARG TARGETARCH

# Build the application.
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

# Migrations
CMD /wait-for-db.sh dotnet ef database update

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app

# Copy everything needed to run the app from the "build" stage.
COPY --from=build /app .

ENTRYPOINT ["dotnet", "web-api.dll"]