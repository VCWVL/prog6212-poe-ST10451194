-- ============================================================
-- 1. Drop DATABASE if exists (force disconnect)
-- ============================================================
USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'MonthlyClaimsDB')
BEGIN
    ALTER DATABASE MonthlyClaimsDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MonthlyClaimsDB;
END
GO

-- ============================================================
-- 2. CREATE DATABASE
-- ============================================================
CREATE DATABASE MonthlyClaimsDB;
GO
USE MonthlyClaimsDB;
GO

-- ============================================================
-- 3. USERS TABLE
-- ============================================================
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Programme NVARCHAR(100) NULL
);
GO

-- ============================================================
-- 4. CLAIMS TABLE
-- ============================================================
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
GO

-- ============================================================
-- 5. CLAIM DOCUMENTS TABLE
-- ============================================================
CREATE TABLE ClaimDocuments (
    DocumentId INT IDENTITY(1,1) PRIMARY KEY,
    ClaimId INT NOT NULL,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    CONSTRAINT FK_ClaimDocuments_Claims FOREIGN KEY (ClaimId) REFERENCES Claims(ClaimId)
);
GO

-- ============================================================
-- 6. PAYMENT REPORTS TABLE
-- ============================================================
CREATE TABLE PaymentReports (
    ReportId INT IDENTITY(1,1) PRIMARY KEY,
    ClaimId INT NOT NULL,
    LecturerId INT NOT NULL,
    HoursWorked FLOAT NOT NULL,
    HourlyRate FLOAT NOT NULL,
    TotalAmount FLOAT NOT NULL,
    DateGenerated DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_PaymentReports_Claims FOREIGN KEY (ClaimId) REFERENCES Claims(ClaimId)
);
GO

-- ============================================================
-- Optional: Add some sample users
-- ============================================================
INSERT INTO Users (Username, Password, Role, Programme)
VALUES 
('lecturer1', 'password123', 'Lecturer', 'CS'),
('coordinator1', 'password123', 'ProgrammeCoordinator', 'CS'),
('manager1', 'password123', 'AcademicManager', NULL);
GO
