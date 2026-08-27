# API Automation Project

Automated API testing based on the web app checklist, developed during my manual QA internship. Since the original backend was unavailable, Swagger Petstore was used as a functional environment.

**Project Structure:**
* **`Services/`:** Encapsulates HTTP request logic (GET, POST, PUT, DELETE). Acts as a service layer to decouple the API client from the tests.
* **`Models/`:** DTO classes for `Book` and `Pet` entities, ensuring type-safe JSON serialization.
* **`Fixture/`:** Manages the test lifecycle, environment configuration, and shared API client state.
* **`Data/`:** Centralized storage for test data objects used in `MemberData` driven scenarios.
* **Configuration (appsettings.json):** Centralized management of BaseUrl and Auth Tokens (Admin/Invalid) for environment-based testing.
* **`Tests/`:** Functional test suites following the **Arrange, Act, Assert** pattern.

**Test Strategy:**
* **CRUD:** Verification of the complete entity lifecycle.
* **Data-Driven Testing:** Using [MemberData] to verify API stability across various input data sets.
* **Contract Validation:** Using DTO models to control JSON response structures (ensures tests fail if data types or field names change).
* **Negative Testing:** Security and error handling verification using invalid tokens and malformed requests.
* **Test Isolation:** Ensuring test independence and resource management using IClassFixture. 
 
**Technology Stack:**
* **Language:** C# (.NET 9)
* **Framework:** xUnit
* **Assertions:** Shouldly