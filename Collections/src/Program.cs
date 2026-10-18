namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Egyptian Phone Validation ===");

            TestPhone("01012345678", expected: true);
            TestPhone("+201512345678", expected: true);
            TestPhone("01312345678", expected: false); 
            TestPhone("0101234567", expected: false);  
            TestPhone("0101234567a", expected: false); 

            Console.WriteLine("\n=== Egyptian National ID Validation ===");

            TestId("29901011234567", expected: true);
            TestId("19901011234567", expected: false); 
            TestId("2990101123456", expected: false);  
        }

        static void TestPhone(string input, bool expected)
        {
            bool result = input.IsValidEgyptianPhone();

            string status = (result == expected) ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] \"{input}\" IsValidEgyptianPhone {result}");
        }

        static void TestId(string input, bool expected)
        {
            bool result = input.IsValidEgyptianNationalId();

            string status = (result == expected) ? "PASS" : "FAIL";
            Console.WriteLine($"[{status}] \"{input}\" IsValidEgyptianNationalId {result}");
        }
    }
    }

