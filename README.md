# 📝 Task Manager - WinForms App

Μια desktop εφαρμογή για διαχείριση εργασιών (tasks) με χρήση **WinForms**, **SQLite**, και **Clean Architecture**.

---

## 📌 Χαρακτηριστικά

✅ Login / Register με αποθήκευση χρηστών  
✅ Διαχείριση εργασιών ανά χρήστη  
✅ CRUD εργασιών με τίτλο, περιγραφή, κατηγορία, ημερομηνία λήξης  
✅ Υποστήριξη για "Ολοκληρωμένες" εργασίες (IsComplete checkbox)  
✅ Καθαρή Αρχιτεκτονική με διαχωρισμό Core και UI  
✅ Dependency Injection και EF Core  
✅ SQLite βάση δεδομένων (ενσωματωμένη, δεν απαιτεί setup)

---

## 🚀 Εκκίνηση

1. **Απαραίτητο:**  
   - Visual Studio 2022+  
   - .NET 6.0 SDK ή νεότερο  

2. **Clone το repo & build:**  
   ```bash
   git clone https://github.com/yourusername/TaskManager.WinForms.git
   cd TaskManager.WinForms

| Τεχνολογία              | Περιγραφή                     |
| ----------------------- | ----------------------------- |
| WinForms                | GUI εφαρμογή για Windows      |
| EF Core + SQLite        | ORM + embedded βάση δεδομένων |
| Microsoft.Extensions.\* | DI, Hosting, Configuration    |
| BCrypt.Net              | Hashing passwords             |
