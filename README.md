# Charma 
## Gamifying the Volunteer Process 
### GVSU Capstone-project - Winter 2016

#### Contributors
- Xinyi Ou
- Kyle Niewiada
- Dave Walsh

#### Overview
Charma is an open API web application that connects volunteers with charitable opportunities.  We gamify the experience through special badges, leader boards, encourage tangible goods, and encourage public praising from charities. 

#### Dependencies

(This assumes you are trying to use Azure Web services to host this)

- A local database on SQL express and remote database on Azure demonstrated in the below configuration file sample

`\GVSU-capstone-project\capstone_project\Web\ConnectionStrings.config`

```
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=localhost\SQLExpress; Initial Catalog=GVSU.Charma.Web.Local; Integrated Security=True" providerName="System.Data.SqlClient" />
  <add name="LocalConnection" connectionString="Data Source=localhost\SQLExpress; Initial Catalog=GVSU.Charma.Web.Local; Integrated Security=False; User ID=""; Password=""; Connect Timeout=60" providerName="System.Data.SqlClient" />
  <add name="AzureSQLServerConnection" connectionString="Data Source="";Initial Catalog=GVSU.Charma.Web;Integrated Security=False;User ID="";Password="";Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />
</connectionStrings>
```

- A configuration file for the local Selenium WebDriver IIS testing

`\GVSU-capstone-project\capstone_project\Web\Tests\App.config`

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="LocalUrl" value="" /> //localhost URL
    <add key="RemoteUrl" value="" /> //Azure service URL
  </appSettings>
</configuration>
```

[screencast overview](https://www.youtube.com/watch?v=HWSoWfWqcsU)
