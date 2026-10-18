## StudentStore vs. CourseStore

What is the same?
The internal logic, the underlying data structure (List<T>), and the method signatures (Add, GetById, GetAll, Remove) are completely identical. Both classes perform the exact same CRUD (Create, Read, Update, Delete) operations.

What is different?
The only difference is the Data Type being operated on (Student in one class, and Course in the other). This heavy code duplication strongly indicates the need for a Generic Repository pattern (e.g., Store<T>) to unify the logic.