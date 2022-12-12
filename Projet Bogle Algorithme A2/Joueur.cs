using System.Collections.Generic;

namespace Projet_Bogle_Algorithme_A2
{
	public class Joueur
	{
		//Déclaration de variables global.
		public string Nom { get; }
		public int Score { get; private set; }
		private List<string> Mots { get; }
		
		//Instancie un Joueur avec en paramètre son nom.
		public Joueur(string nom)
		{
			//Définie un joueur.
			Nom = nom[0].ToString().ToUpper() + nom[1..].ToLower();
			Score = 0;
			Mots = new List<string>();
		}

		//Vérifie si le joueur à déjà le mot passer en paramètre dans sa liste.
		public bool Verif_Mot(string mot)       
		{
			//Return true si le mot existe, false si il n'existe pas.
			return Mots.Contains(mot);                
		}
	   
		//Ajoute un mot passer en paramètre dans la liste de mots du joueur.
		public void Add_Mot(string mot)
		{
			Mots.Add(mot);
		}
		
		//Return tout les mots que le joueurs à trouvers.
		public string Get_Mots()
		{
			string print = "";
			foreach (string mot in Mots)
			{
				print += $"{ mot }, ";
			}
			return print;
		}

		//Ajoute le score passer en paramètre au score total du joueur.
		public void Add_Score(int score)
		{
			Score += score;
		}

		//Return les informations du joueurs.
		public override string ToString()
		{
			string print = $"Le joueur se prénomme { Nom }, son score est de : { Score } et ses mots sont : ";
			//Appel de la fonction Get_Mots().
			print += Get_Mots();
			return print;
		}
	}
}
