using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Projet_Bogle_Algorithme_A2
{
    public class Dictionnaire
    {




        /// <summary>
        /// Méthode qui permet de lire le fichier dictionnaire 
        /// </summary>
        /// <param name="fic"></param>
        /// <param name="nbLettre"></param>
        /// <returns></returns>
        public List<string> ReadFile(string fic, int nbLettre)
        {
            List<string> retour = new List<string>();
            StreamReader flux = null;

            try // essaye de lire le fichier
            {
                flux = new StreamReader(fic);
                string tampindex;
                string line;
                string tampon = "";

                if (nbLettre < 2 || nbLettre > 15)   //elimine les valeurs incorrectes
                {
                    Console.WriteLine("Le nombre de lettres entré est incorrect.");
                    return null;
                }

                while ((line = flux.ReadLine()) != null || retour.Count < 5)
                {

                    if (nbLettre <= 9)    //cas d'un nombre de lettre à un caractère (inférieur à 10)
                    {


                        if (Int32.TryParse(Convert.ToString(line[0]), out int sortie))      // On essaye de convertir le charctère en un int. C'est à dire le charctère doit être un chiffre pour etre converti.
                        {
                            if (sortie == nbLettre)    // on vérifie que le chiffre demandé (qui correspond à la longueur du mot qu'on veut vérifie s'il appartient au dictionnaire) soit égale au chiffre récupéré auparavant.
                            {
                                while ((line = flux.ReadLine()) != null)
                                {
                                    if (Int32.TryParse(Convert.ToString(line[0]), out int sorr)) // Si on arrive à une ligne ou le charactère peut devenir un int, on arrète la lecture
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < line.Length; i++) // Lecture ligne par ligne des mots en string dans le fichier qu'on ajoute dans une liste. Chaque mots sont espacés par un espace qui nous permet de séparer les mots.
                                        {
                                            if (line[i] == ' ')
                                            {
                                                retour.Add(tampon);

                                                tampon = "";
                                            }
                                            else
                                            {
                                                tampon += line[i];
                                            }
                                        }

                                        retour.Add(tampon);
                                        tampon = "";
                                    }
                                }
                            }
                        }

                    }
                    else         //cas ou le nombre chiffres dans le nombre de lettres cherché dépasse 10 ( 1 et 0 do'u 2 caractères)
                    {

                        if (Int32.TryParse(Convert.ToString(line[0]), out int sortie))      // On essaye de convertir le charctère en un int. C'est à dire le charctère doit être un chiffre pour etre converti.
                        {

                            if (sortie == 1)                                  //si la variable sortie est égale à 1, alors cela signifie que le stream à attenit le bloc des mots à 10 lettres (il n'y a pas de mots à 1 lettre)
                            {
                                tampindex = Convert.ToString(line[0]) + Convert.ToString(line[1]);  //ccomme nous avons atteint le 10, alors nous pouvons concaténer le 1 avec la valeur des unités qui suit ce 1.
                                sortie = Convert.ToInt32(tampindex);                            //en retransformant cela en int, nous récupérons le nombre de lettres du bloc qui suit. La démarche de test et copiage est Strictement identique a celle présentée plus haut (je l'ai copiée collée hihi)
                            }
                            else
                            {
                                sortie = 0;
                            }


                            if (sortie == nbLettre)    // on vérifie que le chiffre demandé (qui correspond à la longueur du mot qu'on veut vérifie s'il appartient au dictionnaire) soit égale au chiffre récupéré auparavant.
                            {
                                while ((line = flux.ReadLine()) != null)
                                {
                                    if (Int32.TryParse(Convert.ToString(line[0]), out int sorr)) // Si on arrive à une ligne ou le charactère peut devenir un int, on arrète la lecture
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < line.Length; i++) // Lecture ligne par ligne des mots en string dans le fichier qu'on ajoute dans une liste. Chaque mots sont espacés par un espace qui nous permet de séparer les mots.
                                        {
                                            if (line[i] == ' ')
                                            {
                                                retour.Add(tampon);

                                                tampon = "";
                                            }
                                            else
                                            {
                                                tampon += line[i];
                                            }
                                        }

                                        retour.Add(tampon);
                                        tampon = "";
                                    }
                                }
                            }
                        }

                    }


                }
                return retour;
            }
            catch (Exception e) // renvoie une exception
            {
                Console.WriteLine(e.Message); return null;

            }
            finally // A la fin de l'échange avec le fichier, on ferme le flux.
            {
                if (flux != null) { flux.Close(); }
            }
        }


        /// <summary>
        /// retourne une chaîne de caractères qui décrit le dictionnaire à savoir ici le nombre de mots par longueur et la langue
        /// </summary>
        /// <returns></returns>
        public string ToString(int longMot)
        {
            return "Le dictionnaire est en " + "Français " + "il comporte " + ReadFile("MotsPossibles.txt", longMot).Count + " mots contenant " + longMot + " lettres.";
        }

        ///// <summary>
        /////  Teste si le mot en paramètre appartient bien au tableau de mots de ce dictionnaire
        ///// </summary>
        ///// <returns></returns>
        //public bool RechDichoRecursif(int index, int fin, string mot, List<string> listmot)  //l'utilisation en signature d'une simple list de string, permet d'éviter la réutilisation du ReadFile du Dictionnaire qui est une fonction TRES TRES LOURDE. Elle ne sera utilisée qu'une seule fois a chaque recherche, dans la ligné précédant l'utilisation de la recherche.
        //{


        //    if (mot == listmot[index])  //Sortie 1 : Le mot est trouvé, on return true
        //    {

        //        return true;
        //    }
        //    if (index == fin)   //Sortie 2 : Le mot n'est pas trouvé, l'index arrive a la fin de la liste de mot. On return false
        //    {

        //        return false;
        //    }

        //    return RechDichoRecursif(++index, fin, mot, listmot);    //On return la meme fonction en incrémentant l'index, en mettant la fin à jour, avec les memes paramètres de mot recherché et de liste de mot



        //}

        /// <summary>
        /// Teste si le mot en paramètre appartient bien au tableau de mots de ce dictionnaire
        /// </summary>
        /// <param name="debut"></param> 
        /// <param name="fin"></param> la taille de départ de la liste en paramètre
        /// <param name="mot"></param> Le mot recherché
        /// <param name="listmot"></param> la list de mots en fonction de nombre de charactère de mot à étudier
        /// <returns></returns>
        public bool RechDichoRecursive( int debut, int fin,string mot, List<string> listmot)
        {
            int milieu = (debut + fin) / 2;           //nous prenons le millieu de l'intervalle considéré [début,fin]

            if(mot.Length <=1 || mot.Length >= 16) 
            {
                Console.WriteLine("Le nombre de caractère du mot entré est trop long ou trop court.");
                return false;
            }


            if (debut==milieu||fin==milieu)           //Si le millieu devient égal au début ou a la fin, cela signifie que la dichotomie est bloquée et va tourner a l'infini. Ce cas arrive lorsuqe le mot n'est pas dans la list. On return donc false
            {
                return false;
            }

            switch (String.Compare(mot, listmot[milieu]))         //on test si le mot du millieu est avant ou apres le mot que l'on cherche par aordre alphabétique (le liste est triée par ordre alphabétique)
            {
                case -1:                                             
                    return RechDichoRecursive(debut, milieu, mot, listmot);   //si le mot cherché est avant dans ll'aphabet, on réduit l'interval en supprimant la moitié ou il n'est pas présent. ICi on garde la première moitié de l'interval considéré
                    

                case 0:
                    return true;           //si le compare retourne, 0, on return true car le mot cherché à été trouvé
                    

                case 1:
                    return RechDichoRecursive(milieu, fin, mot, listmot);    //de même que le case -1:  sauf que l'on garde la 2e partie de l'intervalle
                
                default:
                    return false;
                   
            }

        }

        
    }
}
