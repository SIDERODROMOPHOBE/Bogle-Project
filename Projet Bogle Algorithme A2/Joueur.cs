using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Joueur
	{
		private string Nom { get; set; }
        private int Score { get; set; }
        private List<string> Mots { get; set; }
		
		public Joueur(string nom, int score, List<string> mots)
		{
			Nom = nom[0].ToString().ToUpper() + nom[1..].ToLower();
			Score = score;
			Mots = mots;
		}
		
		public bool Verif_Mot(string mot)       
		{
			return Mots.Contains(mot);                
		}
	   
		public void Add_Mot(string mot)
		{
			Mots.Add(mot);
		}

		public override string ToString()
		{
			string print = $"Le joueur se prénomme { Nom }, son score est de : { Score } et ses mots sont : ";
			for (int i = 0; i < Mots.Count ; i++)   //On crée une variable string que l'on incrémente de chaque mot de la liste de mots via ce for. On la concatène ensuite dans le return
			{
				print += $" -  { Mots[i] }";
			}
			return print;
		}
	}
}
