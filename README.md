
# ATEM - Attendance Employee Manager

## Overview

ATEM (Attendance Employee Manager) is a comprehensive solution designed for companies to effectively manage their employees and track attendance. Developed in C# using the ASP.NET framework, ATEM serves as an API that streamlines various administrative tasks related to employee management. This project is aimed at improving organizational efficiency by simplifying the processes of handling employee information, managing departmental structures, and overseeing attendance records.

## Features

- **Employee Management**: Organize employees into departments and manage their records.
- **Sick Days Reporting**: Employees can report their sick days.
- **Vacation Requests**: Employees can request vacations, which need to be approved by a manager.
- **Attendance Tracking**: Record the arrival and departure times of employees.
- **Timesheet Generation**: Generate timesheets for specific periods.
- **CSV Export**: Export attendance data as CSV files for further processing or reporting.

## Technologies Used

- **Backend**: 
  - C#
  - ASP.NET framework
- **Frontend**: 
  - (Planned) React for frontend application

## Installation

### Prerequisites

Before you begin, ensure you have the following prerequisites installed:

- [.NET SDK](https://dotnet.microsoft.com/download) version 8.0.0+
- [Database Server](#) (e.g., SSMS)

### Installation Steps

### a. Clone the Repository

1. Clone the repository using Git:

   ```bash
   git clone https://github.com/xflicky/ATEM.git
   ```

### b. Database Setup

1. Set up your database server (e.g., SSMS).
2. Create a new database in your preferred database management system.
3. Run migrations to create tables and seed data:

   ```bash
   dotnet ef database update
   ```

### c. Configuration

1. Update any configuration settings in the project. This might include:
   - Connection strings for the database.
   - API keys or secrets.
   
### d. Restore .NET Packages
1.  Restore the .NET packages by navigating to the project directory and running:
    
    ```bash 
    dotnet restore
    ```
### e. Build and Run

1. Build the project using the .NET CLI:

   ```bash
   dotnet build
   ```

2. Run the project:

   ```bash
   dotnet run
   ```

### Troubleshooting

If you encounter any issues during the installation process, consider the following solutions:

- **Database Connection Errors**: Double-check your database connection string in the configuration files.
- **Missing Dependencies**: Ensure all necessary dependencies are installed and up-to-date.


## API Endpoints

### Employee
- **Create Employee**: `POST /api/employees/create`
- **Get All Employees**: `GET /api/employees`
- **Get All Employees (including deleted)**: `GET /api/employees/all`
- **Update Employee**: `PUT /api/employees/{employeeId}`
- **Soft Delete Employee**: `POST /api/employees/{employeeId}/soft-delete`
- **Undelete Employee**: `POST /api/employees/{employeeId}/undelete`

### Department
- **Get All Departments**: `GET /api/departments/all`
- **Create Department**: `POST /api/departments/create`
- **Get Department by ID**: `GET /api/departments/{departmentId}`
- **Soft Delete Department**: `POST /api/departments/{departmentId}/soft-delete`
- **Undelete Department**: `POST /api/departments/{departmentId}/undelete`
- **Set Supervisor for Department**: `PATCH /api/departments/{departmentId}/set-supervisor/{employeeId}`
- **Add Employee to Department**: `POST /api/departments/{departmentId}/add-employee/{employeeId}`
- **Delete Employee from Department**: `DELETE /api/departments/{departmentId}/delete-employee/{employeeId}`

### Attendance
- **Record Attendance**: `POST /api/attendance/record/employee/{employeeId}`
- **Get Timesheet**: `GET /api/attendance/timesheet`
- **Download Timesheet**: `GET /api/attendance/timesheet-download`

### Sick Day
- **Announce Sick Day for Employee**: `POST /api/sickdays/announcement/employee/{employeeId}`
- **Get All Sick Days**: `GET /api/sickdays`

### Time Off
- **Request Time Off for Employee**: `POST /api/timeoffs/request/employee/{employeeId}`
- **Get Time Off by ID**: `GET /api/timeoffs/{timeOffId}`
- **Get All Time Off Requests**: `GET /api/timeoffs`
- **Approve Time Off Request**: `POST /api/timeoffs/approve/{timeOffId}`

These endpoints cover various functionalities related to attendance, department management, employee management, sick day reporting, and time off requests as documented in the Swagger specifications.

## Future Development

- Add API authentication, tie attendance operations with roles.
- Develop a React-based frontend application to interact with the API.

## Contact

For any questions or inquiries, please contact me at mail@radobanik.com.
See my website [radobanik.com](https://radobanik.com/) for more information about me and my projects :)

---

Thank you for seeing my project ATEM!
