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
        try{
        current = Enumerable.Range(elso, agyasokszama - elso).ToList();
        }catch{
            Console.WriteLine(elso);
        }
        current.Concat(Enumerable.Range(1, masodik).ToList());
    } else
    {
        current = Enumerable.Range(elso, masodik-elso).ToList();
    }
    agyasok.Add(current);
}
Console.WriteLine(string.Join(", ", sorszamok)); ;

Console.WriteLine("agyas");
int inp = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(agyasok.Count(x => x.Contains(inp)));
