using RefactoringLab;

var calculator = new ShippingCostCalculator();
Console.WriteLine($"Aramex 2kg → {calculator.Calculate(new AramexCarrier(), 2)}");
Console.WriteLine($"FedEx 2kg  → {calculator.Calculate(new FedexCarrier(), 2)}");
Console.WriteLine();

var processor = new OrderProcessor(new SqlOrderRepository(), new SmtpEmailSender());
processor.Process(1001, "customer@example.com");
Console.WriteLine();

INotifier Email =new EmailNotification();
INotifier UrgentEmail=new UrgentNotification(Email);
INotifier ScheduledEmail=new ScheduledNotifier(UrgentEmail, DateTime.Today.AddHours(18));
ScheduledEmail.Send("customer@example.com", "Your order ships tomorrow");
INotifier Sms = new SmsNotification();
INotifier UrgentSms=new UrgentNotification(Sms);
UrgentSms.Send("+201000000000", "OTP 4821");

