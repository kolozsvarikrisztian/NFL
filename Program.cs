// See https://aka.ms/new-console-template for more information
using NFL;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<Jatekos> játékosok = new List<Jatekos>();
        foreach (var sor in File.ReadAllLines("NFL_iranyitok.txt"))
        {
            játékosok.Add(new Jatekos(sor));
        }
        Console.WriteLine("5. feladat: A statisztikában {0} irányító szerepel.", játékosok.Count);

        Console.WriteLine("7. feladat: Legjobb irányítók:");
        foreach (var item in játékosok)
        {
            if (item.IrMutato >= 100 && item.YardMeterben >= 4000)
            {
                Console.WriteLine("\t{0} (Irányító mutató: {1}. Passzok: {2}m.",item.FormazottNev(item.Nev),item.IrMutato,item.YardMeterben);
            }
        }

        Console.Write("8. feladat: Eladaott labdák száma: ");
        int eladott = int.Parse(Console.ReadLine());
        List<string> legtobbeteladott = new List<string>();
        foreach (var item in játékosok)
        {
            if (item.Eladott > eladott)
                legtobbeteladott.Add(item.FormazottNev(item.Nev));
        }
        legtobbeteladott.Sort();
        File.WriteAllLines("legtobbeteladott.txt", legtobbeteladott);

        int legjobb = 0;
        for (int i = 1; i < játékosok.Count; i++)
        {
            if (játékosok[i].TDpasszok > játékosok[legjobb].TDpasszok)
            {
                legjobb = i;
            }
        }

        Console.WriteLine("9. feladat: A legtöbb TD-t szerző játékos: ");
        Console.WriteLine("\tNeve: {0}", játékosok[legjobb].Nev);
        Console.WriteLine("\tTD-k száma: {0}", játékosok[legjobb].TDpasszok);
        Console.WriteLine("\tEladott labdák száma: {0}", játékosok[legjobb].Eladott);

        Dictionary<string, int> stat = new Dictionary<string, int>();
        foreach (var item in játékosok)
        {
            if (stat.ContainsKey(item.Egyetem))
                stat[item.Egyetem]++;
            else
                stat.Add(item.Egyetem, 1);
        }
        Console.WriteLine("10. feladat: Legsikeresebb egyetemek:");
        foreach (var item in stat)
        {
            if (item.Value > 1)
                Console.WriteLine("\t{0} - {1}", item.Key, item.Value);
        }
    }
}