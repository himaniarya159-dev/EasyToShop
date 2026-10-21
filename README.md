# EasyToShop - ASP.NET Core MVC E-Commerce Application

EasyToShop is a functional, secure e-commerce web application built with ASP.NET Core MVC, Entity Framework Core, SQLite, and ASP.NET Core Identity.

---

## 🚀 Features

* **Product Catalog:** View products with image rendering and stock details.
* **Shopping Cart & Checkout:** Persistent session-based cart, stock auto-deduction, and secure order processing.
* **Architecture & DTOs:** Uses Data Transfer Objects (`CreateOrderDto`, `OrderSummaryDto`) to prevent over-posting and isolate UI from database entities.
* **Authentication & Authorization:** Integrated ASP.NET Core Identity for user accounts and administrative controls.
* **Admin Management:** Product creation interface supporting image file uploads via `multipart/form-data` (`IFormFile`).
* **Transparency Policies:** Integrated 14-day return/refund policy and comprehensive privacy policy views.

---

## 🛠️ Tech Stack & Architecture

* **Framework:** ASP.NET Core 8.0 MVC
* **Database:** SQLite with Entity Framework Core (Code-First Migrations)
* **Authentication:** ASP.NET Core Identity
* **Frontend:** Razor Views, HTML5, CSS3, Bootstrap 5
* **Design Pattern:** Model-View-Controller (MVC) + DTO Data Transfer Layer

---

## ⚙️ Getting Started

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
* Visual Studio Code or Visual Studio

### Local Setup Instructions

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/himaniarya159-dev/EasyToShop.git](https://github.com/himaniarya159-dev/EasyToShop.git)
   cd EasyToShop