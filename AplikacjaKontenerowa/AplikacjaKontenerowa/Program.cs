
using AplikacjaKontenerowa;


    Kontenerowiec statek = new("Statek", 10, 40, 40);

    KontenerNaPlyny kontener1 = new(1.5, 200, 3, 5000, true);
    KontenerNaGaz kontener2 = new(4, 100, 2.5, 3000, 10);
    KontenerChlodniczy kontener3 = new(5, 800, 2.5, 4000, -5,"Banany");
    try
    {
        kontener1.LoadingContainer(2000);
        kontener2.LoadingContainer(1000);
        kontener3.LoadingContainer(3500, 10, "Banany");

    }
    catch (OverfillException)
    { }

    Console.WriteLine(kontener1.ToString());
    
        statek.LoadingOnShip(kontener1);
        statek.LoadingOnShip(kontener2);
        statek.LoadingOnShip(kontener3);
        statek.RemoveContainer(kontener1.KontenerID);

    statek.InformacjeOKontenerowcu();
