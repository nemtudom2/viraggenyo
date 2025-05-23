using System.Security.Cryptography.X509Certificates;

namespace gsfadsadffasdf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new StreamReader("felajanlas.txt");
            var allomany = (from x in a.ReadToEnd().Replace("\r", "").Split("\n") select x.Split(" ")).ToList();
            int agyasokszama = Convert.ToInt32(allomany[0][0]);
            //Console.WriteLine(agyasokszama);
            allomany.RemoveAt(0);
            a.Close();

            Console.WriteLine($"{allomany.Count} felajanlas van");
            List<int> sorszamok = new List<int>();
            List<List<int>> agyasok = new List<List<int>>();
            List<string> szinek = new List<string>();
            //Console.WriteLine(Enumerable.Range(5, 10).ToList()[9]);

            for (int i = 0; i < allomany.Count; i++)
            {
                int elso = Convert.ToInt32(allomany[i][0]);
                int masodik = Convert.ToInt32(allomany[i][1]);
                List<int> current = new List<int>();
                if (elso > masodik) // az elso nagyobb mint a masodik
                {
                    sorszamok.Add(i);
                    try
                    {
                        current = Enumerable.Range(elso, agyasokszama - elso).ToList();
                    }
                    catch
                    {
                        Console.WriteLine(elso);
                    }
                    current.Concat(Enumerable.Range(1, masodik).ToList());
                }
                else
                {
                    current = Enumerable.Range(elso, masodik - elso).ToList();
                }
                agyasok.Add(current);
            }
            Console.WriteLine(string.Join(", ", sorszamok)); ;

            Console.WriteLine("agyas");
            int inp = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(agyasok.Count(x => x.Contains(inp)));
            string szin = "Ezt az agyast nem utltettek be";
            for (int i = 0; i < agyasok.Count; i++)
            {
                if (agyasok[i].Contains(inp))
                {
                    szin = allomany[i][2];
                    break;
                }
            }
            Console.WriteLine(szin);
            HashSet<string> agyasszinei = new HashSet<string>();
            for (int i = 0; i < agyasok.Count; i++)
            {
                if (agyasok[i].Contains(inp))
                {
                    agyasszinei.Add(allomany[i][2]);
                }
            }
            Console.WriteLine(string.Join(", ", agyasszinei.ToList()));

            bool mindbenvan = true;
            for (int i = 0; i<agyasokszama; i++)
            {
                if (agyasok.Count(x=> x.Contains(i)) == 0) { mindbenvan = false; } // megszamoljuk mennyi olyan van, ami tartalmazza i-t, ha egy sincs akkor oda senki nem vallalt
            }
            var osszesfelajanlas = agyasok.Aggregate((x, y) => x.Concat(y).ToList()).Count();
            if (mindbenvan) { Console.WriteLine("minden agyas beultetesere van jelentkezo"); }
            else if (osszesfelajanlas >= agyasokszama) { Console.WriteLine("atszervezessel megoldhato"); }
            else { Console.WriteLine("nem oldhato meg"); }
        }
    }
}
