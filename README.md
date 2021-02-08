# Microsoft .NET Framework Remoting Service Sample
## Deploy to OpenShift Container Platform 4.6 with Windows Container

### OpenShift Blogs
[Using Microsoft SQL Server on Red Hat OpenShift](https://developers.redhat.com/blog/2020/10/27/using-microsoft-sql-server-on-red-hat-openshift/)

### Prerequisites
- Create a new project called "mssqldemo"
- Deploy the MSSQL Server 2019 to this project
- Create a secret called "mssql-secret". It has the variables "SA_PASSWORD" and "SERVICE_NAME"
- Pull the windows server base and application images

#### RHEL-based SQL Server Image
Create a SQL server template on OCP
```
oc create -f https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore-persistent-ex/dotnetcore-3.1-mssql/openshift/mssql2019.json
oc process --parameters mssql2019  # I don't rune this
```

#### Create the SQL Server
```
oc new-app --template=mssql2019 -p ACCEPT_EULA=Y
```

### Deploy the application
Deploy the Remoting server
```
oc create -f msserver1.yaml
```

Deploy the Remoting client
```
oc create -f msclient1.yaml
```


### How to deploy MS SQL on OCP
If you don't want to use template you can [reference here](https://github.com/johwes/sqlworkshops-sqlonopenshift) from scratch
