using pudelko;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Pudelko pudelko = new Pudelko(1,2.1,3.05,unit: Pudelko.UnitOfMeasure.meter);
Pudelko pudelko2 = new Pudelko(2100, 1000, 3050, Pudelko.UnitOfMeasure.milimeter);
Console.WriteLine(pudelko.Equals(pudelko2));
var pudlo = new Pudelko();

var pudelkooo = new Pudelko(a:4, c:4, unit:Pudelko.UnitOfMeasure.centimeter);
Console.WriteLine(pudelkooo);