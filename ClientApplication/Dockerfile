# FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019
# FROM mcr.microsoft.com/dotnet/framework/runtime:4.8
# docker pull mcr.microsoft.com/dotnet/framework/sdk:4.8
# docker pull mcr.microsoft.com/dotnet/framework/runtime:4.8
# OCP 4.6.1 windows container server

# FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2 AS build
FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2-windowsservercore-ltsc2016 AS build
WORKDIR /app
COPY ClientApplication/. .
RUN msbuild /p:Configuration=Release

# FROM mcr.microsoft.com/windows/servercore:ltsc2019-amd64
# FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2-windowsservercore-ltsc2019 AS runtime
FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2-windowsservercore-ltsc2016 AS runtime

WORKDIR /app
# EXPOSE 4545
# COPY /bin/Debug .
COPY --from=build /app/bin/Release .
ENTRYPOINT ["ClientApplication.exe"]