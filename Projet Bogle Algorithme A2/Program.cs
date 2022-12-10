using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projet_Bogle_Algorithme_A2
{
	public static class Program
	{
		private static void Main()
		{
			Console.WriteLine($"Bonjour, bienvenue sur le jeu");
			Console.WriteLine($"Voulez vous jouer ? (Yes/No)");
			string answer = Console.ReadLine();
			if (Array.Exists(new string[] {"Yes", "yes", "YES", "y"}, element => element == answer))
			{
				Jeu game = new Jeu();
			}
			else
			{
				Console.WriteLine($"Au revoir");
			}
		}
	}
}
