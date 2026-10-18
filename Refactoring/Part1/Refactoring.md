## ShippingCostCalculator

What was the problem?
The ShippingCostCalculator class violated the Open/Closed Principle (OCP). It used a large switch statement to handle the calculation logic for all carriers. If a new carrier needed to be added, I would have to modify the existing class, which increases the risk of breaking existing code and makes maintenance difficult.

What did you change?
I refactored the code using the Strategy Design Pattern. I extracted the calculation logic for each carrier into its own separate class, where all carriers implement a common interface (ICalculator). Then, I modified the ShippingCostCalculator to accept this interface as a parameter, allowing it to delegate the calculation to the specific carrier's class. Now, adding a new carrier only requires creating a new class, without modifying the existing code.
 
## OrderProcessor

What was the problem?
The OrderProcessor class suffered from Tight Coupling because it directly instantiated its dependencies using the new keyword (new SqlOrderRepository() and new SmtpEmailSender()). This violated the Dependency Inversion Principle (DIP). It made the class inflexible, hard to test in isolation, and forced modifications to the OrderProcessor itself if we wanted to change the database or the email delivery method.

What did you change?
I implemented Dependency Injection (DI) through the constructor. I created separate interfaces for the required operations (IOrderRepository for saving and IEmailSender for sending). Then, I made the specific classes implement these interfaces. Finally, I updated the OrderProcessor to depend on these abstractions (interfaces) rather than concrete implementations, receiving them via its constructor. Now, the OrderProcessor is decoupled from the specific details of how data is saved or sent.

## Notifications

What was the problem?
The Notification system suffered from a severe Class Explosion issue due to an overuse of Inheritance. For every new combination of notification type (e.g., Urgent, Scheduled) and channel (e.g., Email, SMS), a new class had to be created (like UrgentScheduledEmailNotification). This violated the Composition over Inheritance principle, making the system rigid, hard to maintain, and difficult to scale with new channels or types.

What did you change?
I refactored the design using the Decorator Pattern, favoring Composition over Inheritance. I unified all components under a single INotifier interface. I separated the delivery channels (EmailNotification, SmsNotification) from the message modifiers/decorators (UrgentNotification, ScheduledNotifier). Now, decorators wrap any INotifier via constructor injection (Composition), adding their specific behavior (like adding "[URGENT]") and then delegating the actual sending to the wrapped channel. This eliminated the need for combination classes, significantly reduced the total number of classes, and made it easy to add new channels or modifiers without altering existing code.

## Proof

New carrier file(s): UpsCarrier.cs (or added UpsCarrier class implementing ICalculator).

New notification channel file(s): PushNotification.cs (or added PushNotification class implementing INotifier).

Existing classes left unchanged? (yes/no): Yes.
