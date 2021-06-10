# Convention

The best application for conventions

## C4 Core diagrams

### System Context diagram:
![context-diagram](https://raw.githubusercontent.com/skalovigor/Convention/feature/doc/docs/System%20diagrams-C4%20Context.jpg)


### Container diagram:
![conteiner-diagram](https://raw.githubusercontent.com/skalovigor/Convention/feature/doc/docs/System%20diagrams-C4%20Container.jpg)


### Component diagram API:
![conteiner-diagram](https://raw.githubusercontent.com/skalovigor/Convention/feature/doc/docs/System%20diagrams-C4%20Component%20API.jpg)


### Component diagram Worker:
![conteiner-diagram](https://raw.githubusercontent.com/skalovigor/Convention/feature/doc/docs/System%20diagrams-C4%20Component%20Worker.jpg)


## Whats Including In This Repository
#### Frontend application
* React js single-page application

#### API project; 
* .NET 5 Web API application 
* REST API principles, CRUD operations
* Repository and Unit of work Pattern Implementation
* Swagger Open API implementation

#### API Gateway Ocelot
* Implement **API Gateways with Ocelot**
* Sample microservices/containers to reroute through the API Gateways

#### Seq container
* Use seql for logging

#### Docker Compose establishment with all services on docker;
* Container for API
* Container for Database
* Container for seq (Logging service)
* Container for API gateway
* Container for Frontend application


## Run The Project
You will need the following tools:

* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. Once Docker for Windows is installed, go to the **Settings > Advanced option**, from the Docker icon in the system tray, to configure the minimum amount of memory and CPU like so:
* **Memory: 4 GB**
* CPU: 2
3. At the root directory which include **docker-compose.yml** files, run below command:
```csharp
docker --project-name convention-system up -d
```
3. Wait for docker compose all components. That’s it!

4. You can **launch services** as below urls:
* **Frontend -> http://localhost:3000/**
* **API -> http://localhost:8000/swagger**
* **Ocelot -> http://localhost:8010/swagger**
* **SEQ -> http://localhost:5341/#/events**
* **MSSQL -> localhost, 1433**


## Authors

* **Ihor Skalov**