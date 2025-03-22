namespace AplikacjaKontenerowa;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    public int Cisnienie { get; set; }
    public KontenerNaGaz(double wysokosc, double waga, double glebokosc, double maxLoad, int cisnienie)
        : base("G", wysokosc, waga, glebokosc, maxLoad)
    {
        Cisnienie = cisnienie;
    }

    public override void ClearContainer()
    {
        MasaLadunku *= 0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine($"!UWAGA! Zaszlo niebezpeiczne zdarzenie z kontenerem {KontenerID}");
    }
}