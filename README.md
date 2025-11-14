
# 🎓 Student Registration System

An ASP.NET MVC 5 web application for managing student registration using CRUD operations with SQL Server.

## 💡 Features
- Add, Edit, Delete student records
- SQL Server database integration
- Client-side validation using jQuery
- Responsive Bootstrap UI

## 🛠 Tech Stack
- ASP.NET MVC 5 (C#)
- SQL Server
- HTML, CSS, JavaScript, jQuery, Bootstrap

## 💾 Database
**Database Name:** Student  
**Table Name:** StudentReg

```sql
CREATE TABLE StudentReg (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    MobileNo VARCHAR(15),
    Gender NVARCHAR(10),
    PanNo VARCHAR(20),
    AadharNo VARCHAR(20),
    PassportNo VARCHAR(20),
    VoterId VARCHAR(20),
    DrivingNo VARCHAR(20)
);
