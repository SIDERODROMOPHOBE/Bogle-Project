using System;

namespace Projet_Bogle_Algorithme_A2
{
	internal class Jeu
	{
		//Déclaration de variables global.
		private Plateau Plat { get; }
		private readonly Random _rand = new Random();
		private readonly Joueur[] _players = new Joueur[2];

		//Instancie un Jeu.
		public Jeu()
		{
			Console.Clear();
			Console.WriteLine($"Veuillez indiqué le nom du Joueur 1");
			//Vérifie que le nom du joueur 1 est conforme, redemande au joueur si ce n'est pas le cas.
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if(temp != null)
					{
						//Initie un joueur.
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
			//Vérifie que le nom du joueur 2 est conforme, redemande au joueur si ce n'est pas le cas.
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if(temp != null)
					{
						//Initie un joueur.
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
			//Vérifie que le nombre de manche est conforme, redemande au joueur si ce n'est pas le cas.
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
			Console.WriteLine($"Indiqué la difficulté : (1-5)");
			Console.WriteLine($"1 : Haut vers Bas, Gauche vers Droite.");
			Console.WriteLine($"2 : Difficulté 1 + Bas vers Haut, Droite vers Gauche.");
			Console.WriteLine($"3 : Difficulté 2 + Digonale NO vers SE.");
			Console.WriteLine($"4 : Difficulté 3 + Digonale NE vers SO.");
			Console.WriteLine($"5 : Difficulté 4 + Digonales vers le haut.");
			//Vérifie que le niveau de difficulté est conforme, redemande au joueur si ce n'est pas le cas.
			int level = 0;
			do
			{
				string temp = Console.ReadLine();
				try
				{
					if (temp != null && Array.Exists(new[] {"1", "2", "3", "4", "5"}, element => element == temp))
					{
						level = int.Parse(temp);
					}
				}
				catch (Exception)
				{
					Console.WriteLine("Veuillez écrire un chiffre entre 1 et 5 !");
				}
			} while (level == 0);
			
			Console.Clear();
			Console.WriteLine($"Indiqué le langage : (FR/EN)");
			Console.WriteLine($"FR : Dictionnaire Français");
			Console.WriteLine($"EN : Dictionnaire Anglais");
			//Vérifie que la langue du dictionnaire est conforme, redemande au joueur si ce n'est pas le cas.
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
			
			//Boucle sur le nombre de manche.
			for(int i = 0; i < nbManche; i++)
			{
				//Boucle sur le nombre de joueur.
				foreach(Joueur joueur in _players)
				{
					Console.ResetColor();
					Console.Clear();
					Console.WriteLine($"À { joueur.Nom } de joué !");
					//Vérifie qu'une matrice contient un minimum de mot du dictionnaire, recréer une matrice si ce n'est pas le cas.
					do
					{
						//Initie un plateau.
						Plat = new Plateau(InitMatrice(i + 2), lang);
					}
					while (Plat.Get_List_Mots(level, i + 1) == false);
					//Si le plateau est conforme, alors lance la fonction Play().
					Play(joueur);
				}
			}
			Console.Clear();
			//Affiche les résultats des joueurs, et les mots trouvés par le gagnant.
			Console.ForegroundColor = ConsoleColor.Green;
			if(_players[0].Score > _players[1].Score)
			{
				Console.WriteLine($"{ _players[0].Nom } a gagné avec { _players[0].Score } points");
				Console.ResetColor();
				Console.WriteLine($"{ _players[0].Get_Mots() }");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"{ _players[1].Nom } a perdu avec { _players[1].Score } points");
			}
			else if(_players[0].Score < _players[1].Score)
			{
				Console.WriteLine($"{ _players[1].Nom } a gagné avec { _players[1].Score } points");
				Console.ResetColor();
				Console.WriteLine($"{ _players[1].Get_Mots() }");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"{ _players[0].Nom } a perdu avec { _players[0].Score } points");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine($"Égalité entre les joueurs avec { _players[0].Score } points");
			}
			Console.WriteLine("\n");
			Console.ResetColor();
		}
	
		//Lance le jeu du joueur avec en paramètre le joueur.
		private void Play(Joueur player)
		{
			//Lance la compte à rebours.
			DateTime start = DateTime.Now;
			int tempMot = 0;
			//Tant que le compte à rebourd n'atteint pas 0 ou que le joueur n'a pas trouvé tout les mots de la grille disponible.
			do
			{
				Console.ResetColor();
				Console.WriteLine($"\n{ (TimeSpan.FromSeconds(60) - (DateTime.Now - start)).ToString("ss") } secondes restant...\n");
				Console.WriteLine(Plat.ToString());
				Console.WriteLine($"Mot Trouvé : { tempMot }");
				Console.WriteLine($"Mot Restant : { (Plat.MotsInMatrice.Count - tempMot) }");
				Console.Write($"\nVeuillez indiqué un mot : ");
				string mot = Console.ReadLine()?.ToUpper();
				Console.Clear();
				//Vérifie si le mot existe dans la matrice, si le mot n'est pas null et si le joueur n'a pas déjà ce mot.
				if(Plat.Test_Plateau(mot) && mot != null && !player.Verif_Mot(mot))
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Mot valide");
					tempMot++;
					//Lance la fonction Add_Mot().
					player.Add_Mot(mot);
					//Lance la fonction Add_Score().
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
			} while(((DateTime.Now - start) < TimeSpan.FromSeconds(60) && tempMot != Plat.MotsInMatrice.Count));
		}
		
		//Return une matrice avec en paramètre le nombre de manches qui définie la taille de la matrice.
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
