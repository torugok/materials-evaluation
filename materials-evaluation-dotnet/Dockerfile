FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
COPY . ./
RUN dotnet restore

# para executar as migrations, referencia: https://stackoverflow.com/questions/60129303/using-dotnet-ef-with-docker-and-asp-net-core-3-1
# FIXME: não funcionou mesmo assim
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT dotnet watch run --no-launch-profile
