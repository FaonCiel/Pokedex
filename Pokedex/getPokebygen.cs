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
            WebClient webclient = new WebClient();

            for (int i = idstart; i <= idend; i++)
            {

                string json = webclient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + i);

                Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                listPoke.Add(pokemon);

            }


        }


    }
}
