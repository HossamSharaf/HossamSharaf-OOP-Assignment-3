namespace RefactoringLab;
public interface INotifier
{
    void Send(string to, string message);
}


public class EmailNotification : INotifier
{
    public  void Send(string to, string message) =>
        Console.WriteLine($"[email] {to}: {message}");
}

public class SmsNotification : INotifier
{
    public  void Send(string to, string message) =>
        Console.WriteLine($"[sms] {to}: {message}");
}
public class UrgentNotification :INotifier
{  
    private readonly INotifier _notifier;

    public UrgentNotification(INotifier notifier)
    {
        _notifier = notifier;
    }

    public void Send(string to, string message)
  => _notifier.Send(to, $"[URGENT] {message}");
}
public class ScheduledNotifier : INotifier
{
    private readonly INotifier _notifier;


    public DateTime SendAt { get; set; }
    public ScheduledNotifier(INotifier notifier,DateTime Send)
    {
        _notifier = notifier;
        SendAt = Send;
    }

    public void Send(string to ,string message)
  =>_notifier.Send($"[scheduled {SendAt:g}] {to}", message);
}
public class PushNotification : INotifier
{
    public void Send(string to, string message) =>
        Console.WriteLine($"[push] {to}: {message}");
}
