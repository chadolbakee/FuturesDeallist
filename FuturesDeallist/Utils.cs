using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuturesDeallist
{
    public class Utils
    {
        private Dictionary<string, int> futureMultiples;

        public Utils()
        {
            futureMultiples = new Dictionary<string, int>();
            futureMultiples.Add("EuroStoxx", 50);
            futureMultiples.Add("SnP", 50);
            futureMultiples.Add("Kospi", 250000);
        }

        public IReadOnlyDictionary<string, int> MyReadOnlyDictionary
        {
            get { return futureMultiples; }
        }


    }
}
