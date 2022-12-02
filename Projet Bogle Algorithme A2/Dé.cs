using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet_Bogle_Algorithme_A2
{
    public class Dé
    {
        private string lettres;          //Est défini par un string contenant les lettres du dé et un Char pour la lettre tirée aléatoirement
        private char lettreActuelle;

        public string Lettres
        {
            get { return this.lettres; }
        }
        public char LettreActuelle
        {
            get { return this.lettreActuelle; }
            set { this.lettreActuelle = value; }
        }

        /// <summary>
        /// Constructeur pour appeler la méthode.
        /// </summary>
        /// <param name="fichier"></param>
        /// <param name="numdé"></param>
        public Dé(string fichier, int numdé)
        {
            string s = ReadFile(fichier, numdé);

            //test si la ligne extraite du fichier en .txt contient bien 6 caractères
            if (s.Length == 6)
            {

                this.lettres = s;    //le string définissant une variable de la classe dé est issu du fichier txt ainsi que de la ligne voulue

            }
            else
            {
                Console.WriteLine("Erreur dans le fichier .TXT de définiton des Lettres des différents dés. \nVérifiez que la nomenclature d'écriture est bien respectée et réessayez.");
                this.lettres = "";
            }
            Random r = new Random();
            int array =r.Next(0, 6);
            this.lettreActuelle = ReadFile("Des.txt",numdé)[array]; //on initalise la lettre actuelle a rien du tout, car a terme, elle sera modifiée par la fonction Lance
        }

        /// <summary>
        /// Méthode qui permet de lire le fichier.
        /// </summary>
        /// <param name="fic"></param>
        /// <param name="ligne"></param>
        /// <returns></returns>
        public string ReadFile(string fic, int ligne)
        {
            StreamReader flux = null;

            int i = 0;    //Compteur de position dans les lignes du fichier en lecture
            string retour = "";
            try // essaye de lire le fichier
            {
                flux = new StreamReader(fic);
                string line;
                while ((line = flux.ReadLine()) != null)      //on prend en compte la ligne voulue (Sera une valeur aléatoire unique entre 1 et 16) issue du constructeur du dé
                {
                    if (i == ligne - 1)
                    {
                        for (int j = 0; j < line.Length; j++)     //Passe en revue les caractères de la ligné désirée, et retire les points-virgules (présents dans les fichiers en .csv)
                        {
                            if (line[j] != ';')                   
                            {
                                retour += line[j];
                            }
                        }
                        return retour;
                    }
                    i++;
                }
                Console.WriteLine("Fatal Error Has Ocurred");   //si vous voyez ce message, ce n'est pas une bonne chose...
                return null;
            }
            catch (Exception e) // renvoie une exception
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally // A la fin de l'échange avec le fichier, on ferme le flux.
            {
                if (flux != null) { flux.Close(); }
            }
        }

        /// <summary>
        /// Sélectionne une position aléatoire entre 1 et 6 (entre 0 et 5 pour l'index) 
        /// et définit la lettre actuelle du dé en fonction de la liste de lettre choisie via le readfile et la position aléatoire
        /// </summary>
        public  void Lance()
        { 
            Random r = new Random();
            int rLettre = r.Next(0,6);
            this.lettreActuelle = this.lettres[rLettre];
        }

        /// <summary>
        /// Permet de donner l'information sur la lettre choisi en fonctiuon du dé.
        /// </summary>
        /// <returns></returns>
        public override string ToString() 
        {
            string s = "";
            for (int i = 0; i < this.lettres.Length; i++)
            {
                s += this.lettres[i] + " ";
            }
            return "Le dé contient les lettres : " + s + "et sa position actuelle est sur la lettre : " + this.lettreActuelle +'.';
        }
    }
}
