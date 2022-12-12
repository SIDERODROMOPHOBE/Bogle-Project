using System.Collections.Generic;

namespace Projet_Bogle_Algorithme_A2
{
	public class Plateau
	{
		//Déclaration de variables global.
		private char[,] Matrice { get; }
		public List<string> MotsInMatrice { get; }
		private Dictionnaire Dico { get; }
		
		//Instancie un Plateau avec en paramètre une matrice et une langue de jeu.
		public Plateau(char[,] matrice, string lang)
		{
			//Définie un plateau.
			Matrice = matrice;
			MotsInMatrice = new List<string>();
			
			//Selon la langue choisis, créer un dictionnaire de cette langue.
			switch (lang)
			{
				case "FR":
				{
					Dico = new Dictionnaire( lang, "MotsPossiblesFR.txt");
					break;
				}
				case "EN":
				{
					Dico = new Dictionnaire(lang, "MotsPossiblesEN.txt");
					break;
				}
			}
		}
		
		//Return un string de la matrice en carré.
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
		
		//Return true si le nombre de mots dans la matrice est supérieur au nombre de manche, sinon Return false.
		public bool Get_List_Mots(int level, int nbManche = 0)
		{
			//Vérifie les mots selon le level choisis.
			switch(level)
			{
				//Parse tout le tableau et vérifie si l'association de lettre existe dans le dictionnaire choisis par le joueur.
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
					//Lance la fonction Get_List_Mots().
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
				case 3:
				{
					//Lance la fonction Get_List_Mots().
					Get_List_Mots(2);
					string mot = "";
					for (int i = 0; i < Matrice.GetLength(0); i++)
					{
						mot += Matrice[i, i];
					}
					if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
					{
						MotsInMatrice.Add(mot);
					}
					break;
				}
				case 4:
				{
					//Lance la fonction Get_List_Mots().
					Get_List_Mots(3);
					string mot = "";
					for (int i = 0; i < Matrice.GetLength(0); i++)
					{
						mot += Matrice[i, Matrice.GetLength(1)-1-i];
					}
					if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
					{
						MotsInMatrice.Add(mot);
					}
					break;
				}
				case 5:
				{
					//Lance la fonction Get_List_Mots().
					Get_List_Mots(4);
					string mot = "";
					for (int i = Matrice.GetLength(0) - 1; i >= 0; i--)
					{
						mot += Matrice[i, i];
					}
					if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
					{
						MotsInMatrice.Add(mot);
					}
					mot = "";
					for (int i = Matrice.GetLength(0) - 1; i >= 0; i--)
					{
						mot += Matrice[i, Matrice.GetLength(1)-1-i];
					}
					if(Dico.RechDichoRecursive(mot) && !MotsInMatrice.Contains(mot))
					{
						MotsInMatrice.Add(mot);
					}
					break;
				}
			}
			return MotsInMatrice.Count > nbManche;
		}

		//Return true si la mot existe dans la matrice, Return false sinon.
		public bool Test_Plateau(string mot)
		{
			return MotsInMatrice.Contains(mot);
		}
	}
}