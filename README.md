# C# Sales & Invoice Management System

A desktop sales and invoice management system developed with C# Windows Forms and Microsoft Access.

## About

This project is a Windows Forms application for managing customers, products, inventory, and sales invoices. Users can select customers and products, check product availability, create invoices, calculate total amounts, and store invoice information in a database.

## Features

* User authentication
* Customer management and selection
* Product management
* Product search by code
* Display product price and stock
* Inventory availability validation
* Add multiple products to an invoice
* Calculate item totals
* Calculate the total invoice amount
* Automatic invoice number generation
* Invoice date registration
* Save invoices to the database
* Save invoice item details
* Remove products from the current invoice
* Data display using DataGridView

## Technologies

* C#
* Windows Forms
* .NET
* Microsoft Access (`.mdb`)
* DataSet
* TableAdapter
* DataGridView
* Visual Studio

## Database

The application uses a Microsoft Access database (`shop7.mdb`) to store information related to:

* Users
* Customers
* Goods
* Invoices
* Invoice items

## Application Workflow

1. User logs in through the authentication form.
2. A customer is selected.
3. Products are searched and selected by their codes.
4. Product information such as price and available stock is displayed.
5. The requested quantity is checked against the available stock.
6. Products are added to the invoice.
7. The total invoice amount is calculated.
8. The invoice and its items are saved to the database.

## How to Run

1. Clone or download the repository.
2. Open `p17.sln` in Visual Studio.
3. Make sure the `shop7.mdb` database file remains in the project directory.
4. Build the solution.
5. Run the application.
6. Log in with a valid user account.

## Project Purpose

This project was developed as a university project to practice C# Windows Forms development, database integration, authentication, customer and product management, inventory validation, and invoice processing.
