Dibware.Template.Presentation.Web
=================================

A C# ASP.net 4.5, MVC 4 web template, using Domain Driven Development, IOC patteerens

## A WORK IN PROGRESS!!!
This is very much a work in progress. Check back soon for more updates. 
Feel free to branch or assist if the project looks helpeful to you.

### Feature MusCoW
#### Must have
* Sql Membership, Roles, Account mamangement
* Registration and Login
* Error Logging module
* Dated Terms and conditions module
* Contact Form module
* Notifications module
* About page
* Add more tests!

#### Could have
* Change contact form to a ticket based system
* Add more tests!

#### Would have
* Add more tests!

## Architecture
* Based strongly on an DDD architecture devised by by John collinson
### Layers
* Presentation 
    * Web
* Core
    * Domain
    * Application
* Infrastructure
    * SqlDataAccess
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

