using System.Text.RegularExpressions;
// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");


Dictionary<string, int> livro = new Dictionary<string, int>();


using (var flow = new FileStream("texto.txt", FileMode.Open))
using (var reader = new StreamReader(flow))
{
  while (!reader.EndOfStream)
  {
    string line = reader.ReadLine().Trim().ToLower();

    if (line == null)
    {
      continue;
    }
    string[] lineText = Regex.Replace(line, @"[^0-9a-zA-Z]+", " ").Split(" ");

    foreach (var item in lineText)
    {

      if (item == "")
        continue;



      if (!livro.ContainsKey(item))
      {
        livro.Add(item, 1);
      }
      else
      {

        livro[item] = livro.GetValueOrDefault(item) + 1;
      }
    }

  }
}













Dictionary<string, int> sorted = (
            from entry in livro
            orderby entry.Value descending
            select entry
        )
            .Take(10)
            .ToDictionary(entry => entry.Key, entry => entry.Value);



foreach (var item in sorted)
{
  Console.WriteLine(item);
}