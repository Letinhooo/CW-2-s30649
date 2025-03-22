namespace AplikacjaKontenerowa;

public class KontenerChlodniczy : Kontener
{
    public double Temperatura { get; }
    public string TypProduktu { get; set; }

    public KontenerChlodniczy(double wysokosc, double waga, double glebokosc, double maxLoad, double temperatura,string typProduktu)
        : base("C", wysokosc, waga, glebokosc, maxLoad)
    {
        Temperatura = temperatura;
        TypProduktu = typProduktu;
    }
    

    public void LoadingContainer(double masa,double temperaturaProduktu,string typProduktuNowego)
    {
        if (temperaturaProduktu < Temperatura && typProduktuNowego != TypProduktu)
        {
            Console.WriteLine("Typ produktu sie nie zgadza albo temperatura");
        }
        if (masa + MasaLadunku > MaxLoad)
        {
            throw new OverfillException();
        }
        MasaLadunku+=masa;
    }
}