using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPechesPapa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estimation d'une population par la méthode de Carle et Strub.");

            //Nom pêche
            Console.WriteLine("Nom du site de pêche :");
            string site_peche = Console.ReadLine();
            //Date pêche
            Console.WriteLine("Date de la pêche :");
            string date_peche = Console.ReadLine();
            //Surface
            Console.WriteLine("Surface échantillonnée en m2 :");
            int surface_echantillonnee = Convert.ToInt32(Console.ReadLine());
            //Espèce
            Console.WriteLine("Quelle est l'espèce étudiée :");
            string espece = Console.ReadLine();
            //Nombre de pêches
            Console.WriteLine("Combien de pêches successives :");
            int nb_peche = Convert.ToInt32(Console.ReadLine());

            //Stat par pêche
            Console.WriteLine("Tapez le nombre de poissons capturés à chaque pêche :" + nb_peche);
            int[] captures = new int[nb_peche];
            int total_poisson = 0;
            int surface_calcul = 0;
            int iteration = 0;

            for(int cpt=1; cpt <= nb_peche; cpt++)
            {
                captures[cpt - 1] = Convert.ToInt32(Console.ReadLine());
                total_poisson = total_poisson + captures[cpt - 1];
                surface_calcul = surface_calcul + (nb_peche - cpt) * captures[cpt - 1];
            }

            Console.WriteLine("Solution de l'équation de Carle et Strub");

            for(int cpt = total_poisson; cpt <= 10000; cpt++)
            {
                float u = 1;

                for(int cpt2 = 1; cpt2 <= nb_peche; cpt2++)
                {
                    u = u * (((nb_peche * cpt) - surface_calcul - total_poisson + 1 + (nb_peche - cpt2)) / ((nb_peche * cpt) - surface_calcul + 2 + (nb_peche - cpt2)));
                    Console.WriteLine(u);
                }

                u = (cpt + 1) * u / (cpt - total_poisson + 1);

                if (u < 1)
                {
                    iteration = cpt;
                    break;
                }     
            }

            Console.WriteLine("u<1 à l'itération numéro " + iteration);

            float d = total_poisson / (nb_peche * iteration - surface_calcul);
            float q1 = 1 - d;
            double e = 2 * Math.Sqrt(iteration * (iteration - total_poisson) * total_poisson / ((total_poisson * total_poisson) - iteration * (iteration + total_poisson) * ((nb_peche * d) * (nb_peche * d)) / q1));

            Console.WriteLine("RESULTATS");

            Console.WriteLine("Blabla" + d);

            Console.WriteLine("Espece de poisson étudié : " + espece);
            Console.WriteLine("Nombre de poissons capturés à chaque pêche : ");
            foreach(int capture in captures)
            {
                Console.WriteLine("            " + capture);
            }

            Console.WriteLine("Aire totale échantillonnée en m2 : " + surface_echantillonnee);
            Console.WriteLine("Nombre de pêches successives : " + nb_peche);
            Console.WriteLine("Total des poissons capturés : " + total_poisson);
            Console.WriteLine("Densité minimum par m2 : " + total_poisson/surface_echantillonnee);
            Console.WriteLine("Estimation par la méthode de Carle et Strub: N = " + iteration);
            Console.WriteLine("Intervalle de confiance a 5% : " + e);
            Console.WriteLine("Densité estimée au m2 : " + iteration/surface_echantillonnee);
            Console.WriteLine("Intervalle de confiance de la densité a 5% : " + e/surface_echantillonnee);

            Console.WriteLine("Press enter for close...");
            Console.ReadLine();
        }
    }
}
