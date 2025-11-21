# Contract Monthly Claims Management System

## Overview

This project is a **Contract Monthly Claims Management System** built using **ASP.NET Core MVC** and **SQL Server (SSMS)**. It allows lecturers, programme coordinators, and academic managers to manage monthly claims efficiently. The system features a fully functional **login and registration system**, claims submission, approval workflow, and persistent storage using a SQL database.  

This project represents **Part 2 of the system**, with significant improvements over the initial prototype.

---

## Features

### 1. User Authentication
- Fully functional **Login and Registration system**.
- Users are assigned **roles**: Lecturer, Programme Coordinator, Academic Manager.
- Role-based redirects to their respective dashboards.
- User credentials and information are securely stored in the SQL database.

### 2. Claims Management
- Lecturers can **submit claims** including:
  - Description of the work
  - Hours worked
  - Hourly rate
  - Supporting document uploads (optional)
- The system **automatically calculates the claim amount** (`HoursWorked × HourlyRate`).
- Claims are stored in the **SQL Server database**, ensuring data persistence.

### 3. Approval Workflow
- **Programme Coordinator** can review and verify claims:
  - Approve or reject submitted claims.
  - Add comments for lecturer feedback.
- **Academic Manager** can approve verified claims from the coordinator:
  - Approve or reject claims.
  - Add manager-specific comments.
- Claims workflow is **role-based**, and only appropriate users can access their part of the process.

### 4. Database Integration
- The system uses **SQL Server (SSMS)** for persistent data storage.
- Database contains the following tables:
  - **Users**: Stores usernames, passwords, roles, and programme info.
  - **Claims**: Stores claim information, including hours, rate, amount, status, and comments.
  - **ClaimDocuments**: Optional table to store uploaded files associated with claims.
- Claims and users are fully linked with **foreign key relationships**.

### 5. User-Friendly Interface
- Clean, organized, and responsive **MVC Views** for:
  - Login and Registration
  - Submit Claim
  - My Claims (Lecturer)
  - Pending Claims (Programme Coordinator)
  - Claims Ready for Approval (Academic Manager)
  - Claim Review Pages
- Intuitive navigation and feedback for users.

### 6. Error Handling & Validation
- Form inputs validated on the server side.
- Prevents duplicate usernames during registration.
- Handles missing or null fields with proper defaults and validation messages.

---

## Improvements Over Previous Version
- Fully functional **login system** with role-based access.
- **Persistent claim storage** in SQL database.
- Automatic **calculation of claim amounts**.
- Improved **user interface** and user experience.
- Integrated **file upload** for supporting documents.
- Complete **approval workflow** for coordinator and manager.
- Fully tested to ensure no runtime errors when submitting or approving claims.

---

## Technologies Used
- **Backend:** ASP.NET Core MVC, C#
- **Database:** SQL Server (SSMS)
- **Frontend:** Razor Views, Bootstrap (optional for styling)
- **Session Management:** ASP.NET Core Session for user authentication

---

## Database Schema
```sql
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

Add Claim Management
Commit message: Added Create, Read, Update, Delete (CRUD) functionality for claims

Implement File Uploads for Claims
Commit message: Implemented file upload feature for supporting documents

Add Role-Based Dashboards
Commit message: Created dashboards for Lecturer, Program Coordinator, and Academic Manager roles

Integrate MVC Views
Commit message: Designed views for claims, dashboards, and file uploads

Add Export Functionality
Commit message: Added export to database feature for claims and users