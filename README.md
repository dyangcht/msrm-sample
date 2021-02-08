# Microsoft .NET Framework Remoting Service Sample
## Deploy to OpenShift Container Platform 4.6 with Windows Container

### Prerequisites
- Create a new project called "mssqldemo"
- Deploy the MSSQL Server 2019 to this project
- Create a secret called "mssql-secret". It has the variables "SA_PASSWORD" and "SERVICE_NAME"
- Pull the windows server base and application images

### Deploy the application
Deploy the Remoting server
```
oc create -f msserver1.yaml
```

Deploy the Remoting client
```
oc create -f msclient1.yaml
```
