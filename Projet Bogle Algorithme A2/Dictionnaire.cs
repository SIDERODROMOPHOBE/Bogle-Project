using System.Collections.Generic;
using System.IO;

namespace Projet_Bogle_Algorithme_A2
{
	public class Dictionnaire
	{
		//Déclaration de variables global.
		private string Langage { get; }
		private List<List<string>> Mots { get; }
        private string Fichier { get; }

        //Instancie un Dictionnaire avec en paramètre son langage et la localisation du fichier.
		public Dictionnaire(string langage, string file)
		{
			//Définie le dictionnaire.
			Langage = langage;
			Fichier = file;
			Mots = new List<List<string>>();
			//Lance la fonction ReadFile().
			ReadFile();
        }

		//Parse le fichier et ajoute tout les mots dans la liste.
		private void ReadFile()
		{
            int lengh = 0;
            foreach(string mot in new StreamReader(Fichier).ToString()!.Split(" "))
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
		}

		//Return un string qui définie le dictionnaire.
		public override string ToString()
		{
			int totalMots = 0;
			foreach (var mots in Mots)
			{
				totalMots += mots.Count;
			}

			string print = $"Le dictionnaire est en {Langage}, il comporte {totalMots} mots dont :";
			for(int i = 0; i < Mots.Count; i++)
			{
				print += $" -  {Mots[i].Count} mots de {i + 1} de longueurs.";
			}

			return print;
		}

		//Return true si le mot en paramètre existe dans la liste, sinon Return false.
		public bool RechDichoRecursive(string mot)
		{
			return Mots[mot.Length].Contains(mot);
		}
	}
}
