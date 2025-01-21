# Machines Application (MVVM)

This application represents a list of machine statuses with full CRUD (Create, Read, Update, Delete) operations, implemented using the MVVM architecture.

---

## Features Overview

### Adding a New Machine Status

1. **Click the Add Button**  
   ![Add Button](https://github.com/user-attachments/assets/23d4c558-686b-4fff-abe6-062e356e743c)

2. **A Popup Will Appear**  
   ![Popup](https://github.com/user-attachments/assets/fd4239b0-720e-4ee4-b787-8746a353694d)

3. **Select the Machine Name from the Database**  
   The machine names are loaded from a JSON database file.  
   ![Select Machine Name](https://github.com/user-attachments/assets/e1c4cda6-9ff8-4505-8ef9-8a093ce5fc85)

4. **Save the New Status**  
   The database file can be found here:  
   `WpfApp1\Machines\WpfApp1\bin\Debug\net8.0-windows\DataBase`

5. **The New Status Will Be Available Immediately**  
   ![New Status](https://github.com/user-attachments/assets/803e9052-9307-4fad-9767-a866ec199d72)

---

### Editing a Machine Status

- Simply click the **Edit** button to reopen the popup and make changes.

---

### Filtering Machine Statuses

- Use the dropdown ComboBox to filter the machine statuses by predefined criteria.  
  ![ComboBox Filtering](https://github.com/user-attachments/assets/70cdac3e-e708-459b-b6e3-4615e3fe607b)

- Only the selected machine statuses will be visible for you.
  ![Filtered Statuses](https://github.com/user-attachments/assets/e9ca45b5-9274-49ab-a577-8494d3035051)

---

## Architecture

### MVVM Design Pattern
- The project is built using the Model-View-ViewModel (MVVM) pattern to separate concerns and ensure testability.

### Dependency Injection
- Services, ViewModels, and Models are registered via Dependency Injection for decoupled and reusable components.

### Factory Design Pattern
- The Factory Pattern is used for dynamically instantiating ViewModels, enabling better decoupling and testability.
