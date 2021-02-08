# Microsoft .NET Framework Remoting Service Sample
## Deploy to OpenShift Container Platform 4.6 with Windows Container

### OpenShift Blogs
[Using Microsoft SQL Server on Red Hat OpenShift](https://developers.redhat.com/blog/2020/10/27/using-microsoft-sql-server-on-red-hat-openshift/)

### Prerequisites
- Create a new project called "mssqldemo"
- Deploy the MSSQL Server 2019 to this project
- Create a secret called "mssql-secret". It has the variables "SA_PASSWORD" and "SERVICE_NAME"
- Pull the windows server base and application images

### How to deploy MS SQL on OCP
[Reference Here](https://github.com/johwes/sqlworkshops-sqlonopenshift)

### Deploy the application
Deploy the Remoting server
```
oc create -f msserver1.yaml
```

Deploy the Remoting client
```
oc create -f msclient1.yaml
```
