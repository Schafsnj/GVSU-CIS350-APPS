# Average Party of Programmers (APPS)

This project is a prototype web app meant to be used by a business. The app has a log in system to handle managers and employees. Managers may create tasks and assign them to employees. Employees are able to see all of the tasks assigned to them and are able to close tasks once completed.

## Team Members 

* [Jayden Schafsnitz](https://github.com/Schafsnj/CIS350-HW2-Schafsnitz.git) 
* [Tim Nguyen](https://github.com/nguytim4098/CIS350-HW2-Nguyen.git) 
* [Hunter Sutton](https://github.com/Hunter-36/CIS350-HW2-Sutton)
* [Eldin Kadic](https://github.com/EldinKadic/CIS350-HW2-Kadic) 

## Prerequisites

* Visual Studio 

## Run Instructions

1. Clone the repository from Visual Studio
2. In VS, on the “Solution Explorer” tab, open up the “APP-Web_APP.sln” found in the “APP-Web_APP” folder
3. On the “Solution Explorer” tab, open “App-Data” and double click on the .mdf file to open it in the “Server Explorer”.
4. On the “Server Explorer” tab, right click on “APPS-Project-Database.mdf and select properties. 
5. In the “Properties” tab, copy the entire Connection String. 
6. Past that string as follows @“inserthere“ in the connectionString variable at the top of the following files in the Services folder in the file explorer: LinkedDAO.cs, TaskDAO.cs, & UsersDAO.cs
7. Click on the “IIS Express” button to launch the app (next to green play button)
