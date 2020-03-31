# Traveler Reviews

#### Travel Reviews project for Epicodus, 03/30/2020

#### By Andrew Philott and Andriy Veremyeyev

<!-- [![Project Status: Inactive – The project has reached a stable, usable state but is no longer being actively developed; support/maintenance will be provided as time allows.](https://www.repostatus.org/badges/latest/inactive.svg)](https://www.repostatus.org/#inactive) -->
<!-- [![Project Status: Active – The project has reached a stable, usable state and is being actively developed.](https://www.repostatus.org/badges/latest/active.svg)](https://www.repostatus.org/#active) -->

[![Project Status: WIP – Initial development is in progress, but there has not yet been a stable, usable release suitable for the public.](https://www.repostatus.org/badges/latest/wip.svg)](https://www.repostatus.org/#wip)
![LastCommit](https://img.shields.io/github/last-commit/Andrew-Philpott/TravelAPI)
![Languages](https://img.shields.io/github/languages/top/Andrew-Philpott/TravelAPI)
[![MIT license](https://img.shields.io/badge/License-MIT-orange.svg)](https://lbesson.mit-license.org/)

## Description

An API that allows users to GET and POST reviews about various travel destinations around the world.

## Specs

| Spec                                                                                                     | Input                    | Output                              |
| :------------------------------------------------------------------------------------------------------- | :----------------------- | :---------------------------------- |
|                                                                                                          |
| Authorized user:                                                                                         |
| Main page shows links to assortiment and to log out                                                      | main page                | assortiment, log out                |
| Log out link leads to log out page                                                                       | log out                  | log out page                        |
| Log out page leads back to main page                                                                     | log out                  | main page                           |
| Assortiment link leads to list with clickable treats and flavors, possibility to add new treat or flavor | assortiment              | assortiment page                    |
| Add new treat/flavor button leads to add new treat/flavor page                                           | add new treat/flavor     | log in                              |
| Click on treat/flavor leads treat/flavor details with possibility to edit and delete                     | treat/flavor             | treat/flavor details                |
| Edit/delete treat/flavor leads to edit/delete pages                                                      | edit/delete treat/flavor | edit/delete pages                   |
|                                                                                                          |
| Unauthorized user:                                                                                       |
| Main page shows links to assortiment, create account and to log in                                       | main page                | assortiment, create account, log in |
| Main page shows links to assortiment and to log out                                                      | authorized user          | assortiment, log out                |
| Assortiment link leads to list with clickable treats and flavors, possibility to add new treat or flavor | assortiment              | assortiment page                    |
| Add new treat or flavor button leads to log in page                                                      | add new treat/flavor     | log in                              |
| Click on treat/flavor leads treat/flavor details with possibility to edit and delete                     | treat/flavor             | treat/flavor details                |
| Edit/delete treat/flavor leads to log in page                                                            | edit/delete treat/flavor | log in                              |

## Screenshots

#### Search Module:

<image src="./TravelApi.Solution/Screenshots/SearchTool.gif" width="750px" />

## Setup/Installation Requirements

### Download or clone this repository

### Installing and Configuring MySQL database:

Option A For Mac:

1. Download and install [MySQL Community Server DMG File](https://dev.mysql.com/downloads/file/?id=484914) and [MySQL Workbench DMG File](https://dev.mysql.com/downloads/file/?id=484391)

Option B for Windows:

1. Download and install [MySQL Web Installer](https://dev.mysql.com/downloads/file/?id=484919)

2. Run migration commands in the command prompt within the project folder:

- dotnet ef migrations add addIdentity,
- dotnet ef database update

### Installing and Configuring .NET:

- Download .NET application [for Mac](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.106-macos-x64-installer) or [for Windows](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-2.2.203-windows-x64-installer) and install it
- Open terminal
- Run "dotnet run" to run the application

## Known Bugs

No bugs

## Support and contact details

For feedback, questions and/or ideas, please email <andrewphilpott92@gmail.com> or <belyybrat@gmail.com>

## Technologies Used

- .NET Core
- C#
- ASP.NET Core MVC
- Entity Framework
- MySQL Workbench
- CSS
- HTML

### License

This software is licensed under the MIT license.

Copyright (c) 2020 **Andrew Philott**, **Andriy Veremyeyev**
