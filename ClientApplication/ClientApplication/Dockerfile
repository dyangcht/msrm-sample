# FROM mcr.microsoft.com/dotnet/framework/runtime:4.8-windowsservercore-ltsc2019
FROM mcr.microsoft.com/windows/servercore:ltsc2019-amd64
WORKDIR /app
# EXPOSE 4545
COPY /bin/Debug .
ENTRYPOINT ["ClientApplication.exe"]