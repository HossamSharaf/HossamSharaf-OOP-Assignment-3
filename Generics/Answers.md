## StudentStore vs. CourseStore

What is the same?
The internal logic, the underlying data structure (List<T>), and the method signatures (Add, GetById, GetAll, Remove) are completely identical. Both classes perform the exact same CRUD (Create, Read, Update, Delete) operations.

What is different?
The only difference is the Data Type being operated on (Student in one class, and Course in the other). This heavy code duplication strongly indicates the need for a Generic Repository pattern (e.g., Store<T>) to unify the logic.

## Generic Store Error

Compiler Error:
CS1061: 'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found.

Explanation:
The C# compiler is strictly type-safe. By declaring Store<T>, we are telling the compiler that T can be absolutely any data type (for example, a string, a DateTime, or an int). Since the compiler does not know what T will be, it cannot guarantee that T will have a property named Id. To prevent the program from crashing at runtime, the compiler plays it safe and rejects the code. It demands a guarantee (a generic constraint) that T will always have an Id.
## Step 7 & General Architecture

Why new Store<int>() must NOT compile:
The compiler clearly rejects new Store<int>() because the generic Store<T> class has a strict constraint: where T : IHasId. The built-in int structure does not implement our custom IHasId interface. This is a massive advantage because it guarantees Type Safety at compile-time, ensuring our store can never accidentally be created for invalid types that lack an Id property.

What is the common name for the kind of class built in Steps 4 and 5?
The standard architectural name for this generic data-access class is the Repository Pattern (specifically, a Generic Repository). It acts as an in-memory, collection-like interface that encapsulates and hides the underlying storage logic (the Dictionary) from the rest of the business logic.