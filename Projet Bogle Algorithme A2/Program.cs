using System;

namespace Projet_Bogle_Algorithme_A2
{
	public static class Program
	{
		private static Jeu jeu;
		private static void Main()
		{
			do
			{
				Console.WriteLine($"Bonjour, bienvenue sur le jeu");
				Console.WriteLine($"Voulez vous jouer ? (Yes/No)");
				string answer = Console.ReadLine();
				if (Array.Exists(new[] {"Yes", "yes", "YES", "y"}, element => element == answer))
				{
					jeu = new Jeu();
				}
				else
				{
					jeu = null;
					Console.WriteLine($"Au revoir");
				}
			} while (jeu != null);
		}
	}
}
