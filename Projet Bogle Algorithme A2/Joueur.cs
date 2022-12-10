using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Joueur
	{
		public string Nom { get; }
		public int Score { get; private set; }
		private List<string> Mots { get; }
		
		public Joueur(string nom)
		{
			Nom = nom[0].ToString().ToUpper() + nom[1..].ToLower();
			Score = 0;
			Mots = new List<string>();
		}

		public bool Verif_Mot(string mot)       
		{
			return Mots.Contains(mot);                
		}
	   
		public void Add_Mot(string mot)
		{
			Mots.Add(mot);
		}
		public string Get_Mots()
		{
			string print = "";
			foreach (string mot in Mots)
			{
				print += $"{ mot }, ";
			}
			return print;
		}

		public void Add_Score(int score)
		{
			Score += score;
		}

		public override string ToString()
		{
			string print = $"Le joueur se prénomme { Nom }, son score est de : { Score } et ses mots sont : ";
			foreach (string mot in Mots)
			{
				print += $" -  { mot }";
			}
			return print;
		}
	}
}
