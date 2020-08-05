# REST-API-eCommerce

At the start of the project the database will be seeded automaticaly, you don't have to make commands "add-migration" or "update-database". Just start the project.

The API used Swagger UI to generate interactive API documentation that lets users try out the API calls directly in the browser.

To make API calls to database you have to authenticate. You can do this from /api/v1/Users/authenticate. In the request body are filled correct username and password that exists in the database, you shoud only execute the request. Below in the response body appears a JWT token, which you will use to authorize in the upper right corner of the app. Before the JWT token you shoud write Bearer + JWT token. If the username and password are correct you can make calls to database, if not you don't have permissions, only "get all products" and "get product by id" allows anonymous.
