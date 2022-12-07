using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
	public class Plateau
	{
		Dé[,] dés;

		public Dé[,] Dés
		{
			get { return dés; }
		}



		public Plateau(Dé[,] dés)
		{
			this.dés = dés;
		}

		/// <summary>
		/// Qui retourne une chaîne de caractères qui décrit un plateau.
		/// </summary>
		public string toString()
		{
			string retour = "";

			for (int i = 0; i < this.dés.GetLength(0); i++)
			{
				for (int j = 0; j < this.dés.GetLength(1); j++)
				{
					retour += Convert.ToString(this.dés[i, j].LettreActuelle) + " ";
				}
				retour += "\n";
			}

			return retour;
		}

		public char[,] GetMatrice()    //Retourne la matrice de char d'un plateau
		{
			char[,] md = new char[4, 4];
			for (int i = 0; i < this.dés.GetLength(0); i++)
			{
				for (int j = 0; j < this.dés.GetLength(1); j++)
				{
					md[i, j] = this.dés[i, j].LettreActuelle;
				}
			}
			return md;
		}



		/// <summary>
		/// qui teste si le mot passé en paramètre est un mot éligible c’est-à-dire qu’il respecte la contrainte d’adjacence décrite ci-dessus.
		///</summary>
		public bool Test_Plateau(string mot)  //Cas non pris en compte : REPASSER 2 FOIS PAR LA MEME LETTRE (a corriger)
		{

			int tp = 0;
			int tampon = 0;
			int tampon2 = 0;

			char[,] caractères = this.GetMatrice();



			for (int i = 0; i < caractères.GetLength(0); i++)
			{

				for (int j = 0; j < caractères.GetLength(1); j++) //pour toute la matrice de char, on détermine les coordonnées de la lettre recherchée, et on note sous forme de tab de int que l'on met dans un stack
				{
					
					if (caractères[i, j] == mot[0])  //détection de la INDEXIEME lettre voulue du mot dont nous cherchons la présence
					{
						for (int index = 1; index < mot.Length; index++)  //pour chaque position de caractère du mot
						{
							caractères[i, j] = mot[0];
							

							tp = index + 1;
							if (LettresAdjacentes(i, j).Contains(mot[index]))       //test parmis les caractères adjacents, on cherche si la lettre suivante y est présente
							{
								
							   // Console.WriteLine("La " + tp + "e lettre est adjacente");



								tampon = this.GetCoordonnées(i, j, mot[index])[0];       //si oui, on récupère les nouvelles coordonnées de la lettre suivante via le GetCoordonnées
								tampon2 = this.GetCoordonnées(i, j, mot[index])[1];

								caractères[i, j] = '$';

								i = tampon;
								j = tampon2;


							}
							else     //sinon, on arrete la recherche via un break, après avoir supprimé le mauvais chemin.
							{
								//Console.WriteLine("La " + tp+ "e lettre nest pas adjacente");
								//insérer un GetCoordonnées pour supprimer la lettre en question et détruire le chemin erroné
								if (LettresAdjacentes(i, j).Contains(mot[index]))
									caractères[this.GetCoordonnées(i, j, mot[index])[0], this.GetCoordonnées(i, j, mot[index])[1]] = '$';

								break;
								
							}

							if (index == mot.Length - 1) return true;    //si l'on est jamais passé par le else de laligne précédente, cela siginife que l'on a toujours trouvé la lettre suivante en adjacence à la lettre précédente. Si on atteint cette conditio, cela siginifie qu l'on arrive à la limite de l'index et donc a la fin du mot, en ayant trouvé un chemin possible. On return doinc true
							
						}
					}
				}
			}
			
			return false;    //si le mot n'a pas été trouvé via toutes les recherches précédentes, on return false
		}





		public List<int> GetCoordonnées(int xdepart, int ydepart, char recherche)  //renvoie un true si une lettre en particulier à été trouvée dans le tableau et renvoie ses coordonnées
		{
			List<int> list = new List<int>();

			for (int i = xdepart - 1; i <= xdepart + 1; i++) //on entre également la Combientième occurence de la lettre nous cherchons, en cherchant de gauche a droite et de haut en bas.
			{
				for (int j = ydepart - 1; j <= ydepart + 1; j++)
				{
					if ((i == xdepart && ydepart == j) || i == -1 || i == 4 || j == -1 || j == 4)  //on supprime le cas de la case actuelle et des bords
					{

					}
					else
					{

						if (this.GetMatrice()[i, j] == recherche)
						{
						   

							list.Add(i); list.Add(j);
							return list;

						}


					}
				}
			}
			return null;

		}





		public List<char> LettresAdjacentes(int x, int y)   //Cette fonction rend sous forme de liste, toutes les lettres adjacentes a la lettre correspondant aux coordonnées en entrée
		{

			List<char> list = new List<char>();

			for (int i = x - 1; i <= x + 1; i++)
			{
				for (int j = y - 1; j <= y + 1; j++)
				{
					if (i == x && j == y)   //cas ou on se retrouve sur la lettre voulue, on ne la prend pas en compte
					{

					}
					else
					{
						if (i == -1 || j == -1 || i == 4 || j == 4) //prendre en compte la sorité du tableau si on est sur un bord
						{

						}
						else
						{
							list.Add(this.Dés[i, j].LettreActuelle);
						}

					}
				}
			}


			return list;
		}











		//public bool LettresValidées(string mot)
		//{
		//    int compteur = 0;
		//    for (int a = 0; a < mot.Length; a++)
		//    {
		//        for (int i = 0; i < this.Dés.GetLength(0); i++)              //détermine les coordonnées de toutes les lettres identiques à la première lettre du mot cherché dans le plateau
		//        {
		//            for (int j = 0; j < this.Dés.GetLength(1); j++)
		//            {
		//                if (this.dés[i, j].LettreActuelle == mot[a])
		//                {
		//                    compteur++;
		//                }
		//            }
		//        }

		//    }
		//    if (compteur >= mot.Length)
		//    {
		//        return true;
		//    }
		//    else { return false; }

		//}















		///// <summary>
		///// qui teste si le mot passé en paramètre est un mot éligible c’est-à-dire qu’il respecte la contrainte d’adjacence décrite ci-dessus.
		/////</summary>
		//public bool Test_Plateau2(string mot)
		//{
		//    char[,] bord = new char[6, 6];
		//    for (int i = 0; i < 6; i++)
		//    {
		//        bord[i, 0] = '|';
		//        bord[0, i] = '|';
		//        bord[i, 5] = '|';
		//        bord[5, i] = '|';
		//    }
		//    for (int i = 1; i < 5; i++)
		//    {
		//        for (int j = 1; j < 5; j++)
		//        {
		//            bord[i, j] = bord[i - 1, j - 1];
		//        }
		//    }
		//    for (int i = 1; i < 5; i++)
		//    {
		//        for (int j = 1; j < 5; j++)
		//        {
		//            if (bord[i, j] == mot[0])
		//            {
		//                bord[i, j] = '0';
		//                if (Recursivité(mot, bord, 1, i, j))
		//                {
		//                    return true;
		//                }
		//                bord[i, j] = mot[0];
		//            }
		//        }
		//    }
		//    return false;
		//}

		//public bool Recursivité(string mot, char[,] bord, int cpt, int ligne, int colonne)
		//{
		//    {
		//        if (cpt >= mot.Length)
		//        {
		//            return true;
		//        }

		//        for (int i = ligne - 1; i <= ligne + 1; i++)
		//        {
		//            for (int j = colonne - 1; j <= colonne + 1; j++)
		//            {
		//                if (bord[i, j] == mot[cpt] && bord[i, j] != '0')
		//                {
		//                    bord[i, j] = '0';
		//                    if (Recursivité(mot, bord, cpt + 1, i, j))
		//                    {
		//                        return true;
		//                    }
		//                    bord[i, j] = mot[cpt];
		//                }
		//            }
		//        }
		//        return false;
		//    }
		//}
	}

}




