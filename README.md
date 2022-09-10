# Osmo API Testing Exam

# Application requirement 
1. Visual Studio

# Packages used
1. NUnit.Framework
2. RestSharp
3. Newtonsoft

# How to use the project
1. Open Visual Studio and Click Clone a repository
2. Insert https://github.com/jvits/osmo-api-automation.git to repository location
3. Click Clone button
4. Click Test Menu > Run All Tests

# Classes
1. User : This class is basically for user management methods, that includes InsertUser, RetrieveUser, UpdateUser and DeleteUser.
2. ApiHelper : This helper class is for repetitive endpoints like get, post, put and delete.

# Available Endpoints
1. Method : POST  ( https://petstore.swagger.io/v2/user )
    Example Value: 
    {
      "id": 0,
      "username": "jojo",
      "firstName": "Jojo",
      "lastName": "Vito",
      "email": "jojo@yopmail.com",
      "password": "password",
      "phone", "099992141",
      "userStatus": 0
    }
    
    Model / Json Schema
    {
      "type" : "object",
      "properties": {
          "id": {"type": "int"},
          "username": {"type": "string"},
          "firstName": {"type": "string"},
          "lastName": {"type": "string"},
          "email": {"type": "string"},
          "password": {"type": "string"},
          "phone": {"type": "string"},
          "userStatus": {"type": "int"},
      }
    }
