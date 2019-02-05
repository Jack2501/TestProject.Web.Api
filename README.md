# Test Project for Zeux by Yevhen Ushakov
This is the test task was written by Yevhen Ushakov for Zeux.
In this task you can see n-layer architecture of Web.API.
You should use next urls:

| url | http verb | description |
| ------ | ------ | ------ |
| ~/auth/login | POST | return Bearer token |
| ~/product | GET | return list of products|

# Prerequisites
You must have an ASP.NET Core 2.2. SDK installed.

# Installation
The solution must be installed without any additional setup. Just to press F5 in Visual Studio 2017 to run the application.

# How to use
Firstly, you should get Bearer token for authentification. For this, you should create a POST request with JSON parameters: 
```sh
POST /auth/login HTTP/1.1
Host: localhost:44338
Content-Type: application/json
cache-control: no-cache
Postman-Token: 8014f083-3b81-4d00-931e-da5fba733d7d
{
	"login": "admin@admin1.com",
	"password": "P@ssword123"
}------WebKitFormBoundary7MA4YWxkTrZu0gW--
```

Bearer token will be in a responce.
You have to use this token for authentification.
Using this token, you can get list of products.
```sh
GET /product HTTP/1.1
Host: localhost:44338
Content-Type: application/json
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0ZDI2ZjU2Yy05YTI4LWU5MTEtYTgzMC01NGVlNzViNDZiYmEiLCJqdGkiOiJmNThhNmFlOC04M2ExLTRkYmUtYjhhZS03OTJlMWY0NTQyNDIiLCJleHAiOjE1NTE5MDA3MTksImlzcyI6InlldmhlbnVzaGFrb3YuY29tIn0.Pfzg1wWgLG7shUFCOzg43PcPt6FvZIggfUHFXFinoY0
cache-control: no-cache
```

# Example of the responce

```sh
{
    "model": [
        {
            "name": "name1",
            "productType": 1,
            "price": 10,
            "returns": 0.1
        },
        {
            "name": "name2",
            "productType": 2,
            "price": 20,
            "returns": 0.2
        },
        {
            "name": "name3",
            "productType": 3,
            "price": 30,
            "returns": 0.3
        },
        {
            "name": "name4",
            "productType": 4,
            "price": 40,
            "returns": 0.4
        },
        {
            "name": "name5",
            "productType": 5,
            "price": 50,
            "returns": 0.5
        },
        {
            "name": "name6",
            "productType": 6,
            "price": 60,
            "returns": 0.6
        },
        {
            "name": "name7",
            "productType": 7,
            "price": 70,
            "returns": 0.7
        },
        {
            "name": "name8",
            "productType": 8,
            "price": 80,
            "returns": 0.8
        },
        {
            "name": "name9",
            "productType": 9,
            "price": 90,
            "returns": 0.9
        },
        {
            "name": "name10",
            "productType": 10,
            "price": 1000,
            "returns": 0.95
        }
    ],
    "status": 1,
    "description": "Success",
    "timestamp": 1549354364
}
```