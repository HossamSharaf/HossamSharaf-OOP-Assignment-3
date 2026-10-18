## Reports

What was the problem?
The main problem was severe Code Duplication, which violated the DRY (Don't Repeat Yourself) principle. The three exporter classes (CsvReportExporter, JsonReportExporter, and TextReportExporter) had identical implementations for the Export(), Load(), Validate(), and Save() methods. The only difference among them was the logic inside the Format() method.

What did you change?
I applied the Template Method Pattern. I created an AbstractReport base class that holds the common implementation for the invariant steps (Load, Validate, Save) and the main workflow template method (Export). I then marked the Format() method as protected abstract in the base class. Finally, I made each specific exporter class inherit from this base class and override only the Format() method to provide its own specific formatting logic.

Why did you choose that approach?
I chose this approach to centralize the shared logic into a single "template," making the code much more maintainable and readable. By putting the common code in an abstract class, I eliminated redundancy and enforced the DRY principle. Now, the overall export algorithm is defined in exactly one place, while each derived class remains focused only on its unique formatting responsibility. This also makes the codebase easier to understand and extend for any future developers.

## Enrollment

What was the problem?
The caller (Program.cs) was highly coupled to the complex subsystems. To enroll a single student, the caller had to manually instantiate four different classes (PaymentGateway, SeatInventory, InvoiceGenerator, EmailService) and coordinate their execution in a strictly specific order, along with passing intermediate data (like the invoice ID) between them.

What did you change?
I implemented the Facade Design Pattern. I created an EnrollmentFacade class that encapsulates the creation of these four services and handles the entire enrollment workflow internally. Now, the Program.cs only creates one object (EnrollmentFacade) and calls a single unified method: Enroll().

Why did you choose that approach?
I chose this approach to hide the complexity of the subsystems from the client and provide a simple, unified interface. This makes the caller's code much cleaner and easier to read. The caller no longer needs to know how the services are created, what order they run in, or how they interact with each other. It just makes one call to achieve the goal.