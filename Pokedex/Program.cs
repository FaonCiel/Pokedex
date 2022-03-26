using System;
using System.Text.Json;
using System.Net;
using System.Collections.Generic;
using System.Threading;

namespace Pokedex
{
    class Program
    {
       public static ListePokemon Pokedex;
        static void Main(string[] args)
        {
            Pokedex = new ListePokemon();
            Pokedex.initlistpokemon();
            Menu();
           
            /*
            WebClient webclient = new WebClient();
            string liste = webclient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons");
            List<ListePokemon> listedepokemon = JsonSerializer.Deserialize<List<ListePokemon>>(liste);
             //Console.WriteLine(AllPoke.Count);
            */
        }

        public static void Menu()
        {
            int choix;
            do
            {
                Console.WriteLine("Que voulez vous faire ?");
                Console.WriteLine("1. Afficher la liste des Pokémons : Numéro et nom ");
                Console.WriteLine("2. Afficher un Pokémons de chaque type pour chaque génération");
                Console.WriteLine("3. Afficher tous les Pokemons d'un type (au choix)");
                Console.WriteLine("4. Afficher tous les Pokémons de la génération 3");
                Console.WriteLine("5. Afficher la moyenne des poids des Pokémons de type Acier");
                Console.WriteLine("6. Retrouver un Pokémon avec son nom");
                Console.WriteLine("7. Retrouver un Pokémon avec son id");
                Console.WriteLine("0. Quitter");

                choix = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choix)
                {
                    case 1:
                        Pokedex.Affiche();
                        break;
                    case 2:
                        Pokedex.AffichePokemonChaqueType();
                        break;
                    case 3:
                        Pokedex.Affiche("Steel");
                        break;
                    case 4:
                        Pokedex.Affiche(3);
                        break;
                    case 5:
                        Pokedex.MoyennePoids("Steel");
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        return;
                    default:
                        break;
                }
            }
            while (true);
    
        }
    }
}
