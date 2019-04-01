# Test Project by Yevhen Ushakov
This is the test task was written by Yevhen Ushakov.
In this task you can see n-layer architecture of Web.API.
You should use next urls:

| url | http verb | description |
| ------ | ------ | ------ |
| ~/auth/login | POST | return Bearer token |
| ~/products | GET | return list of products|
| ~/product/{id} | GET | return product by Id|
| ~/products | POST | create product|
| ~/products | PUT | update product|
| ~/product/{id} | DELETE | delete product|

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
	"login": "admin@admin.com",
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