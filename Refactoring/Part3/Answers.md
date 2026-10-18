## BlockedUsersTime 
complexity before: $O(N \times M)$. The List<int>.Contains() method performs a linear search taking $O(N)$ time, and it was executed inside a loop that runs $M$ times (for each request).Time (ms) before: 26 ms   

 What did you change? 
 I converted the blockedIds List into a HashSet<int> before the foreach loop. A HashSet provides an $O(1)$ time complexity for lookup operations instead of $O(N)$.

 Time complexity after: $O(N + M)$. Creating the HashSet takes $O(N)$ time, and the loop 
 takes $O(M)$ time because the Contains check is now $O(1)$.

 Time (ms) after: 2 ms  

 ## Students
 
 What was the problem? 
 The code suffered from Eager Evaluation. It instantiated and allocated a List<Student> containing 1,000,000 objects in memory all at once, even though the caller (Program.cs) only needed to process and print the first 3 students. This caused massive unnecessary memory allocation and CPU overhead.
 
 What did you change?
  I changed the return type of GetAllStudents from List<Student> to IEnumerable<Student>, removed the list instantiation, and used the yield return keyword. This implemented Lazy Evaluation, allowing the method to generate and return students one by one and perfectly stop executing as soon as the caller received the 3 required students.