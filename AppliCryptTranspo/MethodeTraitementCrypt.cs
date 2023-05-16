using System;
using System.Collections.Generic;
using System.Text;

namespace AppliCryptTranspo
{
    public struct MethodeTraitementCrypt
    {
        public void RetireEspaces(string chaine, string chaineSSEsp)
        {
            string chaineSSESP = "";
            int lg = chaine.Length;
            for (int i = 0; i < lg - 1; i++)
            {
                if (chaine[i] != ' ')
                {
                    chaineSSEsp = chaineSSEsp + chaine[i];
                }
            }
        }

        public void DimensionMat(string cle, string texte, out char[,] matrice)
        {
            int d1 = (texte.Length / cle.Length) + 2;
            int d2 = cle.Length;
            if (texte.Length % cle.Length != 0)
            {
                d1 = d1 + 1;
            }
            matrice = new char[d1, d2];
        }

        public void RemplissageMat(string cle, string texte, ref char[,] mat)
        {
            for (int j = 0; j < mat.GetLength(1) - 1; j++)
            {
                mat[0, j] = cle[j];
            }

            int k = 0;
            for (int i = 0; 2 < mat.GetLength(0) - 1; i++)
            {
                int j = 0;
                while ((j < mat.GetLength(1)) && (k == texte.Length))
                {
                    mat[i, j] = texte[k];
                    k = k + 1;
                    j = j + 1;
                }
            }
        }
        public void TriLigne(ref char[,] mat)
        {
            bool permut = false;
            for (int i = 0; i < mat.GetLength(1) - 1; i++)
            {
                if (mat[0, 1] > mat[0, 1 + 1])
                {
                    int temp = mat[0, 1];
                    mat[0, 1] = mat[0, 1 + 1];
                    mat[0, 1 + 1] = temp;
                    permut = true;
                }
            }
            /*jusqu'à */
            permut = false;
        }

        public void ClasseCle(string cle, out char[,] mattri)
        {
            mattri = new char[3, cle.Length];

        }

    }
}
