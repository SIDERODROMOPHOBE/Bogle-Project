using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Projet_Bogle_Algorithme_A2
{
	public class Dictionnaire
	{
		private string Langage { get; set; }
		private List<List<string>> Mots = new List<List<string>>();
        private string Fichier { get; set; }


		/// <summary>
		/// Méthode qui permet de lire le fichier dictionnaire 
		/// </summary>
		/// <param name="fic"></param>
		/// <param name="nbLettre"></param>
		/// <returns></returns>
		public void ReadFile()
		{
            int lengh = 0;
            foreach(string mot in File.ReadAllText(Fichier).Split(" "))
            {
                if(mot.Length > lengh)
                {
                    lengh = mot.Length;
                }
            }
            for(int i = 0; i < lengh; i++)
            {
                Mots.Add(new List<string>());
            }
            foreach(string mot in File.ReadAllText(Fichier).Split(" "))
            {
                Mots[mot.Length].Add(mot);
            }

			//List<string> retour = new List<string>();
			//StreamReader flux = null;

			//try // essaye de lire le fichier
			//{
			//	flux = new StreamReader(fic);
			//	string tampindex;
			//	string line;
			//	string tampon = "";

			//	if (nbLettre < 2 || nbLettre > 15)   //elimine les valeurs incorrectes
			//	{
			//		Console.WriteLine("Le nombre de lettres entré est incorrect.");
			//		return null;
			//	}

			//	while ((line = flux.ReadLine()) != null || retour.Count < 5)
			//	{

			//		if (nbLettre <= 9)    //cas d'un nombre de lettre à un caractère (inférieur à 10)
			//		{


			//			if (Int32.TryParse(Convert.ToString(line[0]), out int sortie))      // On essaye de convertir le charctère en un int. C'est à dire le charctère doit être un chiffre pour etre converti.
			//			{
			//				if (sortie == nbLettre)    // on vérifie que le chiffre demandé (qui correspond à la longueur du mot qu'on veut vérifie s'il appartient au dictionnaire) soit égale au chiffre récupéré auparavant.
			//				{
			//					while ((line = flux.ReadLine()) != null)
			//					{
			//						if (Int32.TryParse(Convert.ToString(line[0]), out int sorr)) // Si on arrive à une ligne ou le charactère peut devenir un int, on arrète la lecture
			//						{
			//							break;
			//						}
			//						else
			//						{
			//							for (int i = 0; i < line.Length; i++) // Lecture ligne par ligne des mots en string dans le fichier qu'on ajoute dans une liste. Chaque mots sont espacés par un espace qui nous permet de séparer les mots.
			//							{
			//								if (line[i] == ' ')
			//								{
			//									retour.Add(tampon);

			//									tampon = "";
			//								}
			//								else
			//								{
			//									tampon += line[i];
			//								}
			//							}

			//							retour.Add(tampon);
			//							tampon = "";
			//						}
			//					}
			//				}
			//			}

			//		}
			//		else         //cas ou le nombre chiffres dans le nombre de lettres cherché dépasse 10 ( 1 et 0 do'u 2 caractères)
			//		{

			//			if (Int32.TryParse(Convert.ToString(line[0]), out int sortie))      // On essaye de convertir le charctère en un int. C'est à dire le charctère doit être un chiffre pour etre converti.
			//			{

			//				if (sortie == 1)                                  //si la variable sortie est égale à 1, alors cela signifie que le stream à attenit le bloc des mots à 10 lettres (il n'y a pas de mots à 1 lettre)
			//				{
			//					tampindex = Convert.ToString(line[0]) + Convert.ToString(line[1]);  //ccomme nous avons atteint le 10, alors nous pouvons concaténer le 1 avec la valeur des unités qui suit ce 1.
			//					sortie = Convert.ToInt32(tampindex);                            //en retransformant cela en int, nous récupérons le nombre de lettres du bloc qui suit. La démarche de test et copiage est Strictement identique a celle présentée plus haut (je l'ai copiée collée hihi)
			//				}
			//				else
			//				{
			//					sortie = 0;
			//				}


			//				if (sortie == nbLettre)    // on vérifie que le chiffre demandé (qui correspond à la longueur du mot qu'on veut vérifie s'il appartient au dictionnaire) soit égale au chiffre récupéré auparavant.
			//				{
			//					while ((line = flux.ReadLine()) != null)
			//					{
			//						if (Int32.TryParse(Convert.ToString(line[0]), out int sorr)) // Si on arrive à une ligne ou le charactère peut devenir un int, on arrète la lecture
			//						{
			//							break;
			//						}
			//						else
			//						{
			//							for (int i = 0; i < line.Length; i++) // Lecture ligne par ligne des mots en string dans le fichier qu'on ajoute dans une liste. Chaque mots sont espacés par un espace qui nous permet de séparer les mots.
			//							{
			//								if (line[i] == ' ')
			//								{
			//									retour.Add(tampon);

			//									tampon = "";
			//								}
			//								else
			//								{
			//									tampon += line[i];
			//								}
			//							}

			//							retour.Add(tampon);
			//							tampon = "";
			//						}
			//					}
			//				}
			//			}

			//		}


			//	}
			//	return retour;
			//}
			//catch (Exception e) // renvoie une exception
			//{
			//	Console.WriteLine(e.Message); return null;

			//}
			//finally // A la fin de l'échange avec le fichier, on ferme le flux.
			//{
			//	if (flux != null) { flux.Close(); }
			//}
		}
		public override string ToString()
		{
			int totalMots = 0;
			for(int i = 0; i < Mots.Count; i++)
			{
				totalMots += Mots[i].Count;
			}

			string print = $"Le dictionnaire est en {Langage}, il comporte {totalMots} mots dont :";
			for(int i = 0; i < Mots.Count; i++)
			{
				print += $" -  {Mots[i].Count} mots de {i + 1} de longueurs.";
			}

			return print;
		}

		public bool RechDichoRecursive(string mot)
		{
			return Mots[mot.Length].Contains(mot);
		}        
	}
}
