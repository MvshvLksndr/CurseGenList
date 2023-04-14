using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListWPD
{
    public class CurseGen
    {
        Random random = new Random();
        public string curse()
        {
            int rnd = random.Next(2, 4);
            string result = string.Empty;

            int one = random.Next(2);
            if (one == 1)
            {
                for (int i = 0; i < rnd; i++)
                {
                    result += GetRandomGlas() + GetRandomSogl();
                }
                return result;
            }
            else
            {
                for (int i = 0; i < rnd; i++)
                {
                    result += GetRandomSogl() + GetRandomGlas();
                }
                return result;
            }
            
        }

        public string GetRandomSentence(int MaxWords)
        {
            string result = string.Empty;

            for (int i = 0; i < random.Next(2,MaxWords); i++)
            {
                result += curse() + " ";
            }
            return result;
        }

        public string GetRandomGlas()
        {
            string glas = "аоуыэеёиюя";

            return glas[random.Next(glas.Length)].ToString();
        }

        public string GetRandomSogl()
        {
            string sogl = "бвгджзйклмнпрстфхцчшщ";

            return sogl[random.Next(sogl.Length)].ToString();
        }
    }
}
