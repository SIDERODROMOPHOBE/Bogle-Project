using System;
using System.Collections.Generic;
using System.IO;

namespace Projet_Bogle_Algorithme_A2
{
    public class Program
    {

        //public static void Test()
        //{


        //    Console.ForegroundColor = ConsoleColor.Green;      //en tant que programmeurs qui se respectent, on ecrit en vert fluo sur fond noir. Merci bien
        //    Console.CursorSize = 1;     //On customize le curseur pour simplifier la visibilité lors de l'écriture des mots


        //    List<string> départ = new List<string>();
        //    List<string> départ2 = new List<string>();
        //    Joueur Gab = new Joueur("GaBrIeL", 0, départ);            //On crée des variables de la classe Joueur.
        //    Joueur Luk = new Joueur("lUkAs", 0, départ2);

        //    Console.WriteLine("Test 1 : Test des variables Joueurs et des constructeurs \nTest 2 : Test des fonctions Add_Mot Contain et ToString \nTest 3 : Test des fonctions lecture du fichier Des");
        //    Console.WriteLine("Test 4 : Test de choix aléatoire de la liste des lettres d'un dé, ainsi que de sa lettre actuelle \nTest 5 : test du readfile dictionnaire qui sert pour toute la classe dictionnaire \nTest 6 : Test de la recherche dans le dictionnaire en récursif");

        //    switch (Convert.ToInt32(Console.ReadLine()))
        //    {

        //        case 1: // on test le constructeur de la classe Joueur
        //            Console.Clear();
        //            Console.WriteLine("laul");

        //            // on initialise une liste


        //            Console.WriteLine(Gab.Nom + " " + Luk.Nom);
        //            break;
        //        case 2:
        //            // Test des nouvelles fonctions

        //            Console.Clear();
        //            Console.WriteLine(Gab.Contain("Pschit"));
        //            Gab.Add_Mot("Pschit");
        //            Console.WriteLine(Gab.Contain("Pschit"));
        //            Console.WriteLine(Gab.ToString());

        //            Console.WriteLine("\n" + Luk.ToString());
        //            break;

        //        case 3:  //test des dés et de leur valeurs

        //            Console.Clear();
        //            Dé d = new Dé("Des.txt", 3);
        //            Dé d2 = new Dé("Des.txt", 2);

        //            Console.WriteLine(d.Lettres);
        //            Console.WriteLine(d2.Lettres);


        //            break;
        //        case 4:    //test de la randomisation des dés, ainsi que de leur lettre actuelle (Fonction Lance et constructeur de la classe dé)
        //            Random ran = new Random();
        //            Dé d3 = new Dé("Des.txt", ran.Next(0, 17));

        //            d3.Lance();

        //            Console.WriteLine(d3.ToString());


        //            break;
        //        case 5:   //test du read file du dictionnaire 

        //            Dictionnaire dico = new Dictionnaire();
        //            Console.Clear();
        //            //LireList( dico.ReadFile("MotsPossibles.txt", 15));
        //            for (int i = 2; i < 16; i++)
        //            {
        //                Console.WriteLine(dico.ToString(i));
        //            }

        //            break;
        //        case 6:   //Test de la recherche du mot en recursif

        //            Dictionnaire ddico = new Dictionnaire();
        //            while (true)
        //            {

        //                string mot = Console.ReadLine();
        //                if (mot == "laul")
        //                    break;



        //                List<string> lst = ddico.ReadFile("MotsPossibles.txt", mot.Length);

        //                Console.WriteLine(ddico.RechDichoRecursive(0, lst.Count, mot.ToUpper(), lst));
        //            }


        //            break;
        //        case 7:  //test de l'affichage des plateaux

        //            Console.Clear();



        //            Plateau plat = new Plateau(CréerPlat());

        //            string t = plat.toString();

        //            Console.WriteLine(t);

        //            for (int k = 0; k < plat.Dés.GetLength(0); k++)
        //            {
        //                for (int l = 0; l < plat.Dés.GetLength(1); l++)
        //                {
        //                    plat.Dés[k, l].Lance();
        //                }
        //            }
        //            Console.WriteLine();
        //            string tt = plat.toString();

        //            Console.WriteLine(tt);

        //            break;

        //        case 8:   //Test de l afonction LettresValidées

        //            Console.Clear();

        //            Plateau platt = new Plateau(CréerPlat());

        //            Console.WriteLine(platt.toString());

        //            while (true)
        //            {
        //                Console.WriteLine("Ecrire le mot chacal !");
        //                string tst = Console.ReadLine();

        //                if (tst == "laul") break;

        //                Console.WriteLine(platt.LettresValidées(tst.ToUpper()));
        //            }

        //            break;

