# Overview

This document is our SRS, which details the primary features of our web application in the form of functional and non-functional software requirements. Our functional requirements focus on account and task management as well as communication. Our non-functional requirements also mainly cover account/task management, along with general performance of the application.

# Software Requirements

Individual software requirements are organized and grouped into several categories that each make up a particular general feature of the app, such as account management for example.

## Functional Requirements

1. Account Management
	1. The app shall allow employees and managers to login with a username and password.
	2. The app shall be able to create new user accounts.
	3. Employees shall be able to change their passwords.
	4. Employees shall be prompted to enter new passwords twice for verification.
	5. The app shall be able to send a password reset email to users if necessary.

2. Task Management
	1. Employees shall be able to see their assigned tasks for the week.
	2. Managers shall be able to assign other employees to specific tasks.
	3. Managers shall be able to create new tasks.
	4. Managers shall be able to close/update tasks.
	5. Employees shall be able to request assignment to tasks. 

3. Communication
	1. Users shall be able to submit complaints to the company through a support page.
	2. Employees shall be able to submit requests/complaints to managers.
	3. Managers shall be able to send company-wide emails to employees under them.
	4. Employees shall be able to email a manager by clicking a button on the employee page.
	5. The app shall include a contacts page for general communication with the company.

4. General
	1. The app shall interact with an SQL database to store, update, and retrieve information.
	2. The app shall contain multiple page views both public (website homepage/info) and privately only to employees (task management). 
	3. Users shall be able to select between light and dark mode. 

## Non-Functional Requirements

1. Account Management
	1. The app shall register new accounts to the system within a minute of their creation.
	2. The app shall encrypt user passwords.
	3. Passwords shall be at least eight characters long with at least one lowercase character, at least one uppercase character, and at least one digit.
	4. The app should prompt the user if they want to change their password after 3 failed attempts.
	5. Users shall be prompted to change their temporary password when first logging in.

2. Task Management
	1. Employees shall be able to see any changes made to tasks within 1 minute of the manager submitting them.
	2. Managers shall be able to assign multiple employees to a task at once.
	3. Managers shall be able to create multiple tasks at once.
	4. Managers shall be able to see task assignment requests from employees within 1 minute of them being sent.
	5. Employees shall be able to see their newly assigned tasks within 1 minute of the manager assigning them.

3. Performance
	1. The app shall push any updates to the database within a minute.
	2. The app shall be friendly to users with red-green colorblindness.
	3. The app should be on a public server to log in from anywhere.
	4. The app should be able to work on all OS.
	5. The web app shall be able to handle hundreds of users.
	6. The website shall load each page within 30 seconds with a good connection.
	7. The SQL Database shall be accessed over the web and not held locally.

4. Design
	1. The website pages shall be displayed in a readable and easy to navigate manner.
	2. The login page shall be a small section in the top right of the home screen.

# Software Artifacts

This section includes links to the various software artifacts that we developed during the design process of the application.

## Use-Case Diagrams/Descriptions

- [Account Management UML Diagram](https://github.com/Schafsnj/GVSU-CIS350-APPS/blob/f58af4c91d39a2bf532b801914b8e2b04155bed3/artifacts/use_case_diagrams/AccountManagementUML.drawio.pdf)
- [Communication System UML Diagram](https://github.com/Schafsnj/GVSU-CIS350-APPS/blob/f58af4c91d39a2bf532b801914b8e2b04155bed3/artifacts/use_case_diagrams/CommunicationSystemUML.drawio.pdf)
- [Task Management UML Diagram](https://github.com/Schafsnj/GVSU-CIS350-APPS/blob/f58af4c91d39a2bf532b801914b8e2b04155bed3/artifacts/use_case_diagrams/TaskManagementUML.pdf)
- [Assign Task Use-Case Description](https://github.com/Schafsnj/GVSU-CIS350-APPS/blob/f58af4c91d39a2bf532b801914b8e2b04155bed3/artifacts/use_case_diagrams/assign_task_description.md)
