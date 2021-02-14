FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster

WORKDIR /app
COPY billing_callbacks.csproj billing_callbacks.csproj
RUN dotnet restore
COPY . . 
RUN dotnet build
CMD ["dotnet", "run"]