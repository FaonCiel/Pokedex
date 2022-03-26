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

        List<Pokemon> AllPoke = new List<Pokemon>(); //instancie la liste de tous les pokemons

        List<Pokemon> ListeGen1 = new List<Pokemon>(); //instancie la liste des pokemons de gen 1
        List<Pokemon> ListeGen2 = new List<Pokemon>(); //instancie la liste des pokemons de gen 2
        List<Pokemon> ListeGen3 = new List<Pokemon>(); //instancie la liste des pokemons de gen 3
        List<Pokemon> ListeGen4 = new List<Pokemon>(); //instancie la liste des pokemons de gen 4
        List<Pokemon> ListeGen5 = new List<Pokemon>(); //instancie la liste des pokemons de gen 5
        List<Pokemon> ListeGen6 = new List<Pokemon>(); //instancie la liste des pokemons de gen 6
        List<Pokemon> ListeGen7 = new List<Pokemon>(); //instancie la liste des pokemons de gen 7
        List<Pokemon> ListeGen8 = new List<Pokemon>(); //instancie la liste des pokemons de gen 8

       List<List<Pokemon>> ListePoke;

        public void initlistpokemon()
        {
            Thread Gen1 = new Thread(() => getPokebygen.getPoke(1, 151, ListeGen1)); //Récupére la premiere génération de pokemon allant de 1 a 151
            Thread Gen2 = new Thread(() => getPokebygen.getPoke(152, 251, ListeGen2)); //Récupére la deuxième génération de pokemon allant de 152 a 251
            Thread Gen3 = new Thread(() => getPokebygen.getPoke(252, 386, ListeGen3)); //Récupére la troisième génération de pokemon allant de 252 a 386
            Thread Gen4 = new Thread(() => getPokebygen.getPoke(387, 493, ListeGen4)); //Récupére la quatrième génération de pokemon allant de 387 a 493
            Thread Gen5 = new Thread(() => getPokebygen.getPoke(494, 649, ListeGen5)); //Récupére la cinquième génération de pokemon allant de 494 a 649
            Thread Gen6 = new Thread(() => getPokebygen.getPoke(650, 721, ListeGen6)); //Récupére la sixième génération de pokemon allant de 650 a 721
            Thread Gen7 = new Thread(() => getPokebygen.getPoke(722, 802, ListeGen7)); //Récupére la septième génération de pokemon allant de 722 a 802
            Thread Gen8 = new Thread(() => getPokebygen.getPoke(803, 898, ListeGen8)); //Récupére la huitième génération de pokemon allant de 803 a 898

            List<Thread> threads = new List<Thread>() { Gen1, Gen2, Gen3, Gen4, Gen5, Gen6, Gen7, Gen8 }; //On fais une liste de thread pour simplifier le code

            foreach (Thread t in threads)
            {
                t.Start(); // on lance chaque thread
            }

            foreach (Thread t in threads)
            {
                t.Join(); // on attend que chaque thread se termine
            }
            
            ListePoke = new List<List<Pokemon>>() { ListeGen1, ListeGen2, ListeGen3, ListeGen4, ListeGen5, ListeGen6, ListeGen7, ListeGen8 }; //On fais une liste de liste de pokemon pour simplifier le code
        
           foreach (List<Pokemon> list in ListePoke)
            {
                 int i = 0;
                 AllPoke.AddRange(list); //on ajoute tous les pokemons de chaque génération dans la liste AllPoke
                 i++;
            }   
        }
        public void Affiche() //Affiche tous les pokemons
        {
            parcourirlaliste(AllPoke); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons
        }

      
        public void Affiche(int gen) // Affiche les pokemons d'une génération passer en paramettre 
        {
            switch (gen)                
            {
                case 1:
                    parcourirlaliste(ListeGen1); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la premiere génération
                    break;
                case 2 :
                    parcourirlaliste(ListeGen2); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la deuxième génération
                    break;
                case 3 :
                    parcourirlaliste(ListeGen3); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la troisième génération
                    break;
                case 4 :
                    parcourirlaliste(ListeGen4); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la quatrième génération
                    break;
                case 5 :
                    parcourirlaliste(ListeGen5); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la cinquième génération
                    break;
                case 6 :
                    parcourirlaliste(ListeGen6); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la sixième génération
                    break;
                case 7 :
                    parcourirlaliste(ListeGen7); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la septième génération
                    break;
                case 8 :
                    parcourirlaliste(ListeGen8); // on fais appel a la fonction parcourir la liste en lui passant notre liste de tous les pokemons de la huitième génération
                    break;    
                default:
                   Console.WriteLine("Erreur");
                    break;
            }

        }
        public void Affiche(string type)
        {
            for (int i = 0; i < AllPoke.Count; i++) // on parcour la liste de tous les pokemons
            {
                foreach (string typePoke in AllPoke[i].types) 
                {
                    if (typePoke == type)
                    {
                        AllPoke[i].getgen(AllPoke[i].id);
                        Console.WriteLine("id  : " + AllPoke[i].id);
                        Console.WriteLine("nom : " + AllPoke[i].name.fr);
                        Console.WriteLine("type :" + type);
                    }
                }
            }

        }

        
        public void parcourirlaliste(List<Pokemon> Liste)
        {  
            for (int i = 0; i < Liste.Count; i++)
            {
                AllPoke[i].getgen(Liste[i].id);
                Console.WriteLine("id  : " + Liste[i].id);
                Console.WriteLine("nom : " + Liste[i].name.fr);
            }
            
        }

        //Donne la Moyenne des poids des pokemons d'un type donné

        public void MoyennePoids(string type)
        {
            double moyenne = 0;
            int nb = 0;
            for (int i = 0; i < AllPoke.Count; i++)
            {
                foreach (string typePoke in AllPoke[i].types)
                {
                    if (typePoke == type)
                    {
                        moyenne += AllPoke[i].weight;
                        nb++;
                    }
                }
            }
            moyenne = moyenne / nb;
            Console.WriteLine("La moyenne des poids des pokemons de type " + type + " est de " + moyenne);

        }
        public void AffichePokemonChaqueType(){
            List<string> ListeType= new List<string>();
            {
              foreach(List<Pokemon> list in ListePoke)
              {
                    foreach (Pokemon poke in list)
                    {
                        int i = 0;
                        poke.getgen(AllPoke[i].id);
                        i++;
                        foreach (string type in poke.types)
                        {
                            if (!ListeType.Contains(type))
                            {
                                ListeType.Add(type);
                                Console.WriteLine(poke.name.fr);
                                Console.WriteLine(poke.gen);
                                Console.WriteLine(type);
                                
                            }
                        }
                    
                    }
                ListeType.Clear();
              }
                
            }
        
        }
    }
}




       
    
    
    

