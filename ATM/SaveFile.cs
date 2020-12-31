using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ATM
{
    class SaveFile
    {
        public void SaveOperation(string operation)
        {
            using(StreamWriter sw = new StreamWriter("Operations.txt", true))
            {
                DateTime dt = new DateTime();

                dt = DateTime.Now;

                sw.WriteLine($"{dt.ToString("dd-MM-yyyy HH:mm")} -> {operation}\n");
            }
        }
    }
}
