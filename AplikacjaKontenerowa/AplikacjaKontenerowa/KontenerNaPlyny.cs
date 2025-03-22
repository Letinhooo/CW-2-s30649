namespace AplikacjaKontenerowa;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public bool IsSafe { get; }

    public KontenerNaPlyny(double wysokosc, double waga, double glebokosc, double maxLoad, bool isSafe)
        : base("L", wysokosc, waga, glebokosc, maxLoad)
    {
        IsSafe = isSafe;
    }
    

    public override void LoadingContainer(double masa)
    {
        masa = IsSafe ? MaxLoad*0.5: MaxLoad*0.9;
        if (masa + MasaLadunku > MaxLoad)
        {
            NotifyHazard();
            throw new OverfillException();
        }
     MasaLadunku += masa;   
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"!UWAGA! Niebezpieczna sytuacja z kontenerem {KontenerID}");
    }
}
