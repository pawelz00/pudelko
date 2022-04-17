using pudelko;
Console.WriteLine("------------------");
Pudelko p1 = new Pudelko(1,7,3,Pudelko.UnitOfMeasure.meter);
Pudelko p2 = new Pudelko(2,3,4, Pudelko.UnitOfMeasure.meter);
Pudelko p3 = new Pudelko(3,4,5,Pudelko.UnitOfMeasure.meter);
Pudelko p4 = new Pudelko(1,9,3, Pudelko.UnitOfMeasure.meter);
Pudelko p5 = new Pudelko(2500, 9321, 100, Pudelko.UnitOfMeasure.milimeter);
List<Pudelko> lista = new List<Pudelko>() { p1,p2,p3,p4,p5};
lista.Sort(delegate (Pudelko p1, Pudelko p2) {
    int returnValue = 1;
    if (p1.Objetosc.Equals(p2.Objetosc))
    {
        if (p1.Pole.Equals(p2.Pole))
        {
            returnValue = ((p1.A + p1.B + p1.C).CompareTo((p2.A + p2.B + p3.C)));
        }
        else returnValue = p1.Pole.CompareTo(p2.Pole);
    }
    else returnValue = p1.Objetosc.CompareTo(p2.Objetosc);
    return returnValue;
});
Console.WriteLine("Sortowanie listy");
foreach(Pudelko p in lista)
{
    Console.WriteLine(p);
}
Console.WriteLine("------------------");
Console.WriteLine("Objetosc pudelka p1:");
Console.WriteLine(p1.Objetosc);
Console.WriteLine("------------------");
Console.WriteLine("Pole pudelka p1:");
Console.WriteLine(p1.Pole);
Console.WriteLine("------------------");