        //        case 9:   //Test de la rechechre d'un mot dans le plateau
        //            Console.Clear();

        //            Plateau plattt = new Plateau(CréerPlat());

        //            Console.WriteLine(plattt.toString());

        //            while (true)
        //            {

        //                string tst = Console.ReadLine();

        //                if (tst == "laul") break;


        //                Console.WriteLine(plattt.Test_Plateau(tst.ToUpper()));

        //            }
        //            break;

        //        case 10:


        //            Console.WriteLine("Vous allez jouer au Jeu du Boggle !");
        //            Console.WriteLine("Joueur 1 : Entrer votre nom :");
        //            List<string> mot1 = new List<string>();
        //            string nom1 = Console.ReadLine();
        //            int score1 = 0;
        //            Joueur J1 = new Joueur(nom1, score1, mot1);

        //            Console.WriteLine("Joueur 2 : Entrer votre nom :");
        //            List<string> mot2 = new List<string>();
        //            string nom2 = Console.ReadLine();
        //            int score2 = 0;
        //            Joueur J2 = new Joueur(nom2, score2, mot2);

        //            Console.WriteLine("Voici le plateau du Joueur 1");
        //            Plateau plat1 = new Plateau(CréerPlat());


        //            Console.WriteLine(plat1.toString());





        //            Console.WriteLine("Voici le plateau du Joueur 2");
        //            Plateau plat2 = new Plateau(CréerPlat());
        //            Console.WriteLine(plat2.toString());


        //            break;


        //    }

        //}   //Ancienne console de test avant l'utilisation des tests Unitaires. Merci de ne pas prendre en compte
       






        /// <summary>
        /// List la liste entrée en paramètre dans la console
        /// </summary>
        /// <param name="list"></param>
        public static string LireList<T>(List<T> list)
        {
            string s = "";

            for (int i = 0; i < list.Count; i++)
            {

                s += list[i] + ", ";
            }
            return s;
        }

        public static Dé[,] CréerPlat()
        {
            Dé[,] tabdé = new Dé[4, 4];

            Random r = new Random();

            int c = 1;
            for (int i = 0; i < tabdé.GetLength(0); i++)
            {
                for (int j = 0; j < tabdé.GetLength(1); j++)
                {
                    tabdé[i, j] = new Dé("Des.txt", c);
                    c++;
                }
            }
            return tabdé;
        }

