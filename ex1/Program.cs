using System;

namespace ex1
{
    class Program
    {
       static void Main(string[] args)
        {
            var Game = new Game();
            Game.Play();

        }
    }

    public class Game
    {
        private readonly int valeurATrouver = new Random().Next(0, 100);
        private readonly int nombreDeCoupsMax = 10;
        int nombreDeCoups = 0;
        bool trouve = false;
        public void Play(){
            Console.WriteLine("Veuillez saisir un nombre compris entre 0 et 100 (exclu)");
            while (!trouve){
                string saisie = Console.ReadLine();
                int valeurSaisie;
                if (int.TryParse(saisie, out valeurSaisie)){
                   trouve = Verif(valeurSaisie);
                }else{
                    if(valeurSaisie == -1){
                        End(false);
                        break;
                    }else{
                     Console.WriteLine("La valeur saisie est incorrecte, veuillez recommencer ...");
                    }
                }
            }
            End(trouve);
        }

        public virtual bool Verif(int valeurSaisie){
            if(nombreDeCoups < nombreDeCoupsMax){
                if(valeurSaisie == valeurATrouver){
                    return true;
                }else{
                    if (valeurSaisie < valeurATrouver){
                        Console.WriteLine("Trop petit ...");
                    }else{
                        Console.WriteLine("Trop grand ...");
                    };
                    nombreDeCoups++;
                    return false;
                };
            }else{
                return true;
            }
        }

        public void End(bool success){
            if(success){
                Console.WriteLine("Vous avez trouvé en " + nombreDeCoups + " coup(s)");
                Console.ReadLine();
            }else{
                Console.WriteLine("Vous n'avez pas trouvé en moins de " + nombreDeCoupsMax + " coup(s)");
                Console.ReadLine();
            }
            Console.WriteLine("Fin du jeu");
        }

    }
}
