namespace RefactoringLab.Part02.Enrollment;

public class EnrollmentFacade
{
    private readonly PaymentGateway _paymentGateway = new PaymentGateway();
    private readonly SeatInventory _seatInventory = new SeatInventory();
    private readonly InvoiceGenerator _invoiceGenerator = new InvoiceGenerator();
    private readonly EmailService _emailService = new EmailService();

    public void Enroll(string studentId, string courseId, decimal amount)
    {
        _paymentGateway.Charge(studentId, amount);
        _seatInventory.Reserve(courseId, studentId);

        var invoiceId = _invoiceGenerator.Create(studentId, amount);

        _emailService.Send(studentId, "Enrollment confirmed", $"Invoice {invoiceId} for {courseId}");
    }
}
public class PaymentGateway
{
    public void Charge(string studentId, decimal amount) =>
        Console.WriteLine($"charge {studentId}: {amount}");
}

public class SeatInventory
{
    public void Reserve(string courseId, string studentId) =>
        Console.WriteLine($"reserve seat {courseId} for {studentId}");
}

public class InvoiceGenerator
{
    public string Create(string studentId, decimal amount)
    {
        var invoiceId = $"INV-{studentId}-{amount}";
        Console.WriteLine($"invoice {invoiceId}");
        return invoiceId;
    }
}

public class EmailService
{
    public void Send(string studentId, string subject, string body) =>
        Console.WriteLine($"email {studentId}: {subject} / {body}");
}
