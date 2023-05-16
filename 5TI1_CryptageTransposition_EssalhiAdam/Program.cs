using System;

namespace AppliCryptTranspo
{
    class Program
    {
        static void Main(string[] args)
        {
            string cle;
            string texte;
            string chaineSSEsp = "";
            string chaineCrypt;
            char[,] matrice;
            char[,] mattri;

            MethodeTraitementCrypt MesOutils = new MethodeTraitementCrypt();

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("Codage par transposition");
                Console.WriteLine("=========================");
                Console.WriteLine("");

                Console.WriteLine("Entrez votre mot-clé");
                MesOutils.LireString("Votre mot clé : ", out cle);
                Console.WriteLine("=========================");
                Console.WriteLine("Entrez votre phrase");
                MesOutils.LireString("Votre phrase : ", out texte);

                MesOutils.RetireEspaces(texte, chaineSSEsp);
                MesOutils.DimensionMat(cle, chaineSSEsp, out matrice);
                MesOutils.RemplissageMat(cle, texte, ref matrice);
                MesOutils.TriLigne(ref matrice);
                MesOutils.ClasseCle(cle, out mattri);
                MesOutils.AttribueRang(ref matrice, ref mattri);
                MesOutils.RealiseCrypt(matrice, out chaineCrypt);

                Console.WriteLine("Votre phrase cryptée:");
                Console.WriteLine(chaineCrypt);
            }
        }
    }
}