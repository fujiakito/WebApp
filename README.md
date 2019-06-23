# WebApp

1. Entity Framework
2. Web API 2

# Requirements

1. Visual Studio
2. SQL Server
3. Postman

# Install

1. Download Zip.
2. Open your solution in Visual Studio 2017 or above and build the solution.
3. Check the connection string in the web.fig file of WebApp project, change it if you need to.
4. Open the Package Manager Console and Run ad `Update-Database` command to create your database. (ensure that the Package source is selected as nuget.org and Default project is selected as WebApp in the Package Manager Console window, restore missing packages if required)
5. Run the application. It will show Log in page if it is successful.
6. Register as a new user.

# Authentication

Let use Postman (a chrome extension) to demonstrate requests and responses.

1. Set a POST request to `/Token` with the Content-Type="application/x-www-form-urlencoded" header.
2. Add key value in body as below:
    grant_type - password
    username - registered user email
    password - registered user password
3. Send to obtain access_token.

# Retrieve Products

1. Set a GET request to `api/Products` with Content-Type="application/x-www-form-urlencoded" and Authorization=Bearer [access_token] header.

# Store Products

1. Set a POST request to `api/Products` with Content-Type="application/x-www-form-urlencoded" and Authorization=Bearer [access_token] header.
2. Select raw and JSON (application/json) in Body then paste the text below:

{
  "id": "12345678",
  "timestamp": "2019-06-23T10:15:43.7096308+08:00",
  "products": [
    {
      "id": 1,
      "name": "sample1",
      "quantity": 32,
      "saleAmount": 41.1
    },
    {
      "id": 1,
      "name": "sample2",
      "quantity": 23,
      "saleAmount": 54.1
    }
  ]
}

3. Get the result with the new id of products.
