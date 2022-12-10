using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Plateau
	{
		private char[,] Matrice { get; }
		private int Level { get; }
		private List<string> MotsInMatrice { get; }
		private Dictionnaire Dico { get; }
		
		public Plateau(char[,] matrice, int level, string lang)
		{
			Matrice = matrice;
			Level = level;
			MotsInMatrice = new List<string>();
			if(lang == "FR")
			{
				Dico = new Dictionnaire( lang, "MotsPossiblesFR.txt");
			}
			else if(lang == "EN")
			{
				Dico = new Dictionnaire(lang, "MotsPossiblesEN.txt");
			}
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
		
		public bool Get_List_Mots(int level = 0)
		{
			switch(Level)
			{
				case 1:
				{
					for(int i = 0; i < Matrice.GetLength(0); i++)
					{
						for(int j = 0; j < Matrice.GetLength(1); j++)
						{
							string mot = "";
							mot += Matrice[i, j];
							if (Dico.RechDichoRecursive(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					for(int i = 0; i < Matrice.GetLength(0); i++)
					{
						for(int j = 0; j < Matrice.GetLength(1); j++)
						{
							string mot = "";
							mot += Matrice[j, i];
							if (Dico.RechDichoRecursive(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					break;
				}
				case 2:
				{
					Get_List_Mots(1);
					for(int i = Matrice.GetLength(0); i >= 0; i--)
					{
						for(int j = Matrice.GetLength(1); j >= 0; j--)
						{
							string mot = "";
							mot += Matrice[i, j];
							if (Dico.RechDichoRecursive(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					for(int i = Matrice.GetLength(0); i >= 0; i--)
					{
						for(int j = Matrice.GetLength(1); j >= 0; j--)
						{
							string mot = "";
							mot += Matrice[j, i];
							if (Dico.RechDichoRecursive(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					break;
				}
			}
			return MotsInMatrice.Count > 0;
		}

		public bool Test_Plateau(string mot)
		{
			return MotsInMatrice.Contains(mot);
		}
	}
}