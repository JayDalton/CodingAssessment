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
}
