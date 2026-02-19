# 🤖 IntelliMonitor

> 🚧 **This project is actively under development. Still working on this.** 🚧  

IntelliMonitor is an AI-powered website and dashboard monitoring platform that automatically captures screenshots of web pages (including SAP Analytics Cloud dashboards) and sends them via email on a scheduled basis.

This project demonstrates full-stack automation, background job orchestration, headless browser automation, and enterprise report distribution.

---

## 🚀 Features (Current)

- ✅ ASP.NET Core Web API backend
- ✅ React + TypeScript frontend
- ✅ SQLite database (EF Core)
- ✅ Hangfire background job scheduling
- ✅ Playwright headless browser automation
- ✅ Screenshot capture of public & authenticated pages
- ✅ SAP Analytics Cloud (SAC) dashboard automation
- ✅ Session persistence using Playwright storage state
- ✅ Email delivery via MailKit (SMTP)
- ✅ Configurable monitoring via UI

---

## 🏗 Architecture Overview

Frontend (React)
⬇  
ASP.NET Core Web API  
⬇  
SQLite Database (WebsiteMonitors)  
⬇  
Hangfire Background Jobs  
⬇  
Playwright Headless Browser  
⬇  
Screenshot Capture  
⬇  
MailKit SMTP  
⬇  
Email Delivery  

---

## 🔐 SAP Analytics Cloud (SAC) Support

IntelliMonitor supports automated screenshot capture of authenticated SAC stories using:

- Playwright browser session persistence
- Saved authentication state (`sacAuth.json`)
- Headless browser execution
- Scheduled report distribution via email

---

## 🧠 Tech Stack

### Backend
- ASP.NET Core (.NET 10)
- Entity Framework Core
- SQLite
- Hangfire
- Microsoft Playwright
- MailKit

### Frontend
- React
- TypeScript
- Fetch API

---

## ⚙️ How It Works

1. User creates a monitor via UI.
2. Monitor is stored in SQLite.
3. Hangfire schedules a background job.
4. Playwright launches a headless browser.
5. Website or SAC story loads.
6. Screenshot is captured.
7. Email with attachment is sent automatically.

---

## 📦 Setup Instructions
### Frontend 
npm install
npm start

### Backend

```bash
dotnet restore
dotnet run
