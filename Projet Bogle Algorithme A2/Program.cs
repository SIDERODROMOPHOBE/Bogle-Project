using System;

namespace Projet_Bogle_Algorithme_A2
{
	public static class Program
	{
		//Déclaration de variables global.
		private static Jeu _jeu;
		
		//Programme de lancement.
		private static void Main()
		{
			//Vérifie que le joueur souhaite continuer à jouer.
			do
			{
				Console.WriteLine($"Bonjour, bienvenue sur le jeu");
				Console.WriteLine($"Voulez vous jouer ? (Yes/No)");
				string answer = Console.ReadLine();
				//Vérifie la réponse du joueur.
				if (Array.Exists(new[] {"Yes", "yes", "YES", "y"}, element => element == answer))
				{
					//Lance une partie.
					_jeu = new Jeu();
				}
				else
				{
					//Arrête le programme.
					_jeu = null;
					Console.WriteLine($"Au revoir");
				}
			} while (_jeu != null);
		}
	}
}
