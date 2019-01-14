# SB
Small Business Application Test 

Development using em .Net ,C#, MVC 5, Owin auth, EF, Code First

Test description and requirements

Practical Test

The main goal of this test is provide an opportunity to the job applicant demonstrate
his/her knowledge, developing an application in the .NET platform. For this, will be provided a
database created following the requirements.
The job applicant is free to choose the way and the technologies used to develop the
requirements. The only rule is delivery a developed solution according to the requirements with
Asp.Net MVC framework or Asp.Net Web Forms framework.
The solution should be delivered by email within 48 hours from receive. You must use
Box.com (and send share link) to host your solution or GitHub. Along with the email with the
solution should be listed all technologies that the applicant would like to highlight in the
project.
1. Solution to be implemented
A small business of sales is looking for a system to manage the customer contact. The
system should show a login page every time a user try to access the site. In this page, the sellers
should be identified using the email account of the company and his/her password in the
system. After a successfully login, the sellers must see and search for some data and
classification (VIP, Regular and Sporadic) of his/her clients and plan his/her future sales with the
information. Currently, the company operates only in Porto Alegre, but in the future, there is an
expansion plan to other cities. For a better administration and system control, the company
would like a user with full access to contacts of all sellers.

2. Acceptance Criteria
2.1. Login Page (See Figure 1)
 The login page should be displayed whenever a user tries to access the system.


 If a user types a wrong e-mail and/or password, the system must show the message “The e-
mail and/or password entered is invalid. Please try again.” and the fields should be

displayed with a red border.
 When a user accesses the system successfully, the user should be redirected to page
“Customer List”.
Initial users

Role E-mail Password
Administrator admin@sellseverything.com admin123
Seller seller1@sellseverything.com seller1123
Seller seller2@sellseverything.com seller2123

2.2. Customer List Page (See Figure 2)
The system should have two roles: Seller and Administrator.
Seller
 The sellers should have access only to their clients. The clients are not shared
between the sellers.
 For the sellers, the grid shall display the following columns: Classification, Name,
Phone, Gender, City, Region and Last Purchase.
Administrator
 The administrator user should have total access to records of all customers in the
system.
 For the administrator, the grid shall display the following columns: Classification,
Name, Phone, Gender, City, Region, Last Purchase and Seller.
Filters
Name, Gender, City, Region (If the City field is selected, the region data must be filtered by
the selected city), Last Purchase, Classification, Seller (This field must be visible only to
administrator user).
