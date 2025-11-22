
# **Contract Monthly Claim System**

*A simple MVC web application using EF Core for managing monthly lecturer claims.*



##  **Overview**

The **Contract Monthly Claim System** is an ASP.NET Core MVC web application designed to help lecturers submit their monthly claims and allow Programme Coordinators, Academic Managers, and HR Administrators to review, approve, or reject claims.

This system follows a **role-based workflow**:

1. **Lecturer** — Submits claim + uploads supporting documents
2. **Programme Coordinator** — Reviews and approves/rejects
3. **Academic Manager** — Reviews and approves/rejects
4. **HR** — Final approval + marks as Paid

The application uses **Entity Framework Core** for database access and **Bootstrap 5 + custom CSS** for styling.



##  **Technologies Used**

* **ASP.NET Core MVC**
* **Entity Framework Core**
* **C#**
* **MS SQL Server LocalDB**
* **Bootstrap 5**
* **Custom CSS Theme** (Purple–Aqua gradient)
* **Razor Views**




##  **User Roles & Permissions**

### **1️⃣ Lecturer**

* Login / Register
* Submit a claim
* Upload supporting documents
* Track status of submitted claims

### **2️⃣ Programme Coordinator**

* View all lecturer claims
* Approve or reject claims

### **3️⃣ Academic Manager**

* View claims approved by Coordinator
* Approve or reject

### **4️⃣ HR Admin**

* View claims approved by Manager
* Mark claim as **Paid**
* Finalize workflow



##  **Claim Workflow**


Lecturer → Programme Coordinator → Academic Manager → HR → Paid


Statuses automatically update:

* Pending
* Coordinator Approved
* Manager Approved
* Paid
* Rejected

---

## **Database Setup**

The project uses **EF Core Code-First Migrations**.

### Run the following commands:

```bash
Add-Migration InitialCreate
Update-Database
```

This will create:

* **Users** table
* **Claims** table
* **ClaimHistories** table

---

##  **How to Run the Project**

1. Open the project in **Visual Studio**
2. Ensure **SQL Server LocalDB** is installed
3. Update database:
   
   Update-Database
 
4. Press **F5** or **Run**



##  **Styling**

The system uses:

* Bootstrap 5
* Custom CSS theme
* Purple → Aqua gradients
* Buttons, cards, and tables styled for clarity and usability

---

## **Features Implemented**

✔ Lecturer claim submission
✔ EF Core database integration
✔ File upload
✔ View claim status
✔ Programme Coordinator review & approval
✔ Academic Manager approval
✔ HR final approval (Paid)
✔ Clean navigation based on roles
✔ Fully working MVC structure
✔ Student-friendly design

