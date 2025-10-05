using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filekezeles
{
    internal class Basic
    {
        public Basic()
        {
            //@ jellel elérésiútvonal írható
            string folder = "data";
            string fileName = "example.txt";
            string filePath = Path.Combine(folder, fileName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            File.WriteAllText(filePath, "Első sor");
            File.WriteAllText(filePath, "Második sor");
            File.AppendAllText(filePath, "\nHarmadik sor");

            string allText = File.ReadAllText(filePath);
            Console.WriteLine(allText);

            foreach (var line in File.ReadLines(filePath))
            {
                Console.WriteLine(line);
            }

            using (var reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line.ToUpper());
                }
            }

            foreach (string file in Directory.GetFiles(folder))
            {
                Console.WriteLine(file);
            }
        }
    }
}
