using System;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    private static readonly Regex Digits = new Regex(@"[^\d]");

    public string Number { get; }

    public string AreaCode { get; }

    public PhoneNumber(string phoneNumber)
    {
        Number = ParsePhoneNumber(phoneNumber);
        AreaCode = Number.Substring(0, 3);
    }

    public override string ToString() => 
        $"({AreaCode}) {Number.Substring(3, 3)}-{Number.Substring(6)}";

    private static string ParsePhoneNumber(string phoneNumber)
    {
        phoneNumber = Digits.Replace(phoneNumber, "");

        if (phoneNumber.Length != 10)
            return IsUSPhoneNumber(phoneNumber) ? phoneNumber.Substring(1) : "0000000000";

        return phoneNumber;
    }

    private static bool IsUSPhoneNumber(string phoneNumber) =>
        phoneNumber.Length == 11 && phoneNumber.StartsWith("1");
}