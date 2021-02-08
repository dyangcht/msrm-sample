# Microsoft .NET Framework Remoting Service Sample
## Deploy to OpenShift Container Platform 4.6 with Windows Container

### OpenShift Blogs
[Using Microsoft SQL Server on Red Hat OpenShift](https://developers.redhat.com/blog/2020/10/27/using-microsoft-sql-server-on-red-hat-openshift/)

### Prerequisites
- Create a new project called "mssqldemo"
- Deploy the MSSQL Server 2019 to this project
- Create a secret called "mssql-secret". It has the variables "SA_PASSWORD" and "SERVICE_NAME"
- Pull the windows server base and application images

### RHEL-based SQL Server Image
Create a SQL server template on OCP
```
oc create -f https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore-persistent-ex/dotnetcore-3.1-mssql/openshift/mssql2019.json
oc process --parameters mssql2019  # I don't rune this
```

### Create the SQL Server
```
oc new-app --template=mssql2019 -p ACCEPT_EULA=Y
```

### Deploy .NET Core Image Streams
Check the .NET Core 3.1
```
oc get is dotnet
oc describe is dotnet
```
It's not listed
Deploy them
```
oc create -f https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams.json
```
Deploy .NET Core 3.1 application and test it
```
oc new-app dotnet:3.1~https://github.com/redhat-developer/s2i-dotnetcore-persistent-ex#dotnetcore-3.1-mssql --context-dir app --as-deployment-config
oc expose service s2i-dotnetcore-persistent-ex
oc get route
```
Connect to MS SQL Server, before do this, the application generates the records in memory only
```
oc set env --from=secret/mssql-secret dc/s2i-dotnetcore-persistent-ex --prefix=MSSQL_
```

## Download the images to Windows worker node
First, get the windows worker node name
```
oc get nodes -l kubernetes.io/os=windows
```
Then log into the working pod
```
oc -n openshift-windows-machine-config-operator rsh $(oc get pods -n openshift-windows-machine-config-operator -l app=winc-ssh -o name)
```
Log into the Windows
```
sshcmd.sh ip-10-0-155-23.us-east-2.compute.internal
```
It should drop you into PowerShell as below
```
Windows PowerShell
Copyright (C) Microsoft Corporation. All rights reserved.

PS C:\Users\Administrator>
```

### Deploy the .NET framework application
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
