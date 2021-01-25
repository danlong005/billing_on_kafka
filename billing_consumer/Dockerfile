FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster

WORKDIR /app
COPY billing_consumer.csproj billing_consumer.csproj 
RUN dotnet restore
COPY . . 
RUN dotnet build
CMD ["dotnet", "run"]
