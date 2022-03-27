using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;

namespace Pokedex
{
    class getPokebygen
    {
        public static void getPoke(int idstart, int idend,List<Pokemon>listPoke)
        {
            WebClient webclient = new WebClient(); // on instancie un webclient pour récupérer les données de l'API

            for (int i = idstart; i <= idend; i++) //on boucle du début de la génréation jusqua sa fin pour récupérer les donnée de l'API
            {

                string json = webclient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + i); // on récupère le json de chaque pokemon 

                Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json); // on converti le json en objet pokemon a l'aide du jsonSerializer

                listPoke.Add(pokemon);// on ajoute le pokemon a la liste 

            }


        }


    }
}
