# Online Store Project with Microservice Architecture

# Description:
This project is an online store that uses microservice architecture. It consists of several independent services that perform different tasks.

# Services:
Product Service: Manages product information.
Cart Service: Manages users' shopping carts.
Discount Service: Manages available discounts.
OrderService: Manages user orders.
API Service: Provides the final API to the frontend project and mobile application.
HealthCheck Service: Monitors the health of other projects.

# Technologies:
API Gateway: Ocelot
Storage:
Redis (Cart Service)
PostgreSQL (Discount Service)
EF Core (Product Service)
SQLExpress (API Service)
Authentication: JWT
Logging: Serilog

# Features:
High scalability
Easy development and maintenance
High availability
Monitoring and observability

# Use Cases:
Online stores
Online ordering systems
E-commerce websites
