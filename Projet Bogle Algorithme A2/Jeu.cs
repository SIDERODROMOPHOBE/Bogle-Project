using System;

namespace Projet_Bogle_Algorithme_A2
{
	internal class Jeu
	{
		private Plateau Plat { get; }
		private readonly Random _rand = new Random();
		private readonly Joueur[] _players = new Joueur[2];

		public Jeu()
		{
			Console.Clear();
			Console.WriteLine($"Veuillez indiqué le nom du Joueur 1");
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if(temp != null)
					{
						_players[0] = new Joueur(temp);
					}
				}
				catch(Exception)
				{
					Console.WriteLine("Nom du joueur non reconnue, veuillez réessayer.");
				}
			}
			while(_players[0] == null);
			
			Console.Clear();
			Console.WriteLine($"Veuillez indiqué le nom du Joueur 2");
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if(temp != null)
					{
						_players[1] = new Joueur(temp);
					}
				}
				catch(Exception)
				{
					Console.WriteLine("Nom du joueur non reconnue, veuillez réessayer.");
				}
			}
			while(_players[1] == null);
			
			Console.Clear();
			Console.WriteLine($"Indiqué le nombre de manche :");
			int nbManche = 0;
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if(temp != null)
					{
						nbManche = int.Parse(temp);
					}
				}
				catch(Exception)
				{
					Console.WriteLine("Nombre de manche non reconnue, veuillez réessayer.");
				}
			}
			while(nbManche == 0);
			
			Console.Clear();
			Console.WriteLine($"Indiqué la difficulté : (1-3)");
			int level = 0;
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if (temp != null && Array.Exists(new[] {"1", "2", "3"}, element => element == temp))
					{
						level = int.Parse(temp);
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Veuillez écrire un chiffre entre 1 et 3 !");
				}
			} while (level == 0);
			
			Console.Clear();
			Console.WriteLine($"Indiqué le langage : (FR/EN)");
			string lang = null;
			do
			{
				string temp = Console.ReadLine();
				if(Array.Exists(new[] {"FR", "fr", "f", "EN", "en", "e"}, element => element == temp))
				{
					if(Array.Exists(new[] {"FR", "fr", "f"}, element => element == temp))
					{
						lang = "FR";
					}
					else
					{
						lang = "EN";
					}
				}
				else
				{
					Console.WriteLine("Langue non reconnue, veuillez réessayer.");
				}
			} while (lang == null);
			
			for(int i = 0; i < nbManche; i++)
			{
				foreach(Joueur joueur in _players)
				{
					Console.ResetColor();
					Console.Clear();
					Console.WriteLine($"À { joueur.Nom } de joué !");
					do
					{
						Plat = new Plateau(InitMatrice(i + 2), lang);
					}
					while (Plat.Get_List_Mots(level, i + 1) == false);
					Play(joueur);
				}
			}
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Green;
			if(_players[0].Score > _players[1].Score)
			{
				Console.WriteLine($"{ _players[0].Nom } a gagné avec { _players[0].Score } points");
			}
			else if(_players[0].Score < _players[1].Score)
			{
				Console.WriteLine($"{ _players[1].Nom } a gagné avec { _players[1].Score } points");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"Égalité entre les joueurs avec { _players[0].Score } points");
			}
			Console.WriteLine("\n");
			Console.ResetColor();
		}
	
		private void Play(Joueur player)
		{
			DateTime start = DateTime.Now;
			do
			{
				Console.ResetColor();
				Console.WriteLine($"\n{ (TimeSpan.FromSeconds(60) - (DateTime.Now - start)).ToString("ss") } secondes restant...\n");
				Console.WriteLine(Plat.ToString());
				Console.Write($"\nVeuillez indiqué un mot : ");
				string mot = Console.ReadLine()?.ToUpper();
				Console.Clear();
				if(Plat.Test_Plateau(mot) && mot != null && !player.Verif_Mot(mot))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Mot valide");
					player.Add_Mot(mot);
					player.Add_Score(mot.Length);
				}
				else if(player.Verif_Mot(mot))
				{
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"Mot déjà trouver");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Mot invalide");
				}
			} while(((DateTime.Now - start) < TimeSpan.FromSeconds(60) && player.Mots.Count != Plat.MotsInMatrice.Count));
		}
		
		private char[,] InitMatrice(int nbManches)
		{
			char[,] matrice = new char[nbManches, nbManches];
			for(int i = 0; i < nbManches; i++)
			{
				for(int j = 0; j < nbManches; j++)
				{
					matrice[i, j] = Convert.ToChar(_rand.Next(65, 91));
				}
			}
			return matrice;
		}
	}
}
