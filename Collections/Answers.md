## Dictionaries

What is each one?
IReadOnlyDictionary<TKey, TValue> is an interface representing a read-only collection of key/value pairs. SortedDictionary<TKey, TValue> is a class representing a collection of key/value pairs that are automatically sorted by the key.

How is IReadOnlyDictionary different from Dictionary, and why would a public method return one instead of a Dictionary?
Unlike a standard Dictionary which allows adding, removing, and modifying elements, IReadOnlyDictionary only allows reading and traversing the data (e.g., reading values or using Contains).

A public method returns an IReadOnlyDictionary to strictly enforce Encapsulation. It allows the caller to view important internal data without giving them the ability to accidentally or intentionally alter, clear, or corrupt the original state of that data.

How is SortedDictionary different from Dictionary in ordering and in lookup speed?
Ordering:
 A standard Dictionary is unordered. A SortedDictionary automatically maintains the elements in a sorted order based on the keys (e.g., alphabetically).

Lookup Speed:
 A standard Dictionary uses a Hash Table, providing a blazing-fast lookup speed of $O(1)$. A SortedDictionary uses a Binary Search Tree (Red-Black Tree), making its lookup speed slightly slower at $O(\log N)$.

 When would you choose it?
 I would choose a SortedDictionary when the application strictly requires the dictionary elements to always remain sorted by their keys for display or processing purposes. Using it prevents the CPU overhead of repeatedly applying manual sorting (like .OrderBy()) on a standard Dictionary every time the data needs to be accessed in order.

 ## Collections / Scenarios
 S1: Find a student by national ID — thousands of times a day.

 Collection: Dictionary

 Why: It provides $O(1)$ lookup time, making it incredibly fast and efficient for repeatedly searching by a unique key (national ID).

 S2: Keep the tags of a course. The same tag must never be stored twice.

 Collection: HashSet

 Why: It automatically prevents duplicate entries and provides $O(1)$ performance for insertions and lookups.

 S3: Keep a student's grades in the order they were entered. The same grade can appear more than once.

Collection: List

Why: It preserves the exact insertion order of the items and inherently allows duplicate values to be stored.

S4: A public method returns the course price list. Callers can read prices but must not add or change any.

Collection: IReadOnlyDictionary

Why: It strictly enforces encapsulation by allowing callers to read values by key while preventing them from modifying or adding any data.

S5: A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.

Collection: SortedDictionary

Why: It automatically maintains its elements in a sorted order based on the key (start time) every time a new session is inserted.

S6: A method returns results that the caller only loops over once — and may stop early.

Collection: IEnumerable

Why: It utilizes lazy evaluation, meaning it only generates items as needed and prevents unnecessary memory allocation if the caller decides to stop early (yield break).