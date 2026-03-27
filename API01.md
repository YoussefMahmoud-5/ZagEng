1. What are the fundamental differences between the original ASP.NET and ASP.NET Core?

ASP.NET was built to run only on Windows, and it was tightly coupled to IIS and the System.Web assembly, which made it heavy and less flexible.
ASP.NET Core, on the other hand, is a complete redesign — it's cross-platform (Windows, Linux, macOS), open-source, modular, and much faster. You're not locked into IIS anymore, and you only include what you actually need.

--------------

2. What does it mean for an API to be "Stateless"?

It means every request the client sends must contain all the information the server needs to handle it. The server doesn't remember anything from previous requests — each one is treated as completely new and independent.

-------------

3. Break down the anatomy of an HTTP Request URL?

https://api.example.com:201/Category/4?sort=asc

https        → Scheme (the protocol being used)
api.example.com → Host/Domain (where the server lives)
:201         → Port
/Category/4  → Path (the resource being accessed)
?sort=asc    → Query String (optional parameters)

------------------

4. What are the primary HTTP Methods (Verbs) and their standard uses?

GET    → Retrieve/read data
POST   → Create a new resource
PUT    → Update an existing resource
DELETE → Remove a resource

-----------------

5. What is the role of Program.cs in an ASP.NET Core application?

It's the entry point of the application. It does exactly two things:
first, it registers all the services the app needs into the DI container,
and second, it sets up the middleware pipeline that handles incoming requests.

-----------------

6. Why is Swagger/OpenAPI typically enabled only in the "Development" environment?

Because Swagger exposes your full API — every endpoint, model, and parameter — which is exactly the kind of information you don't want publicly visible in production.
It's a great tool for developers while building and testing, but it becomes a security risk if left on in a live environment.

-----------------

7. What is the core concept of "Dependency Injection" (DI)?

Normally, a class would create its own dependencies using new. DI flips that around — instead of the class building what it needs, those dependencies are provided from the outside (injected into it).
The class just says "I need this," and the DI container takes care of creating and supplying it.

----------------

8. Explain the three Service Lifetimes in ASP.NET Core DI?

Transient  → A new instance is created every time the service is requested
Scoped     → One instance per HTTP request (shared within the same request)
Singleton  → One instance for the entire lifetime of the application

---------------

9. Why is it a "Best Practice" to register services against an Interface rather than a concrete Class?

Because it keeps things flexible. If you code against an interface, you can swap out the underlying implementation any time without touching the classes that depend on it. It also makes unit testing much easier since you can inject a mock or fake implementation.

----------------

10. What are the "Launch Profiles" found in launchSettings.json?

They define different ways to run the app locally during development — for example, whether to launch with IIS Express or Kestrel, which environment to use (Development/Production), and which URL to open on startup.

-----------------

11. How does JSON facilitate data exchange in APIs?

JSON became the go-to format for APIs because it's lightweight and easy to read for both humans and machines. In ASP.NET Core, this is handled automatically — C# objects get serialized into JSON when sending responses, and incoming JSON gets deserialized back into C# objects.

================================================================================

Question 1 - What is a Dependency?

The OrderService creates three objects directly inside the method using new:
SqlConnection, EmailSender, and FileLogger.

The problem here is tight coupling — these implementations are hardcoded. You can't swap them or change behavior without going in and modifying the class directly.

----------------------------------

Question 2 - Tight Coupling Problem

What's the difference between A and B? Which one is better?

Scenario A: UserService creates EmailService itself with new EmailService(). The implementation is locked in — you can never swap it for a different email provider without changing the class.

Scenario B: UserService depends on IEmailService (an interface), and the actual implementation gets injected through the constructor. Any class that implements IEmailService can be passed in.

Scenario B is the better approach — it's flexible, testable, and follows good design principles.

----------------------------

Question 3 - Constructor Injection

What happens when a request is received?

When the POST request comes in, the DI container works through the dependency chain:

1. It sees ProductController is needed
2. ProductController needs ProductService → creates a new ProductService (Scoped)
3. ProductService needs IRepository → creates a new SqlRepository (Scoped)
4. SqlRepository gets injected into ProductService, which then gets injected into ProductController
5. AddProduct() is called → which calls _repository.Save(product) → prints "Saving to SQL Database"

--------------------------

Question 4 - DI Container Registration

What is the output for each registration?

Registration A → False
Registration B → True
Registration C → True

----------------

Question 5 - Multiple Registrations

Which implementation will Controller A receive?
Controller A receives MailgunEmailService — when there are multiple registrations for the same interface, the last one registered wins.

How many services will be injected into Controller B?
Controller B receives all 3 implementations (it uses IEnumerable<IEmailService>, so the container injects the full list).
