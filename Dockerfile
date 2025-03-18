# Use official .NET SDK image for building the app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src



# Copy the entire project directory

COPY TodoApi/ TodoApi/



# Set working directory to the project folder

WORKDIR /src/TodoApi



# Restore dependencies

RUN dotnet restore



# Build the app

RUN dotnet publish -c Release -o /app/publish



# Use official ASP.NET runtime image

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

WORKDIR /app



# Copy the build output from the previous stage

COPY --from=build /app/publish .



# Expose the port

EXPOSE 80



# Run the app

ENTRYPOINT ["dotnet", "TodoApi.dll"]


