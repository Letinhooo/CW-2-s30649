namespace AplikacjaKontenerowa;

public class OverfillException : Exception
{
    public OverfillException() : base("Nie pomiesci wiecej") { }

    public OverfillException(string message) : base(message) { }

    public OverfillException(string message, Exception innerException) : base(message, innerException) { }
}