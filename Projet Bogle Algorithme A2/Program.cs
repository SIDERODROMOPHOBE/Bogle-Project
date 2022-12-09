using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_Bogle_Algorithme_A2
{
	public static class Program
	{
		private static Joueur[] Joueurs = new Joueur[2];
		
		private static void Main()
		{
			Console.WriteLine($"Bonjour, bienvenue sur le jeu");
			Console.WriteLine($"Veuillez indiqué le nom du Joueur 1");
			Joueurs[0] = new Joueur(Console.ReadLine());
			Console.WriteLine($"Veuillez indiqué le nom du Joueur 2");
			Joueurs[1] = new Joueur(Console.ReadLine());
			
			Console.WriteLine($"Indiqué le nombre de manche :");
			int nbManche = Convert.ToInt32(Console.ReadLine());

			for(int i = 0; i < nbManche; i++)
			{
				foreach(Joueur joueur in Joueurs)
				{
					Plateau(char[0,0], i, )
				}
			}
		}
	}
}
