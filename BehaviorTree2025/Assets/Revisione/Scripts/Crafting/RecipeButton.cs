using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Revisione.Scripts.Crafting
{
    [RequireComponent(typeof(Button))]
    public class RecipeButton : MonoBehaviour
    {
        [SerializeField]
        private Recipe _recipe;

        private Button _button;
        private TMP_Text _text;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);

            _text = GetComponentInChildren<TMP_Text>();
            _text.text = _recipe.ToText();

            CraftingBenchStatus.CurrentRecipe = null;
        }

        private void OnClick()
        {
            if (CraftingBenchStatus.CurrentRecipe != null)
            {
                return;
            }

            CraftingBenchStatus.CurrentRecipe = _recipe;
        }
    }

    [System.Serializable]
    public class Recipe
    {
        public string Name = "Recipe";
        public int WoodRequired = 0;
        public int MetalRequired = 0;
        public int ClotRequired = 0;

        public string ToText()
        {
            return $"{Name}\n{WoodRequired}W-{MetalRequired}M-{ClotRequired}C";;
        }
    }
}