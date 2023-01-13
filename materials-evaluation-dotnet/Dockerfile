FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
COPY . ./
RUN dotnet restore
ENTRYPOINT dotnet watch run --no-launch-profile

# # Build and publish a release
# RUN dotnet publish -c Release -o out

# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:7.0
# WORKDIR /App
# ENV ASPNETCORE_ENVIRONMENT "Development"
# ENV ASPNETCORE_URLS http://*:80
# COPY --from=build-env /App/out .
# #ENTRYPOINT ["dotnet", "materials-evaluation.dll"]
# ENTRYPOINT dotnet materials-evaluation.dll watch run