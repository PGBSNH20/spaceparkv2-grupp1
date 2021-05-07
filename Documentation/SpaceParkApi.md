# Documentation

## SpacePark API
Our API runs by default against port 443 (https default)

### Parking Endpoint
| Endpoint              | Method | Description                                                                | Response codes                                                   |
|-----------------------|--------|----------------------------------------------------------------------------|------------------------------------------------------------------|
| api/parkings          | GET    | Returns all parkings and their respective spaceport                        | 200 (Success) 204 (No content)                                   |
| api/parkings/id       | GET    | Return the specified parking using unique id                               | 200 (Success) 404 (Not found)                                    |
| api/parkings?portname | GET    | Returns all parkings related to the portname  specified in the query field | 200 (Success) 404 (Not found)                                    |
| api/parkings          | POST   | Adds a parking to  the database                                            | 201 (Created) 400 (Bad request)                                  |
| api/parkings/id       | PUT    | Updates the specified parking                                              | 200 (Success) 204 (No content) 400 (Bad request) 404 (Not found) |
| api/parkings/id       | DELETE | Deletes the specified parking                                              | 200 (Success) 204 (No content) 404 (Not found)                   |

### Parking Schema
![image](https://user-images.githubusercontent.com/58253756/117141078-6bd57c80-adae-11eb-8269-1d251e85d1ef.png)

### Spaceport Endpoint
| Endpoint          | Method | Description                                          | Response codes                                                   |
|-------------------|--------|------------------------------------------------------|------------------------------------------------------------------|
| api/spaceports    | GET    | Returns all spaceports                               | 200 (Success) 204 (No content)                                   |
| api/spaceports/id | GET    | Return the specified parking using unique id         | 200 (Success) 404 (Not found)                                    |
| api/spaceports    | POST   | Adds a new space port                                | 200 (Success) 400 (Bad request)                                  |
| api/spaceports/id | PUT    | Updates the specified spaceport                      | 200 (Success) 204 (No content) 400 (Bad request) 404 (Not found) |
| api/spaceports/id | DELETE | Deletes the specified parking                        | 200 (Success) 204 (No content) 404 (Not found)                   |

### Spaceport Schema
![image](https://user-images.githubusercontent.com/58253756/117141052-62e4ab00-adae-11eb-9015-f3345cd40149.png)

### Spaceships Endpoint
| Endpoint                  | Method | Description                                                         | Response codes                            |
|---------------------------|--------|---------------------------------------------------------------------|-------------------------------------------|
| api/spaceships?personName | GET    | Returns a list of spaceships that belong to a person specified in the query field and are not yet parked       | 200 (Success) 204 (No content)            |


### Spaceship Schema
![Starship](https://user-images.githubusercontent.com/70198472/117455773-ca822e00-af47-11eb-810d-48c6df68f256.jpg)

### Payment Endpoint
| Endpoint                  | Method | Description                                                         | Response codes                            |
|---------------------------|--------|---------------------------------------------------------------------|-------------------------------------------|
| api/payments?personName   | GET    | Returns all payments made by a person specified in the query field  | 200 (Success) 204 (No content)            |
| api/payments              | POST   | Adds a new payment to the database                                  | 200 (Success) 400 (Bad request)           |

### Payment Schema
![Payment](https://user-images.githubusercontent.com/70198472/117456797-e508d700-af48-11eb-9f83-33e5fe3117f0.jpg)



