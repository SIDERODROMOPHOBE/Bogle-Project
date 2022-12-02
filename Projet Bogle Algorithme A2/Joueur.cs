using System;
using System.Collections.Generic;
using System.Text;

namespace Projet_Bogle_Algorithme_A2
{
    public class Joueur
    {
        /* Yo le gang 
        On créé les attributs de la classe. 
        Ici le joueur a un nom, un score et la liste de ses mots valides.
        */
        private string nom;
        private int score;
        private List<string> mots;

        /*
        Cette instance nous permet de traiter la variable nom dans notre main car la variable est privé.
        */
        public string Nom
        {
            get { return nom; }
        }

        public int Score
        {
            get { return score; }
            set { this.score = value; }

        }

        public List<string> Mots
        {
            get { return mots; }
        }

       
        /// <summary>
        ///On programme le constructeur de notre classe Joueur.
        /// C'est à dire un joueur a un nom, un score et une liste de mot.
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="score"></param>
        /// <param name="mots"></param>
        public Joueur(string nom, int score, List<string> mots)
        {
            string s = Convert.ToString(nom[0]).ToUpper() + nom.Substring(1).ToLower();        //On met la première lettre en MAJ et le reste en MIN
            this.nom = s;
            this.score = score;
            this.mots = mots;
        }

        /// <summary>
        /// Regarde si le mot a déjà été cité.
        /// </summary>
        /// <param name="mot"></param>
        /// <returns></returns>
        public bool Contain(string mot)       
        {
            return this.Mots.Contains(mot); 
                
        }

       
        /// <summary>
        ///  Rajoute le mot a la list.
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot)
        {
            this.Mots.Add(mot);
        }

       
        /// <summary>
        /// Les informations du joueurs
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string Mots = "";
            for (int i = 0; i < this.mots.Count ; i++)   //On crée une variable string que l'on incrémente de chaque mot de la liste de mots via ce for. On la concatène ensuite dans le return
            {
                Mots += " " + this.Mots[i];
            }
            return "Le joueur se prénomme " + nom + "." + "\nSon score est de : " + score + ". " + "\nVoici la liste de mots trouvée par le joueur :" + Mots;
        }


    }
}
