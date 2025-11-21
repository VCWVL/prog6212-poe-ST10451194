Contract Monthly Claims Management System – Part 3
YouTube Links and GitHub

PowerPoint Presentation: https://www.youtube.com/watch?v=XxX81Gimx6E

Claims Demo: https://www.youtube.com/watch?v=brVpBBH9qgA

Database Demo: https://www.youtube.com/watch?v=zVcmbLhwZ9k

GitHub Repository: https://github.com/VCWVL/prog6212-poe-ST10451194

Project Overview

This project is Part 3 of the Contract Monthly Claims Management System, developed using ASP.NET Core MVC, C#, and SQL Server (SSMS). The system allows lecturers, programme coordinators, and academic managers to submit, manage, and approve monthly claims efficiently.

Part 3 builds upon Part 2 by introducing several new features and improvements:

Database export functionality for secure backup and reporting.

Enhanced file upload management, including metadata and encryption for supporting documents.

Improved dashboards and MVC Views for all roles, providing a cleaner and more intuitive interface.

Robust error handling and input validation across forms and workflows.

The system ensures role-based access, data integrity, and secure storage, making claim management seamless and reliable.

Key Features
1. User Authentication and Role Management

Fully functional login and registration system with role assignment.

Users are assigned roles: Lecturer, Programme Coordinator, Academic Manager.

Role-based redirects ensure users access only their dashboards and relevant actions.

Credentials are securely stored in the SQL Server database.

2. Claims Management

Lecturers can submit monthly claims including:

Work description

Hours worked

Hourly rate

Optional supporting document uploads

The system calculates claim amounts automatically (Hours × Rate).

All claims are persisted in the database with timestamps and status tracking.

3. Approval Workflow

Programme Coordinator: Reviews and verifies claims, approves or rejects, and provides feedback.

Academic Manager: Approves verified claims from coordinators and provides manager-specific comments.

Role-based workflows prevent unauthorized access to sensitive processes.

4. Database Export Functionality

Claims and user data can be exported securely for reporting or backup.

Exported data preserves all relationships and metadata for claims and uploaded files.

Supports ongoing auditing and system maintenance.

5. File Upload Management

Users can upload supporting documents with each claim.

Files are stored securely with metadata: original file name, stored name, size, type, encryption IV and tag.

Upload history is tracked and displayed for reference.

6. User Interface (UI)

Clean and responsive MVC Views for all functionalities.

Dashboards for lecturers, coordinators, and managers show claims status, pending actions, and summaries.

Intuitive navigation ensures minimal learning curve for users.

7. Error Handling and Validation

Prevents duplicate usernames during registration.

Validates form inputs to ensure data integrity.

Handles null or missing fields gracefully with default values.

Improvements Over Part 2

Part 3 introduces significant enhancements compared to Part 2:

Database Export Functionality – Ability to export claims and user data safely for backup or reporting.

Enhanced File Uploads – Metadata storage, encryption support, and upload history tracking.

Refined Dashboards and Views – Cleaner UI, better layout, and more intuitive navigation.

Role-Based Workflow Enhancements – Stronger access control and clearer claim processing for coordinators and managers.

Automated Calculations and Validations – Claims are calculated automatically with input validation.

Bug Fixes and Testing – Fully tested claim submission, approval, and export processes for reliability.

Technologies Used

Backend: ASP.NET Core MVC, C#

Frontend: Razor Views, HTML, CSS, Bootstrap (optional for styling)

Database: SQL Server (SSMS)

File Handling: Encrypted file storage with metadata

Session Management: ASP.NET Core Session for secure authentication

Database Schema
-- Users table
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Programme NVARCHAR(100) NULL
);

-- Claims table
CREATE TABLE Claims (
    ClaimId INT IDENTITY(1,1) PRIMARY KEY,
    LecturerId INT NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    HoursWorked DECIMAL(5,2) NOT NULL,
    HourlyRate DECIMAL(10,2) NOT NULL,
    Amount AS (HoursWorked * HourlyRate) PERSISTED,
    Status NVARCHAR(50) DEFAULT 'Submitted',
    DateSubmitted DATETIME DEFAULT GETDATE(),
    FileName NVARCHAR(255) NULL,
    FilePath NVARCHAR(500) NULL,
    CoordinatorComment NVARCHAR(255) NULL,
    ManagerComment NVARCHAR(255) NULL,
    CONSTRAINT FK_Claims_User FOREIGN KEY (LecturerId) REFERENCES Users(UserId)
);

-- ClaimDocuments table
CREATE TABLE ClaimDocuments (
    DocumentId INT IDENTITY(1,1) PRIMARY KEY,
    ClaimId INT NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    CONSTRAINT FK_ClaimDocuments_Claims FOREIGN KEY (ClaimId) REFERENCES Claims(ClaimId)
);

GitHub Commit History (Suggested)

Initial Commit – Project structure and configuration.

Add Models – User, Claim, ClaimDocuments.

Configure DbContext – SQL Server connection.

Add Controllers – User and Claim management.

Add Views – Login, registration, claim submission, dashboards.

File Upload Feature – Support for claim documents.

Role-Based Dashboards – Lecturer, coordinator, manager dashboards.

Export Functionality – Export claims and users to database.

Validation and Error Handling – Input validation and duplicate prevention.

Final Testing & Bug Fixes – Tested workflows and ensured database integrity.

References (Harvard Style)

Microsoft (2025) Introduction to ASP.NET Core MVC. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/overview
 (Accessed: 21 November 2025).

Microsoft (2025) SQL Server Documentation. Available at: https://learn.microsoft.com/en-us/sql/sql-server/
 (Accessed: 21 November 2025).

Stack Overflow (2025) How to handle file uploads in ASP.NET Core MVC. Available at: https://stackoverflow.com/questions/asp-net-core-mvc-file-upload
 (Accessed: 21 November 2025).

Microsoft (2025) Entity Framework Core Documentation. Available at: https://learn.microsoft.com/en-us/ef/core/
 (Accessed: 21 November 2025).

W3Schools (2025) HTML Forms. Available at: https://www.w3schools.com/html/html_forms.asp
 (Accessed: 21 November 2025).
