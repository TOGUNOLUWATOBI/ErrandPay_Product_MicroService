ErrandPay_Product_MicroService


This microservice is to help in the creation of products in a company.

The AuthenticationController has endpoints that help in the creation of different users(superAdmin,Staff and user) and also to login to generate Jwt token that will be used for authorization and authentication.

The ProductController is where authorization and authentication is performed. all endpoints are accessible by the superAdmin, 2 by a user with staff role and one by a user with user role.
Each enpoint returns the name of the user/customer and their role.

The service layer is where all business logic is performed.
Core for where actions or properties needed by each project is stored
Model project to store models, entities and DTOs used in the project.
