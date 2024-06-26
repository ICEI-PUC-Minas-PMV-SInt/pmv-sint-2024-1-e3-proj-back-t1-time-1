FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG TARGETARCH
WORKDIR /app

COPY src/*.csproj .
RUN dotnet restore -a $TARGETARCH

COPY src/. .
RUN dotnet publish -a $TARGETARCH --no-restore --property:PublishDir=/app

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations add InitialCreate
RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/nightly/aspnet:8.0-alpine-composite
EXPOSE 8080
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["dotnet", "Pharma.dll"]