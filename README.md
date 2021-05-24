# CountryFileDb
Solution following **DDD methodology** to build a json file as repository for countries.
This is the cleaniest and most complete architecture i would consider for a simple problem like this one. These are the patterns I have aplied apart from following DDD coding:
- **Specification**: Centralizes the knowledge of domain criteria.
- **Mediator**: Decouple web layer and application, so no references are needed to use application services from web controller for instance
- **CQRS (Command Query Responsibility Segregation)**: Split the domain actions in updates and display. Take in consideration that this is not the case for a right use of CQRS due to its complexity.
- **Repository**: A Repository mediates between the domain and data mapping layers, acting like an in-memory domain object collection.
- **Agregate**: Cluster of domain objects that can be treated as a single unit.
