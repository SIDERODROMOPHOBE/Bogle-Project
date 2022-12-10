using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Projet_Bogle_Algorithme_A2
{
	class Jeu
	{
		private Dictionnaire Dico { get; set; }
		private Plateau Plat { get; set; }
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
				catch (Exception e)
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
				catch (Exception e)
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
				catch (Exception e)
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
				int temp = Convert.ToInt32(Console.ReadLine());
				if(Array.Exists(new int[] {1, 2, 3}, element => element == temp))
				{
					level = temp;
				}
				else
				{
					Console.WriteLine("Difficulté non reconnue, veuillez réessayer.");
				}
			} while (level == 0);
			
			Console.Clear();
			Console.WriteLine($"Indiqué le langage : (FR/EN)");
			string lang = null;
			do
			{
				string temp = Console.ReadLine();
				if(Array.Exists(new string[] {"FR", "fr", "f", "EN", "en", "e"}, element => element == temp))
				{
					if(Array.Exists(new string[] {"FR", "fr", "f"}, element => element == temp))
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
					do
					{
						Console.WriteLine("Error");
						Plat = new Plateau(InitMatrice(nbManche + 2), level, lang);
						Console.WriteLine(Plat.ToString());
					}
					while (Plat.Get_List_Mots() == false);
					Console.WriteLine("OK");
					Play(joueur);
				}
			}
			Console.Clear();
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
				Console.WriteLine($"Égalité entre les joueurs avec { _players[0].Score } points");
			}
		}
	
		private void Play(Joueur joueur)
		{
			DateTime start = DateTime.Now;
			Console.Clear();
			Console.WriteLine(Plat.ToString());
			Console.WriteLine($"Veuillez indiqué un mot :");
			do
			{
				Console.Clear();
				Console.WriteLine($"{ TimeSpan.FromSeconds(60) - (DateTime.Now - start) } secondes");
				string mot = Console.ReadLine();
				if(Plat.Test_Plateau(mot) && mot != null)
				{
					Console.WriteLine($"Mot valide");
					joueur.Add_Mot(mot);
					joueur.Add_Score(mot.Length);
				}
				else
				{
					Console.WriteLine($"Mot invalide");
				}
			} while (DateTime.Now - start < TimeSpan.FromSeconds(60));
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