        static void Main(string[] args)  //------------------------------------------------------------------------------------------------------
        {

            //Test();      // Pour lancer l'ancienne console de test

            Console.ForegroundColor = ConsoleColor.Green; //en tant que programmeurs qui se respectent, on ecrit en rouge fluo sur fond noir. Merci bien
            Console.CursorSize = 1;                        //On customize le curseur pour simplifier la visibilité lors de l'écriture des mots

            DateTime d;
            DateTime d1;
            TimeSpan d2;
            string motentre = "";
            int scoring = 0;
            Dictionnaire dico = new Dictionnaire();


          

            Console.WriteLine("Vous allez jouer au Jeu du Boggle !");


            Console.WriteLine("Joueur 1 : Entrer votre nom :");

            Joueur J1 = new Joueur(Console.ReadLine(), 0, new List<string>());

            Console.WriteLine("Joueur 2 : Entrer votre nom :");

            Joueur J2 = new Joueur(Console.ReadLine(), 0, new List<string>());

            Console.WriteLine("Entrer le nombre de manches");

            int nbmanche = Convert.ToInt32(Console.ReadLine());
            

            for (int i = 0; i < nbmanche; i++)   //Compteur de manches, pour faire le nombre de manches que l'on souhaite
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(J1.Nom + " c'est a votre Tour de jouer");
                Console.WriteLine("\nAppuyer sur Entrer pour continuer");
                Console.ReadLine();


                Console.WriteLine("\nVoici le plateau du joueur 1, vous avez 60 secondes pour trouver le plus de mots possibles.\n");
                Plateau plat1 = new Plateau(CréerPlat());
                Console.WriteLine(plat1.toString());


                d = DateTime.Now;
                d2 = d - d; //Création d'un timeSpan nul (D - D = 0)
                int tamptime;
                while (d2.Minutes < 1)  //phase de jeu Joueur 1
                {
                    //Jouer au jeu ici

                    Console.WriteLine("\nEntrer votre mot");
                    motentre=Console.ReadLine().ToUpper();
                    
                    d1 = DateTime.Now;
                    d2 = d1 - d;
                    tamptime = 60 - d2.Seconds;

                    if (d2.Minutes == 1)
                    {
                        Console.WriteLine("\nLe temps limite à été dépassé, votre dernière entrée n'a pas été comptabilisée");
                        break;
                    }

                    

                    List<string> list = dico.ReadFile("MotsPossibles.txt", motentre.Length);
                    if (plat1.Test_Plateau(motentre) && dico.RechDichoRecursive(0, list.Count, motentre, list) && (J1.Mots.Contains(motentre)==false) && motentre.Length > 2 && motentre.Length <16 && motentre != null)
                    {
                        J1.Mots.Add(motentre);                       
                        Console.WriteLine( J1.Nom + " gagne "+Score(motentre) + " points grâce au mot " + motentre);

                        J1.Score += Score(motentre);
                    }
                    else
                    {
                        Console.WriteLine("\nLe mot n'a pas été validé !" + "\n");                       
                    }
                    Console.WriteLine("\nIl vous reste " + tamptime + " secondes de jeu.\n");
                    Console.WriteLine(plat1.toString());
                }




                Console.WriteLine("fin du tour du Joueur 1" + "\nScore de " + J1.Nom + " : " + J1.Score + "\nIl a trouvé les mots suivants : " + LireList<string>(J1.Mots));
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(J2.Nom + " c'est a votre Tour de jouer");
                Console.WriteLine("\nAppuyer sur Entrer pour continuer");
                Console.ReadLine();

                Plateau plat2 = new Plateau(CréerPlat());
                Console.WriteLine("\nVoici le plateau du Joueur 2");
                Console.WriteLine(plat2.toString());

                d = DateTime.Now;
                d2 = d - d;
                while (d2.Minutes < 1)  //phase de jeu Joueur 2
                {
                    //Jouer au jeu ici

                    Console.WriteLine("\nEntrer votre mot");
                    motentre = Console.ReadLine().ToUpper();

                    d1 = DateTime.Now;
                    d2 = d1 - d;
                    tamptime = 60 - d2.Seconds;

                    if (d2.Minutes == 1)
                    {
                        Console.WriteLine("\nLe temps limite à été dépassé, votre dernière entrée n'a pas été comptabilisée");
                        break;
                    }



                    List<string> list = dico.ReadFile("MotsPossibles.txt", motentre.Length);
                    if (plat2.Test_Plateau(motentre) && dico.RechDichoRecursive(0, list.Count, motentre, list) && (J2.Mots.Contains(motentre) == false) && motentre.Length > 2 && motentre.Length < 16 && motentre != null)
                    {
                        J2.Mots.Add(motentre);
                        Console.WriteLine(J2.Nom + " gagne " + Score(motentre) + " points grâce au mot " + motentre);

                        J2.Score += Score(motentre);
                    }
                    else
                    {
                        Console.WriteLine("\nLe mot n'a pas été validé !" + "\n");
                    }

                    Console.WriteLine("\nIl vous reste " + tamptime + " secondes de jeu.\n");
                    Console.WriteLine(plat2.toString());
                }

                Console.WriteLine("fin du tour du Joueur 2" + "\nScore de " + J2.Nom + " : " + J2.Score + "\nIl a trouvé les mots suivants : " + LireList<string>(J2.Mots));

            }

            Console.WriteLine("\nFin de la partie");


            if(J1.Score > J2.Score)
            {
                Console.WriteLine(J1.Nom + " à gagné la partie avec un score de " + J1.Score);
                Console.WriteLine("Il a trouvé les mots suivants : " + LireList<string>(J1.Mots));

                Console.WriteLine(J2.Nom + " a marqué " + J2.Score + " points, et à trouvé les mots suivants : " + LireList<string>(J2.Mots));
            }
            if (J2.Score > J1.Score)
            {
                Console.WriteLine(J2.Nom + " à gagné la partie avec un score de " + J2.Score);
                Console.WriteLine("Il a trouvé les mots suivants : " + LireList<string>(J2.Mots));

                Console.WriteLine(J1.Nom + " a marqué " + J1.Score + " points, et à trouvé les mots suivants : " + LireList<string>(J1.Mots));
            }

            if (J2.Score == J1.Score)
            {
                Console.WriteLine(J1.Nom + " et " + J2.Nom + " ont eu le même nombre de points. En effet vous avez marqué tous les deux " + J1.Score + ".\nIl y a donc égalité !");
                Console.WriteLine(J1.Nom + "à trouvé les mots suivants : " + LireList<string>(J1.Mots));
                Console.WriteLine(J2.Nom + "à trouvé les mots suivants : " + LireList<string>(J2.Mots));
            }
        }

        
        public static int Score(string mot)  //retourn le score du mot en fonction de sa longueur
        {
            
            switch (mot.Length)
            {
                case 3:
                    return 2;
                case 4:
                    return 3;
                    
                case 5:
                    return 4;
                    
                case 6:
                    return 5;
                    
                default:
                    return 11;
                    
            }
            
        }

    }
}
