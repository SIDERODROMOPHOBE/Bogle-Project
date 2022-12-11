using System.Collections.Generic;

namespace Projet_Bogle_Algorithme_A2
{
	public class Plateau
	{
		private char[,] Matrice { get; }
		public List<string> MotsInMatrice { get; }
		private Dictionnaire Dico { get; }
		
		public Plateau(char[,] matrice, string lang)
		{
			Matrice = matrice;
			MotsInMatrice = new List<string>();
			
			switch (lang)
			{
				case "FR":
				{
					Dico = new Dictionnaire( lang, "MotsPotyssiblesFR.txt");
					break;
				}
				case "EN":
				{
					Dico = new Dictionnaire(lang, "MotsPossiblesEN.txt");
					break;
				}
			}
		}
		
		public override string ToString()
		{
			string print = "";

			for (int i = 0; i < Matrice.GetLength(0); i++)
			{
				for (int j = 0; j < Matrice.GetLength(1); j++)
				{
					print += $"{ Matrice[i, j] } ";
				}
				print += "\n";
			}
			return print;
		}
		
		public bool Get_List_Mots(int level, int nbManche = 0)
		{
			switch(level)
			{
				case 1:
				{
					for(int i = 0; i < Matrice.GetLength(0); i++)
					{
						string mot = "";
						for(int j = 0; j < Matrice.GetLength(1); j++)
						{
							mot += Matrice[i, j];
							if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					for(int i = 0; i < Matrice.GetLength(0); i++)
					{
						string mot = "";
						for(int j = 0; j < Matrice.GetLength(1); j++)
						{
							mot += Matrice[j, i];
							if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
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
					for(int i = Matrice.GetLength(0) - 1; i >= 0; i--)
					{
						string mot = "";
						for(int j = Matrice.GetLength(1) - 1; j >= 0; j--)
						{
							mot += Matrice[i, j];
							if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					for(int i = Matrice.GetLength(0) - 1; i >= 0; i--)
					{
						string mot = "";
						for(int j = Matrice.GetLength(1) - 1; j >= 0; j--)
						{
							mot += Matrice[j, i];
							if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
							{
								MotsInMatrice.Add(mot);
							}
						}
					}
					break;
				}
			}
			return MotsInMatrice.Count > nbManche;
		}

		public bool Test_Plateau(string mot)
		{
			return MotsInMatrice.Contains(mot);
		}
	}
}