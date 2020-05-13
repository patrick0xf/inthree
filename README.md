# INTHREE

## Intro
This project is a reverse-engineered implementation of Honeywell's defunct in2myhome.com services that supported the ip-enabled ICM device for installation in Vista home security panels. It was creatively named **in3myhome**, as in, the successor to *in2myhome*.  The short hand for this project on GitHub is "inthree". The code name for this project is "GrandDetour" - which is still present in most of the code references.

The purpose of this project was to allow owners of existing ICM units to continue using their devices one the original web services were decommissioned.

This code is rather old and for hobbyist use only. Unless you own an ICM device in a functioning Vista security panel, this will be of no use to you.



## The tech behind this
This project is an ASP.NET 2.0 Web Server that is fully compatible with Mono's ASP.NET [https://www.mono-project.com/docs/web/aspnet/](https://www.mono-project.com/docs/web/aspnet/)
and can therefore run on either Windows or Linux or a cloud VPX.
The editor of choice for this project is Visual Studio Community Edition (any version)

## Project layout
Uncapitalized folders are exposed to the web
Capitalized folders are special
### App_Data
Special: This is where user access information is stored
### Core
Special: This is the core .net library for the project
### Properties
Special: Standard .net properties folder
### backspace
Web: Admin endpoint
### diag
Web: Diagnostic endpoint
### firmware
Web: Firmware upgrade endpoint
### iosmod
Web: Download location for customizing mobile access to the ICM
### pdf
Web: Download location for legacy Honeywell documentation
### setup
Web: Download location for host file when configuring an ICM device
### user
Web: User endpoint
### / (root folder)
Web: Device endpoint

## Configs
Basic config options can be set in **Web.config**
**Web.Release.config** contains config options override when running in release mode (ie a cloud environment)


## Getting started

1) Edit Web.Configs and deploy web site
2) Edit setup host files with your server's ip address
2) Enter the admin endpoint using admin/admin (currently hard-coded, since machine-based security was removed)
3) Create yourself a user for your ICM's mac address
4) Change your ICM's configuration by making it download the host file from the setup folder
5) Test a notification






