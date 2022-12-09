# <img src='/YouInvestMe/wwwroot/assets/logo.svg' width='36px'> YouInvestMe
>Web Application for Software Engineering Module at Anglia Ruskin University.

![Version](https://img.shields.io/badge/version-1.5.9-blue) ![License](https://img.shields.io/badge/licence-MIT-green)

#### Abstract
This project has been released under the MIT licence by a group of three second-year undergraduate students at Anglia Ruskin University in Fall semester 2022.

#### Programming Languages and Tools
- .NET platform
- Visual Studio 2022
- Visual Studio Code 2022
- C# - the programming language
###### Specific use of:
- ASP.NET 7.0
- Entity Framework Core
- MySQL
- Azure Cloud
- Github actions
- Zenhub (collaboration tool)

### 💻 Try it out
Good news is that you can try out running the project on your computer. However, the downside is there are some prerequisites to follow.

#### Prerequisites
**1. Install dotnet**

- On Linux
```sh
$ sudo apt update
$ sudo apt install dotnet
```
- On Mac
```sh
$ brew install dotnet
```

**2. Install mysql server and create database**

```sh
sudo apt install mysql
```

**3. Run the server, open the server shell and create database**

```sh
$ mysql > CREATE DATABASE youinvestme;
```

<br/>

> ❗️ Assuming you have installed mysql server and setup database, we will move on to the specific configurations to run the project.

<br/>

#### Run
- All you have to do is go to `appsettings.Development.json` file and change the connection string that matches yours.

Set up `user` and `password` according to your localhost server.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
      "DefaultConnection": "server=localhost;user=YOUR_DATABASE_USERNAME;password=YOUR_DATABASE_USER_PASSWORD;database=youinvestme"
  }
}
```

- Change into project directory if you are not already
```sh
cd YouInvestMe
```

- Apply the migrations
\* This needs `dotnet ef tools` to be installed. Google for more.

```sh
$ dotnet ef database update
```

- Finally, run the project
```sh
dotnet watch run
```

#### 🚀 Your output in the terminal should look something like this:
![](/misc/dotnet-watch-run.jpg)

#### Once done, fee free to create an account for yourself through `Register` at the bottom
![](/misc/default-login.jpg)

**Authors thoughts on the module:**
- An amazing opportunity for us to work in agile environment
- Gained technical skills and got the hands dirty with C# code
- Learned the concepts of software engineering in general
- Had fun and enjoyed the journey all the way through

This project is under [MIT licence](/LICENCE).

&copy; December 2022, YouInvestMe
