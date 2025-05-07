using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Mixer : MonoBehaviour
{
    public GameObject ingredientButtonPrefab;
    public Transform ingredientButtonContainer;
    public TextMeshProUGUI resultText;
    public Button mixButton;
    public GameObject resultPanel;
    public GameObject mixedPanel;
    public Image resultImage;
    public Button continueButton;

    private string createdMixtureName = "";
    private Sprite createdMixtureIcon = null;
    private string selectedIngredient1 = null;
    private string selectedIngredient2 = null;

    public List<Recipe> recipeList;

    private readonly Dictionary<(string, string), string> recipes = new()
    {
        { ("Fire", "Water"), "Steam" },
        { ("Leaf", "Water"), "Potion" },
        { ("Stone", "Fire"), "Lava" }
    };

    void Start()
    {
        mixButton.interactable = false;
        GenerateIngredientButtons();
        mixButton.onClick.AddListener(MixIngredients);
    }

    void GenerateIngredientButtons()
    {
        foreach (Transform child in ingredientButtonContainer)
            Destroy(child.gameObject);

        foreach (string ingredient in Inventory.Instance.collectedIngredients)
        {
            GameObject btnObj = Instantiate(ingredientButtonPrefab, ingredientButtonContainer);
            TextMeshProUGUI btnText = btnObj.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = ingredient;

            Button btn = btnObj.GetComponent<Button>();
            btn.onClick.AddListener(() => OnIngredientSelected(ingredient, btn));
        }
    }

    void OnIngredientSelected(string ingredient, Button btn)
    {
        if (ingredient == selectedIngredient1)
        {
            selectedIngredient1 = null;
            btn.image.color = Color.white;
        }
        else if (ingredient == selectedIngredient2)
        {
            selectedIngredient2 = null;
            btn.image.color = Color.white;
        }
        else if (selectedIngredient1 == null)
        {
            selectedIngredient1 = ingredient;
            btn.image.color = Color.green;
        }
        else if (selectedIngredient2 == null)
        {
            selectedIngredient2 = ingredient;
            btn.image.color = Color.green;
        }

        mixButton.interactable = (selectedIngredient1 != null && selectedIngredient2 != null);
    }

    public void MixIngredients()
    {
        if (selectedIngredient1 == null || selectedIngredient2 == null)
            return;

        if (TryGetMixResult(selectedIngredient1, selectedIngredient2, out string result, out Sprite icon))
        {
            createdMixtureName = result;
            createdMixtureIcon = icon;

            ShowResultPanel();
        }
        else
        {
            resultText.text = "Нельзя изготовить";
            resultImage.sprite = null;
            resultPanel.SetActive(true);

            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                resultPanel.SetActive(false);
            });
        }
    }

    void ShowResultPanel()
    {
        resultText.text = "Ты получил: " + createdMixtureName;

        if (resultImage != null && createdMixtureIcon != null)
            resultImage.sprite = createdMixtureIcon;

        resultPanel.SetActive(true);
        mixedPanel.SetActive(false);

        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(() =>
        {
            Inventory.Instance.collectedIngredients.Add(createdMixtureName);
            SceneManager.LoadScene("Level1");
        });
    }

    bool TryGetMixResult(string a, string b, out string result, out Sprite icon)
    {
        foreach (var recipe in recipeList)
        {
            bool match = (recipe.ingredient1 == a && recipe.ingredient2 == b) ||
                         (recipe.ingredient1 == b && recipe.ingredient2 == a);

            if (match)
            {
                result = recipe.resultName;
                icon = recipe.resultIcon;
                return true;
            }
        }

        result = null;
        icon = null;
        return false;
    }


    Sprite GetMixtureIcon(string mixtureName)
    {
        return null;
    }
}


