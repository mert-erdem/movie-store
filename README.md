# Movie Store

## Overview
The **Movie Store** is a full-featured CRUD application built using **ASP.NET Core 9**. It provides users with the ability to manage movies, actors, directors, and genres, as well as handle customer authentication and purchase processing. The application supports purchasing movies with secure authentication.

## Features
- **Actor Operations**: Add, edit, delete, and view actors.
- **Customer Operations**: Add customer.
- **Director Operations**: Add, edit, delete, and view directors.
- **Genre Operations**: Add, edit, delete, and view genres.
- **Movie Operations**: Add, edit, delete, and view movies.
- **Purchase Operations**: Add and view purchases (customer's only).
- **Customer Authentication**: Secure login and registration.
- **Custom Exception Middleware**: Centralized error handling for cleaner and consistent API responses.

## Technologies Used
- **ASP.NET Core 9** (Web API)
- **Entity Framework Core** (Database ORM)
- **Entity Framework Core InMemory** (Database)
- **AutoMapper** (Object-to-object mapping)
- **Fluent Validation** (Model validation)
- **JWT Authentication** (User authentication & authorization)
- **Newtonsoft.Json** (JSON parsing and serialization)
- **Postman** (Testing)


## API Endpoints
### Movie Endpoints
| Method | Endpoint           | Description          |
|--------|-------------------|----------------------|
| GET    | /api/movies       | Get all movies      |
| GET    | /api/movies/{id}  | Get movie by ID     |
| POST   | /api/movies       | Add a new movie     |
| PUT    | /api/movies/{id}  | Update a movie      |
| DELETE | /api/movies/{id}  | Delete a movie      |

### Actor Endpoints
| Method | Endpoint           | Description          |
|--------|-------------------|----------------------|
| GET    | /api/actors       | Get all actors      |
| GET    | /api/actors/{id}  | Get actor by ID     |
| POST   | /api/actors       | Add a new actor     |
| PUT    | /api/actors/{id}  | Update an actor     |
| DELETE | /api/actors/{id}  | Delete an actor     |

### Director Endpoints
| Method | Endpoint           | Description          |
|--------|-------------------|----------------------|
| GET    | /api/directors       | Get all directors      |
| GET    | /api/directors/{id}  | Get director by ID     |
| POST   | /api/directors       | Add a new director     |
| PUT    | /api/directors/{id}  | Update a director      |
| DELETE | /api/directors/{id}  | Delete a director      |

### Genre Endpoints
| Method | Endpoint           | Description          |
|--------|-------------------|----------------------|
| GET    | /api/genres       | Get all genres      |
| GET    | /api/genres/{id}  | Get genre by ID     |
| POST   | /api/genres       | Add a new genre     |
| PUT    | /api/genres/{id}  | Update a genre      |
| DELETE | /api/genres/{id}  | Delete a genre      |

### Customer Endpoints
| Method | Endpoint           | Description          |
|--------|-------------------|----------------------|
| POST   | /api/customers       | Add a new customer     |
| GET    | /api/customers/{id}  | Get customer by ID     |

### Purchase Endpoints
| Method | Endpoint            | Description                          |
|--------|---------------------|--------------------------------------|
| POST   | /api/purchases      | Place an purchase                    |
| GET    | /api/purchases/{id}  | Get purchases of the customer by ID     |
