using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Joueur
	{
		public string Nom { get; set; }
		public int Score { get; set; }
		public List<string> Mots { get; set; }

		/// <summary>
		///On programme le constructeur de notre classe Joueur.
		/// C'est à dire un joueur a un nom, un score et une liste de mot.
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="score"></param>
		/// <param name="mots"></param>
		public Joueur(string nom, int score, List<string> mots)
		{
			Nom = nom[0].ToString().ToUpper() + nom[1..].ToLower();
			Score = score;
			Mots = mots;
		}
		
		/// <summary>
		/// Regarde si le mot a déjà été cité.
		/// </summary>
		/// <param name="mot"></param>
		/// <returns></returns>
		public bool Contain(string mot)       
		{
			return Mots.Contains(mot);                
		}
	   
		/// <summary>
		///  Rajoute le mot a la list.
		/// </summary>
		/// <param name="mot"></param>
		public void Add_Mot(string mot)
		{
			Mots.Add(mot);
		}

	   
		/// <summary>
		/// Les informations du joueurs
		/// </summary>
		/// <returns></returns>
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
