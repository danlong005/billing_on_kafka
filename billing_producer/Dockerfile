FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster

WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build
CMD ["dotnet", "run"]