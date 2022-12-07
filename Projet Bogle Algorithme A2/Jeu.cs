using System;
using System.Collections.Generic;
using System.Text;


namespace Projet_Bogle_Algorithme_A2
{
	class Jeu
	{
		Dictionnaire[] mondico;
		Plateau monplateau;

		public Dictionnaire[] Mondico
		{
			get { return this.mondico; }
		}
		public Plateau Monplateau
		{
			get { return this.monplateau; }
		}

		public Jeu(Dictionnaire[] mondico , Plateau monplateau)
		{
			this.mondico = mondico;
			this.monplateau = monplateau;
		}
	}
}
