namespace AplikacjaKontenerowa;

public class Kontenerowiec
{
    public string Nazwa { get; set; }
    private List<Kontener> Kontenery { get; }
    public double MaxSpeed { get; set; }
    public int MaxLiczbaKontenerow { get;}
    public double MaxWagaKontenerow { get;}

    public Kontenerowiec(string nazwa,double maxSpeed, int maxLiczbaKontenerow, double maxWagaKontenerow)
    {
        Nazwa = nazwa;
        MaxSpeed = maxSpeed;
        MaxLiczbaKontenerow = maxLiczbaKontenerow;
        MaxWagaKontenerow = maxWagaKontenerow * 1000;
        Kontenery = new List<Kontener>();
    }

    public void LoadingOnShip(Kontener kontener)
    {
        if (Kontenery.Count > MaxLiczbaKontenerow)
        {
            throw new Exception("Brak miejsc");
        }

        if (WagaKontenerow() + kontener.MasaLadunku > MaxWagaKontenerow)
        {
            throw new Exception("Brak mozliwosci wagowych");
        }
        
        Kontenery.Add(kontener);
    }

    public void RemoveContainer(string numer)
    {
        Kontener kontenerDousuniecia = null;
        foreach (var kontener in Kontenery)
        {
            if (kontener.KontenerID == numer)
            {
                kontenerDousuniecia=kontener;
            }
        }
        Kontenery.Remove(kontenerDousuniecia);
    }

    public void Unload()
    {
        Kontenery.Clear();
    }

    public void ChangeContainer(Kontener kontenerNowy, string numer)
    {
                RemoveContainer(numer);
                LoadingOnShip(kontenerNowy);
    }

    public void MoveContainer(Kontenerowiec kontenerowiecDocelowy, string numerKontenera)
    {
        Boolean moznausuwac=false;
        foreach (var kontener in Kontenery)
        {
            if (kontener.KontenerID==numerKontenera)
            {
                moznausuwac = true;
                kontenerowiecDocelowy.LoadingOnShip(kontener);
            }
        }

        if (moznausuwac)
        {
            RemoveContainer(numerKontenera);
        }
    }

    public void InformacjeOKontenerowcu()
    {
        Console.WriteLine($"Nazwa: {Nazwa}, MaxSpeed: {MaxSpeed}, MaxLiczbaKontenerow: {MaxLiczbaKontenerow}, MaxWagaKontenerow: {MaxWagaKontenerow/1000} " +
               $"WszystkieKontenery:");
        foreach (var kontener in Kontenery)
        {
            Console.WriteLine(kontener.ToString());
        }
    }

    public void LoadingOnShipList(List<Kontener> konteneryNowe)
    {
        foreach (var kontener in konteneryNowe)
        {
            LoadingOnShip(kontener);
        }
    }

    public double WagaKontenerow()
    {
        double suma = 0;
        foreach(Kontener kontener in Kontenery)
        {
           suma+= kontener.MasaLadunku;
        }
        return suma;
    }
}