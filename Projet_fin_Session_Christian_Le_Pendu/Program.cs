using System;
using System.Collections.Generic;

namespace Pendu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] mots = { "ordinateur", "programme", "programmation", "langage", "code", "algorithme", "variable" };
            Random random = new Random();
            string motATrouver = mots[random.Next(0, mots.Length)];
            List<char> lettresTrouvees = new List<char>();
            int nbCoupsRestants = 10;
            bool trouve = false;

            Console.WriteLine("Bienvenue dans le jeu du pendu !");
            Console.WriteLine($"Le mot à trouver contient {motATrouver.Length} lettres.");

            while (nbCoupsRestants > 0 && !trouve)
            {
                Console.WriteLine($"Il vous reste {nbCoupsRestants} coups.");
                Console.WriteLine("Entrez une lettre : ");
                char lettre = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (lettresTrouvees.Contains(lettre))
                {
                    Console.WriteLine($"Vous avez déjà entré la lettre {lettre} !");
                }
                else if (motATrouver.Contains(lettre))
                {
                    Console.WriteLine($"Bravo ! La lettre {lettre} est dans le mot.");
                    lettresTrouvees.Add(lettre);

                    if (lettresTrouvees.Count == motATrouver.Length)
                    {
                        trouve = true;
                    }
                }
                else
                {
                    Console.WriteLine($"Dommage ! La lettre {lettre} n'est pas dans le mot.");
                    nbCoupsRestants--;
                }

                Console.WriteLine($"Mot actuel : {GetMotActuel(motATrouver, lettresTrouvees)}");
                Console.WriteLine();
            }

            if (trouve)
            {
                Console.WriteLine("Bravo ! Vous avez trouvé le mot !");
            }
            else
            {
                Console.WriteLine($"Dommage ! Le mot à trouver était {motATrouver}.");
            }

            Console.WriteLine("Appuyez sur une touche pour quitter.");
            Console.ReadKey();
        }

        static string GetMotActuel(string mot, List<char> lettresTrouvees)
        {
            string motActuel = "";

            foreach (char c in mot)
            {
                if (lettresTrouvees.Contains(c))
                {
                    motActuel += c;
                }
                else
                {
                    motActuel += "_";
                }
            }

            return motActuel;
        }
    }
}

