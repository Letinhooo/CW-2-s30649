namespace AplikacjaKontenerowa;

public abstract class Kontener
{
    public double MasaLadunku { get; set; }
    public double Wysokosc { get;}
    public double WagaKontenera { get;}
    public double Glebokosc { get;}
    private static int Licznik=1;
    public string KontenerID { get; set; }
    public double MaxLoad { get;}

    public Kontener(string rodzaj,double wysokosc, double wagaKontenera, double glebokosc, double maxLoad)
    {
        Wysokosc = wysokosc;
        WagaKontenera = wagaKontenera;
        Glebokosc = glebokosc;
        MaxLoad = maxLoad;
        MasaLadunku = 0;
        KontenerID = "KON-" + rodzaj + "-" + Licznik++;
    }

    public virtual void ClearContainer()
    {
        MasaLadunku = 0;
    }

    public virtual void LoadingContainer(double masa)
    {
        if (masa + MasaLadunku > MaxLoad)
        {
            throw new OverfillException();
        }
        MasaLadunku+=masa;
    }

    public override string ToString()
    {
       return $"Kontener o numerze {KontenerID} Max Load: {MaxLoad}kg, Wolne miejsce {MaxLoad-MasaLadunku}kg";
    }
        
}