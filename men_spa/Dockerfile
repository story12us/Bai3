FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore "./men_spa.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet build "men_spa.csproj" -c Release -o /app

# Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "aspnetapp.dll"]

# Build an image using the Dockerfile in the current directory
#docker build --target build -t menspa .
# Run the image, executing the command 'ls /app'
#docker run -it menspa ls /app


FROM build AS publish
RUN dotnet publish "men_spa.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 5001

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "men_spa.dll"]