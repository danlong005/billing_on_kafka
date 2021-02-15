FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster

WORKDIR /app
COPY simple_approval_callback.csproj simple_approval_callback.csproj
RUN dotnet restore
COPY . . 
RUN dotnet build
CMD ["dotnet", "run"]