using Revisione.Scripts.Crafting;
using UnityEngine;

namespace Revisione.Scripts.Agents
{
    public class CrafterAgent : MonoBehaviour
    {
        public Recipe Recipe;

        private void SetRecipe(Recipe recipe)
        {
            Recipe = recipe;
        }

        private void Start()
        {
            var buttons = FindObjectsByType<RecipeButton>(FindObjectsSortMode.None);

            foreach (var button in buttons)
            {
                button.OnRecipeSelected += SetRecipe;
            }
        }

        public void ExerciseInPseudoCode()
        {
            /* Creare una sola custom action nel BehaviourTree del CrafterAgent alla quale passare una stringa
             * per fare il check sulla CraftingBenchStatus per la quantità del materiale specificato nella stringa.
             * 
             * In Start() il CrafterAgent si iscrive ad una public event Action di ogni button, che passa la propria
             * Recipe, con il metodo -private void SetRecipe(Recipe recipe)-, che semplicemente setta la propria Recipe
             * a quella passata dall'evento del button.
             *
             * Una volta settata la current Recipe sia alla bench sia al Crafter, il crafter si occupa di fare un check
             * sul primo dei materiali richiesti dalla current Recipe. Se il materiale è richiesto in quantità '0',
             * il nodo che fa il check torna Faliure e si passa al prossimo nodo con il prossimo materiale. Se invece il
             * materiale è richiesto in quantità 1 o più, si fa il check della CraftingBench per vedere se quel materiale
             * è già presente nella quantità richiesta dalla Recipe. Se lo è, il crafter fa un check per vedere se tutti
             *  i materiali sono presenti nella quantità richiesta. Se lo sono, il crafter "Crafta" il materiale davanti
             * alla CraftingBench per X secondi, poi lo porta al deposito e torna in attesa della proissima Recipe.
             * Altrimenti passa al prossimo materiale.
             * Se il prossimo materiale non è presente in quantità richiesta, il Crafter richiede la location della
             * stazione che dispensa il materiale, vi si reca,lo recupera e lo porta alla CraftingStation. 
             * 
             */
        }
    }
}