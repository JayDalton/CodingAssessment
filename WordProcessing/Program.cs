using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordProcessing
{
  class Program
  {
    static void Main(string[] args)
    {
      var input = "The big brown fox number 4 jumped over the lazy dog. THE BIG BROWN FOX JUMPED OVER THE LAZY DOG. The Big Brown Fox 123.";

      var result = new List<TestItem>
      {
        new TestItem{ ID = 0, Type = 1, Name = "1", Date = new DateTime(2017, 2, 12)},
        new TestItem{ ID = 1, Type = 1, Name = "2", Date = new DateTime(2017, 3, 23)},
        new TestItem{ ID = 2, Type = 1, Name = "3", Date = new DateTime(2017, 3, 17)},
        new TestItem{ ID = 0, Type = 2, Name = "1", Date = new DateTime(2017, 2, 12)},
        new TestItem{ ID = 1, Type = 2, Name = "2", Date = new DateTime(2017, 3, 23)},
        new TestItem{ ID = 2, Type = 2, Name = "3", Date = new DateTime(2017, 3, 17)},
        new TestItem{ ID = 0, Type = 3, Name = "1", Date = new DateTime(2017, 2, 12)},
        new TestItem{ ID = 1, Type = 3, Name = "2", Date = new DateTime(2017, 3, 23)},
        new TestItem{ ID = 2, Type = 3, Name = "3", Date = new DateTime(2017, 3, 17)}
      };

      var temp = result.GroupBy(i => i.Type).Select(i => i.First()).ToList();

      var dict = new Dictionary<string, uint>();
      var sb = new StringBuilder(50);
      foreach (char c in input)
      {
        if (char.IsWhiteSpace(c))
        {
          
        }

        if (char.IsLetter(c))
        {
          sb.Append(c);
        }

        if (c % 2 == 0)
        {

        }

        var y = sb.ToString().ToLower();
        var z = y.Length;

        sb.Clear();

      }
    }
  }

  public class CountIt
  {
    public CountIt()
    {

    }
  }

  public class TestItem
  {
    public TestItem()
    {

    }

    public int ID { get; set; }
    public int Type { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
  }
}
