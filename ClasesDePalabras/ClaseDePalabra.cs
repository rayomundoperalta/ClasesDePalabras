using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesDePalabras
{
    class ClaseDeLaPalabra
    {
        string Name;
        HashSet<string> CategoriaDePalabras = new HashSet<string>();

        ClaseDeLaPalabra()
        {
            Console.WriteLine("No se puede crear la Categoría de la palabra sin el nombre");
        }

        ClaseDeLaPalabra(string Name)
        {
            this.Name = Name;
            CategoriaDePalabras.Add(Name);
        }

        public string Nombre
        {
            get
            {
                return Name;
            }

            set
            {
                Console.WriteLine("No se le puede cambiar el nombre a una categoría");
            }
        }

        public bool TestAndInclude()
        {
            return false;
        }

        int EditDistance(string original, string modified)
        {
            int len_orig = original.Length;
            int len_diff = modified.Length;

            var matrix = new int[len_orig + 1, len_diff + 1];
            for (int i = 0; i <= len_orig; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= len_diff; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= len_orig; i++)
            {
                for (int j = 1; j <= len_diff; j++)
                {
                    int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                    var vals = new int[] {
                matrix[i - 1, j] + 1,
                matrix[i, j - 1] + 1,
                matrix[i - 1, j - 1] + cost
            };
                    matrix[i, j] = vals.Min();
                    if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[len_orig, len_diff];
        }
    }
}
