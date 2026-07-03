# Hospital Management System API

## Overview

The Hospital Management System is a secure RESTful Web API built with ASP.NET Core using Clean Architecture and the CQRS pattern with MediatR. The system is designed to digitize hospital operations by providing centralized management of patients, doctors, appointments, billing, pharmacy, laboratory services, medical records, notifications, and document management.

The project follows industry-standard software engineering practices, making it scalable, maintainable, secure, and suitable for real-world healthcare environments.

---

# Project Aim

To develop a secure, scalable, and maintainable Hospital Management System that streamlines hospital operations through centralized management of patients, healthcare professionals, appointments, medical records, billing, pharmacy, laboratory services, and administrative processes.

---

# Objectives

* Implement a Clean Architecture solution with clear separation of concerns.
* Apply the CQRS pattern using MediatR.
* Implement JWT-based authentication and role-based authorization.
* Manage patient registration and medical information.
* Manage doctors and healthcare staff.
* Schedule and manage appointments.
* Maintain comprehensive medical records.
* Upload and manage patient medical documents.
* Manage laboratory tests and results.
* Manage prescriptions and pharmacy inventory.
* Handle patient billing and payment records.
* Manage medicine inventory and stock levels.
* Generate dashboard statistics for administrators.
* Provide notification management for users.
* Implement global exception handling.
* Support Entity Framework Core migrations.
* Produce RESTful APIs suitable for frontend applications.

---

# Technologies Used

* ASP.NET Core
* .NET 10
* Entity Framework Core
* SQL Server
* MediatR
* JWT Authentication
* Swagger/OpenAPI
* Clean Architecture
* CQRS Pattern
* Repository Pattern
* Dependency Injection

---

# Completed Modules

## Authentication

* JWT Authentication
* Login
* Registration
* Role-based Authorization

## Patients

* Register Patient
* Update Patient
* Delete Patient
* Admit Patient
* Discharge Patient
* Billing Support

## Doctors

* Create Doctor
* Update Doctor
* Delete Doctor
* View Doctors

## Appointments

* Book Appointment
* View Appointment
* Complete Appointment
* Delete Appointment

## Medical Records

* Create Medical Record
* Update Medical Record
* Delete Medical Record
* Patient Medical History

## Medical Document Uploads

* Upload Medical Documents
* Retrieve Patient Documents
* Local File Storage

## Laboratory

* Request Lab Test
* Complete Lab Test
* Delete Lab Test

## Pharmacy

* Medicine Management
* Prescription Management

## Inventory

* Medicine Stock Tracking
* Low Stock Monitoring

## Billing

* Create Bills
* Payment Recording
* Outstanding Bills
* Paid Bills

## Notifications

* Create Notification
* Retrieve Notifications
* Mark Notification as Read
* Delete Notification

## Dashboard

* Total Patients
* Admitted Patients
* Doctors
* Appointments
* Pending Lab Tests
* Revenue
* Outstanding Bills
* Notifications
* Low Stock Medicines

---

# Architecture

The solution follows Clean Architecture:

* API Layer
* Application Layer
* Domain Layer
* Infrastructure Layer
* Shared Layer

Business logic is implemented using the CQRS pattern with MediatR.

---

# Security

* JWT Authentication
* Role-Based Authorization
* Protected API Endpoints
* Secure Password Hashing
* Global Exception Middleware

---

# Current Status

The project has reached a stable MVP (Minimum Viable Product). Core hospital operations are fully functional and ready for frontend integration and further enhancements.

---

# Upcoming Features

The following modules are planned for future development:

## Patient Portal

* View Medical History
* View Prescriptions
* View Bills
* Download Medical Documents

## Doctor Portal

* Personal Dashboard
* Assigned Patients
* Appointment Schedule

## Nurse Module

* Ward Management
* Patient Monitoring
* Nursing Notes

## Reception Module

* Walk-in Registration
* Queue Management
* Appointment Check-in

## Finance Module

* Financial Reports
* Revenue Analytics
* Payment Gateway Integration
* Invoice Generation

## Reporting Module

* Daily Reports
* Monthly Reports
* Yearly Reports
* PDF Export
* Excel Export

## Audit Logs

* User Activity Tracking
* Login History
* System Logs

## Email Notifications

* Appointment Reminders
* Prescription Notifications
* Billing Notifications

## SMS Notifications

* OTP Verification
* Appointment Alerts
* Payment Reminders

## File Storage

* Azure Blob Storage
* AWS S3 Integration
* Cloud File Management

## Analytics Dashboard

* Interactive Charts
* Revenue Graphs
* Patient Trends
* Doctor Performance

## Multi-Hospital Support

* Hospital Branch Management
* Multi-Tenant Architecture

## Docker Support

## CI/CD Pipeline

## Unit and Integration Testing

## Mobile API Support

## Real-time Notifications using SignalR

## Background Jobs using Hangfire

---

# Future Vision

The long-term vision is to evolve the system into a comprehensive Hospital Information Management Platform capable of supporting multiple hospitals, cloud deployment, mobile applications, advanced reporting, artificial intelligence integration, and interoperability with modern healthcare standards.
