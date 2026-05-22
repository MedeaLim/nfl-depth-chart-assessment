# Scalability

## Adding More Sports

The current design stores positions dynamically, so it can support additional sports such as:

- NBA
- MLB
- NHL

without major changes to the core logic.

---

## Adding Multiple NFL Teams

The current implementation manages one team.

To support multiple teams, a Team entity could be added so each team maintains its own depth chart.

---

# Testing

## Manual Testing

The application was manually tested using:

- Swagger
- Frontend demo UI

Main scenarios tested:

- Adding players
- Removing players
- Retrieving backups
- Testing multiple positions
- Invalid requests

---

## Automated Testing

The project includes xUnit automated tests for the service layer.

Tests cover:

- Add player logic
- Player shifting after insertion/removal
- Backup retrieval
- Duplicate prevention
- Edge cases

---

# Code Organization

The project uses a simple layered structure:

- Controllers handle HTTP requests
- Services contain business logic
- DTOs handle request models
- Tests validate functionality

The architecture intentionally keeps the solution simple, readable, and maintainable for the scope of the coding challenge.