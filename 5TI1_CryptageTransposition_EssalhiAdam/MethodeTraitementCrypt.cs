using System;
using System.Collections.Generic;
using System.Text;

namespace AppliCryptTranspo
{
    public struct MethodeTraitementCrypt
    {
        /// <summary>
        /// Fabriquer une copie de la chaine de départ sans les espaces
        /// </summary>
        /// <param name="chaine"> </param>
        /// <param name="chaineSSEsp"> </param>
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

        /// <summary>
        /// Détermine les dimensions de la matrice en fonction de la clé et du texte
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="texte"></param>
        /// <param name="matrice"></param>
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

        /// <summary>
        /// Remplit la première ligne de la matrice avec cle, et le reste à partir de la 3° ligne avec le texte.
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="texte"></param>
        /// <param name="mat"></param>
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

        /// <summary>
        /// Trie la première ligne d’une matrice par ordre alphabétique croissant
        /// </summary>
        /// <param name="mat"></param>
        public void TriLigne(ref char[,] mat)
        {
            bool permut = true;
            while (permut)
            {
                permut = false;
                for (int i = 0; i < mat.GetLength(1) - 1; i++)
                {
                    if (mat[0, i] > mat[0, i + 1])
                    {
                        char temp = mat[0, i];
                        mat[0, i] = mat[0, i + 1];
                        mat[0, i + 1] = temp;
                        permut = true;
                    }
                }
            }
        }

        /// <summary>
        /// Crée et remplit mattri avec la clé triée par ordre alphabétique dans la première ligne, des numéros d’ordre dans la seconde ligne et des 0 dans la 3°
        /// </summary>
        /// <param name="cle"></param>
        /// <param name="mattri"></param>
        public void ClasseCle(string cle, out char[,] mattri)
        {
            mattri = new char[3, cle.Length];
            for (int j = 0; j < mattri.GetLength(1); j++)
            {
                mattri[0, j] = cle[j];
                mattri[2, j] = '0';
                TriLigne(ref mattri);
            }
            for (int j = 1; j < mattri.GetLength(1); j++)
            {
                mattri[1, j - 1] = Char.Parse(j.ToString());
            }
        }

        /// <summary>
        /// Mat existe, contient la clé de cryptage dans sa première ligne et le texte dans le reste de la matrice à partir de la 3° ligne
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="mattri"></param>
        public void AttribueRang(ref char[,] mat, ref char[,] mattri)
        {
            for (int i = 0; i < mat.GetLength(1); i++)
            {
                bool trouve = false;
                int j = 0;
                while (trouve == false && j < mattri.GetLength(1))
                {
                    if (mat[0, i] == mattri[0, j] && mattri[2, j] != '1')
                    {
                        mat[1, j] = mattri[1, j];
                        mattri[2, j] = '1';
                        trouve = true;
                        j = j + 1;
                    }
                }
            }
        }

        /// <summary>
        /// Construit la chaîne de cryptage en utilisant la méthode de cryptage par transposition
        /// </summary>
        /// <param name="mat"></param>
        /// <param name="chaineCrypt"></param>
        public void RealiseCrypt(char[,] mat, out string chaineCrypt)
        {
            chaineCrypt = "";
            int i = 1;
            while (i <= mat.GetLength(1))
            {
                bool trouve = false;
                int j = 0;
                while (!trouve && j < mat.GetLength(1))
                {
                    if (i == mat[1, j])
                    {
                        for (int k = 2; k < mat.GetLength(0); k++)
                        {
                            chaineCrypt += mat[k, j];
                        }
                        chaineCrypt += " ";
                        trouve = true;
                        i = i + 1;
                        j = j + 1;


                    }
                }
            }
        }

        /// <summary>
        /// vérification et empêche l'utilisateur d'entrer une valeur int.
        /// </summary>
        /// <param name="question"></param>
        /// <param name="charUser"></param>
        public void LireString(string question, out string charUser)
        {
            Console.Write(question);
            charUser = Console.ReadLine();
            while (string.IsNullOrEmpty(charUser))
            {
                Console.WriteLine("Attention ! Vous devez entrer des caractères !.");
                Console.Write(question);
                charUser = Console.ReadLine();
            }
        }
    }
}