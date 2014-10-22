Dibware.Template.Presentation.Web
=================================

A C# ASP.net 4.5, MVC 4 web template, using Domain Driven Development, IOC patterns. using Ninject for DI.
The aim of this project is to build a template that can be used as a starting point for any future web based projects. 

## Licence
MIT License (MIT) (See mit-licence.txt)

## A WORK IN PROGRESS!!!
This is very much a work in progress. Check back soon for more updates. 

## Branching, Copy Assist 
Feel free to branch, copy or assist if the project looks helpeful to you. Please note database project is included in solution.

### Feature MoSCoW
See Wiki page

## Architecture
* Based strongly on a DDD architecture devised by John collinson
### Layers
* Presentation 
    * Web
    * Web Tests
* Core
    * Domain
    * Domain Tests
    * Application
    * Application Tests
* Infrastructure
    * SqlDataAccess
    * SqlDataAccess Tests
* Database

## Prerequisit DLLs
* AutoMapper
* Dibware.Extensions.dll
* Dibware.Helpers.dll
* Dibware.Web.Security.dll
* Dibware.Web.Security.dll
* DotNetOpenAuth.Core.dll
* EntityFramework.dll
* EntityFramework.SqlServer.dll
* LowercaseRoutesMVC.dll
* Newtonsoft.Json.dll
* Ninject.dll
* Ninject.Web.Mvc.dll
* System.Web.Optimization.dll
* WebGrease.dll

## Git Commits
* Name your commits in the following format YYYYMMDD-HHMM-IINN COMMENT
* Where YYYY    = Year
* Where MM      = Month
* Where DD      = Day
* Where HH      = Hour (24)
* Where MM      = Minute
* Where II      = Initials of developer (2-4 chars)
* Where NN      = Machine name identifier checked in from (2-4 chars)
    * DT = Desktop
    * LT = Laptop 
    * BS = Build Server
* Where COMMENT = The work that has been carried out for this commit
* Example 20140321-0525-DWDT WebPrinciple and WebIdentity added

## Standards
Follow Microsoft c# standards
Suggested to use Resharper and follow suggestions where appropriate

### Code Blocks
* All code blocks must be wrapped in braces, even if just one line

### Commenting
* Comment all code, implementation and method signatures 
* Suggest that GhostDoc is used for methods, and contenet edited as appropriate
* Keep comments up to date with changes

### Referenced DLLs
* Do not use packages from Nuget in the project or solution- I feel these make the solution messy
* Add referenced .dlls to the Library directory in each project and reference from there
* Remove unused references where known
* Remove unused "usings" from classes and modules

### Regions
* Use region directives to split up logical blocks of code Constructors, Properties, Methods, interface implentations, etc.

### Text Strings
* All text strings must be held in a resource file in the Resources directory

### Unit Tests
* Each project in the solution must have an accompanying TEST project
* Each TEST project must have the same name as the project it is to test but with ".Tests" suffix to the name
* All code must have an accompanying test where possible
* File locations of tests must emulate the location of the class being tested
* Test method names must be in the format of "Test_ActionBeingTested_Conditions_ExpectedResult" where possible

