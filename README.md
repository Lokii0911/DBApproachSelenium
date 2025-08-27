# DBAproachSelenium  
This repository contains Selenium automation framework built with **C#** and **NUnit**, using a **Database-driven testing (DDT)** approach.  

## Project Structure

DBApproachSelenium  
├── **DDT/**  
│   ├── `DBHelper.cs` → Handles DB operations  
│   └── `DBreader.cs` → Reads test data from DB  
│  
├── **Reporting/**  
│   └── `Reporting.cs` → Extent report integration  
│  
├── **Setup/**  
│   ├── `Base.cs` → Base setup for WebDriver  
│   └── `Basefunction.cs` → Common reusable functions  
│  
├── **Testcall/**  
│   └── `Test.cs` → Test runner entry  
│  
└── **TestCase/**  
    ├── `AddAdmin.cs`  
    ├── `AddEmployee.cs`  
    ├── `DeleteAdminVerification.cs`  
    ├── `DeleteEmpverification.cs`  
    └── `Login.cs`  

 
# About
DBApproachSelenium is a Database-driven Selenium Test Automation Framework built with C# and NUnit.
The framework is designed to fetch test data directly from the database instead of hardcoding it, ensuring better scalability and maintainability of test cases.
Key Highlights:
1.Database Driven Testing (DDT): Uses DBHelper.cs and DBreader.cs to connect and fetch test data.

2.Modular Setup:

Setup/ → Contains base classes (Base.cs, Basefunction.cs) to initialize WebDriver and common utilities.
Reporting/ → Handles test reporting with Reporting.cs.
Testcase/ → Includes individual test case files (e.g., AddAdmin.cs, AddEmployee.cs, Login.cs, etc.).
Testcall/ → Manages execution entry points (Test.cs).

3.Scalable Test Management: Each test case is independent and retrieves data dynamically.

4.Reporting Integration: Generates structured execution reports.

# Usecases
This project is ideal for teams who want to:

Run automated tests with real-time DB-driven data.

Maintain test cases in a modular way.

Generate clear execution reports.
