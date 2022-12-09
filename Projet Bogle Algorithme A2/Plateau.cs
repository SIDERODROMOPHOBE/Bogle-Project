using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Plateau
	{
		private char[,] Matrice { get; set; }
		private int Level { get; set; }
		private List<string> Mots { get; set; }
		
		public Plateau(char[,] matrice, int level, List<string> mots)
		{
			Matrice = matrice;
			Level = level;
			Mots = mots;
		}
		
		public override string ToString()
		{
			string print = "";

			for (int i = 0; i < Matrice.GetLength(0); i++)
			{
				for (int j = 0; j < Matrice.GetLength(1); j++)
				{
					print += $"{Matrice[i, j]} ";
				}
				print += "\n";
			}
			return print;
		}

		public bool Test_Plateau(string mot)  //Cas non pris en compte : REPASSER 2 FOIS PAR LA MEME LETTRE (a corriger)
		{
			return true;
		}
	}
}




