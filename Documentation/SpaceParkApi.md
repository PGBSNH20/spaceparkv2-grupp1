# Documentation

## SpacePark API

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
![image](https://user-images.githubusercontent.com/58253756/116851473-b0b4b400-abf2-11eb-8bc4-d03eec248877.png)
