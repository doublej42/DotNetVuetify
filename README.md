# ASP.NET Core Vue Starter

The repository contains an ASP.&#8203;NET Core + Vue.js + Vuetify 2 starter template. 


This template was base of https://github.com/SoftwareAteliers/asp-net-core-vue-starter and updated by DoubleJ42

The template is created by Vue CLI 3.0 with a new plugin based architecture allowing developers to interactively scaffold a new project with just a one command.

Original article how to create the starter template is available [here](https://medium.com/software-ateliers/asp-net-core-vue-template-with-custom-configuration-using-cli-3-0-8288e18ae80b).

---

## Table of Contents

* [Features](#features)
* [Used Technology Stack](#used-technology-stack)
* [Prerequisites](#prerequisites)
* [Getting Started](#getting-started)

## Features

* Hot module replacement
* Code-splitting
* Tree-shaking
* ES2017 transpilation
* Long term caching and so on

## Used Technology Stack

**ASP.NET Core 3.0:**

* Web.API
* JavaScript Services middleware to integrate with client app

**Vue.js with CLI 3.0 supporting optional integrations:**

* TypeScript
* Progressive Web App
* Vue Router & Vuex (State Store)
* Linting, unit testing, E2E testing
* 3rd party component frameworks (Vuetify, Vue Bootstrap etc.)
* publish your personal/enterprise plugin and so on...

*For a full feature list, I suggest you to read the [official CLI release statement](https://medium.com/the-vue-point/vue-cli-3-0-is-here-c42bebe28fbb) by Evan You.*

## Prerequisites

* [.NET Core 3.0 SDK](https://www.microsoft.com/net/download/windows)
* [NodeJS](https://nodejs.org/) >= 8.9
* Your favourite editor like ([VS Code](https://code.visualstudio.com/))  or Visual Studio 2017/19

---

## Getting started

There are two ways how to set up the project: one for people who want to create their own template and choose custom integrations and the other for developers who want to start with no configuration.

## Clone the starter with default configuration

* Clone this repository `git clone https://github.com/doublej42/DotNetVuetify`

or you can use .NET Core CLI templates:

* Install the template from NuGet repository: `dotnet new -i DotNetVuetify`

* Initialize the project: `dotnet new DotNetVuetify -o MyProject`

## Scaffold Vue.js app with custom configuration

If you prefer to overwrite default Vue client app with custom settings, take the following steps:

* **Remove all the contents** of the folder /clientapp
* Create a new Vue project by using Vue CLI: `vue create client-app` OR by using CLI graphical interface running `vue ui`

> Unfortunately Vue CLI does not allow us to set a project name by C# standards using Upper Camel Case (Pascal Case) naming convention, so let's initiate app inside of client-app folder and then move the content to clientapp.

* **Move all the contents from the new folder /client-app to /clientapp.**

Now application is ready to run.

## Run the application

You have two choices when it comes to how you prefer to run the app. You can either use the command line or the build-in run command.

### 1. Using the command line

* Run the .NET application using `dotnet run`

### 2. Using the built-in run command

* Run the application in VSCode or Visual Studio 2017 by hitting `F5`

> It will take some time during the first run to download all client side dependencies.

## View your application running

Browse to [http://localhost:5000](http://localhost:5000) for ASP.&#8203;NET Core + Vue app or browse to [http://localhost:8080](http://localhost:8080) for Vue app only.

## Recommended plugin for debugging Vue

* Get Chrome DevTools for Vue.js [here](https://chrome.google.com/webstore/detail/vuejs-devtools/nhdogjmejiglipccpnnnanhbledajbpd)

## Build Nuget Package
```
nuget pack
```
## Docker Support

 * `docker build -t containerTag`
 * `docker run -p 80:80 containerTag`

if you want tp publish it 

 * `docker push containerTag`


---

## Issues and Contribution

Want to file a bug, contribute some code, or improve documentation? Excellent! Please make sure to check existing issues before opening a new one.

---

## Contributors

Special thanks to everyone who helped and contributed to this project!

* [@jdebarochez](https://github.com/jdebarochez)
* [@SoftwareAteliers](https://github.com/SoftwareAteliers/asp-net-core-vue-starter)
---

## License

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat)](/content/LICENSE)