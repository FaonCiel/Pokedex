using System;
using System.Collections.Generic;
using System.Threading;

namespace Pokedex
{
    public class ListePokemon
    {
        public int id { get; set; }
        public string url { get; set; }
        public int lastEdit { get; set; }

        List<Pokemon> AllPoke = new List<Pokemon>();

        List<Pokemon> ListeGen1 = new List<Pokemon>();
        List<Pokemon> ListeGen2 = new List<Pokemon>();
        List<Pokemon> ListeGen3 = new List<Pokemon>();
        List<Pokemon> ListeGen4 = new List<Pokemon>();
        List<Pokemon> ListeGen5 = new List<Pokemon>();
        List<Pokemon> ListeGen6 = new List<Pokemon>();
        List<Pokemon> ListeGen7 = new List<Pokemon>();
        List<Pokemon> ListeGen8 = new List<Pokemon>();

        
        public void initlistpokemon()
        {
            Thread Gen1 = new Thread(() => getPokebygen.getPoke(1, 151, ListeGen1));
            Thread Gen2 = new Thread(() => getPokebygen.getPoke(152, 251, ListeGen2));
            Thread Gen3 = new Thread(() => getPokebygen.getPoke(252, 386, ListeGen3));
            Thread Gen4 = new Thread(() => getPokebygen.getPoke(387, 493, ListeGen4));
            Thread Gen5 = new Thread(() => getPokebygen.getPoke(494, 649, ListeGen5));
            Thread Gen6 = new Thread(() => getPokebygen.getPoke(650, 721, ListeGen6));
            Thread Gen7 = new Thread(() => getPokebygen.getPoke(722, 802, ListeGen7));
            Thread Gen8 = new Thread(() => getPokebygen.getPoke(803, 898, ListeGen8));

            List<Thread> threads = new List<Thread>() { Gen1, Gen2, Gen3, Gen4, Gen5, Gen6, Gen7, Gen8 };

            foreach (Thread t in threads)
            {
                t.Start();
            }

            foreach (Thread t in threads)
            {
                t.Join();
            }
            

            AllPoke.AddRange(ListeGen1);
            AllPoke.AddRange(ListeGen2);
            AllPoke.AddRange(ListeGen3);
            AllPoke.AddRange(ListeGen4);
            AllPoke.AddRange(ListeGen5);
            AllPoke.AddRange(ListeGen6);
            AllPoke.AddRange(ListeGen7);
            AllPoke.AddRange(ListeGen8);
        }
        public void Affiche()
        {
            parcourirlaliste(AllPoke);
        }

      
        public void Affiche(int gen)
        {
            switch (gen)
            {
                case 1:
                    parcourirlaliste(ListeGen1);
                    break;
                case 2 :
                    parcourirlaliste(ListeGen2);
                    break;
                case 3 :
                    parcourirlaliste(ListeGen3);
                    break;
                case 4 :
                    parcourirlaliste(ListeGen4);
                    break;
                case 5 :
                    parcourirlaliste(ListeGen5);
                    break;
                case 6 :
                    parcourirlaliste(ListeGen6);
                    break;
                case 7 :
                    parcourirlaliste(ListeGen7);
                    break;
                case 8 :
                    parcourirlaliste(ListeGen8);
                    break;    
                default:
                    break;
            }

        }
        public void Affiche(string type)
        {
            for (int i = 0; i < AllPoke.Count; i++)
            {
                foreach (string typePoke in AllPoke[i].types)
                {
                    if (typePoke == type)
                    {
                        AllPoke[i].getgen(AllPoke[i].id);
                        Console.WriteLine("id  : " + AllPoke[i].id);
                        Console.WriteLine("nom : " + AllPoke[i].name.fr);
                    }
                }
            }

        }

       
    
        public void parcourirlaliste(List<Pokemon> Gen)
        {
            for (int i = 0; i < Gen.Count; i++)
            {
                AllPoke[i].getgen(Gen[i].id);
                Console.WriteLine("id  : " + Gen[i].id);
                Console.WriteLine("nom : " + Gen[i].name.fr);
            }
        }

        public void MoyennePoids(string type)
        {
            Double poids = 0.0;
            int nbpkmn=0;
            for (int i = 0; i < AllPoke.Count; i++)
            {
                foreach (string typePoke in AllPoke[i].types)
                {
                    if (typePoke == type)
                    {
                        poids = poids + AllPoke[i].weight;
                        nbpkmn++;
                    }
                }               
            }
            Console.WriteLine("La moyene du poids des pokemons de type : " + type + " est " + poids / nbpkmn);
        }
    }
}
