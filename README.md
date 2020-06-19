<!-- 
	Huge thank you to this repository for their amazing README template!
	https://github.com/othneildrew/Best-README-Template/blob/master/README.md

	Base template : https://github.com/wearespacey/csharp-backend-boilerplate
-->

<!-- PROJECT SHIELDS -->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://dotnet.microsoft.com/download/dotnet-core/3.1">
    <img src="https://d585tldpucybw.cloudfront.net/sfimages/default-source/productsimages/justmock/justmock__net_770.png" alt="Logo">
  </a>

  <h3 align="center">ASP.NET Core back-end boilerplate</h3>

  <p align="center">
    An awesome back-end template built with ASP.NET Core to jumpstart your projects!
    <br />
    <a href="https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate"><strong>Explore the docs �</strong></a>
    <br />
    <br />
    <a href="https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/issues">Report Bug</a>
    �
    <a href="https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

- [Table of Contents](#table-of-contents)
- [About The Project](#about-the-project)
  - [Built With](#built-with)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)


<!-- ABOUT THE PROJECT -->
## About The Project

This is my personal implementation of a RESTful API developed with love and consideration.


### Built With
You will find herebelow the frameworks and dependencies used by this solution:
* [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [System.Text.Json](https://www.nuget.org/packages/System.Text.Json/)
* [Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore)
* [Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer)
* [AutoMapper](https://www.nuget.org/packages/AutoMapper)
* [JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
* [EntityFramework Core](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)


<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

Please make sure you have .NET Core 3.1 installed on your computer.

### Installation
 
1. Clone the repo
```sh
git clone https://github.com/hunteroi/aspnetcore-backend-boilerplate.git
```
2. Open the solution with Visual Studio / Visual Studio Code
3. Add your database's connection string as an environment variable with the following name : `boilerplate_ConnectionStrings__DbContext`
4. Use the *Package Manager Console* to `Add-Migration InitialCreate` 
5. Then `Update-Database`
6. Make sure you have selected the API project as **Start-up project** and enjoy!


<!-- ROADMAP -->
## Roadmap

See the [open issues][issues-url] for a list of proposed features (and known issues).



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated** as long as they served the purpose of this repository : build a general back-end solution customizable for any project.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push the Branch to Remote (`git push origin feature/AmazingFeature`)
5. Open a Pull Request from your Feature Branch to this project Develop Branch



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/HunteRoi/aspnetcore3.1-backend-boilerplate?style=flat-square
[contributors-url]: https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/HunteRoi/aspnetcore3.1-backend-boilerplate?style=flat-square
[forks-url]: https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/network/members
[stars-shield]: https://img.shields.io/github/stars/HunteRoi/aspnetcore3.1-backend-boilerplate?style=flat-square
[stars-url]: https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/stargazers
[issues-shield]: https://img.shields.io/github/issues/HunteRoi/aspnetcore3.1-backend-boilerplate?style=flat-square
[issues-url]: https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/issues
[license-shield]: https://img.shields.io/github/license/HunteRoi/aspnetcore3.1-backend-boilerplate?style=flat-square
[license-url]: https://github.com/HunteRoi/aspnetcore3.1-backend-boilerplate/blob/master/LICENSE
