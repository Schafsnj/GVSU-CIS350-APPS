# Overview

This document is our srs, it shows the functional and not functional requirements for our web application. We focus on account and task management along with communication for our functinal requirements. For non functional requirements we we focus on the same thing bit also the performance of our application.

# Functional Requirements

1. Account Management
	1. The app shall allow employees and managers to login with a username and password.
	2. The app shall be able to create new user accounts.
	3. Employees shall be able to change their passwords.

2. Task Management
	1. Employees shall be able to see their assigned tasks for the week.
	2. Managers shall be able to assign other employees to specific tasks.
	3. Managers shall be able to create new tasks.
	4. Managers shall be able to close tasks/ update tasks.

3. Communication
	1. Users shall be able to submit complaints to the company through a support page.
	2. Employees shall be able to submit requests/complaints to managers.
	3. Managers shall be able to send company wide emails to employees under them.
	4. Employees shall be able to email a manager by clicking a button on the employee page.

4. General
	1. The app shall interact with an SQL database to store, update, and retrieve information.
	2. The app shall contain multiple page views both public (Website homepage/info) and privately only to employees (Task management). 

# Non-Functional Requirements

1. Account Management
	1. The app shall register new accounts to the system within a minute of their creation.
	2. The app shall encrypt user passwords.
	3. Passwords shall be at least eight characters long with at least one lowercase character, at least one uppercase character, and at least one digit.
	4. The app should prompt the user if they want to change their password after 3 failed attempts.
	5. Users shall be prompted to change their temporary password when first logging in.

2. Task Management
	1. Employees shall be able to see any changes made to assignments within 1 minute of the manager submitting them.

3. Performance
	1. The app shall push any updates to the database within a minute.
	2. The app shall be friendly to users with red-green colorblindness.
	3. The app should be on a public server to log in from anywhere.
	4. The app should be able to work on all OS.
	5. The web app shall be able to handle 100’s of users.
	6. The website shall load each page within 30 seconds with a good connection.
	7. The SQL Database shall be accessed over the web and not held localy.


