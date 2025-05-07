using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<string> collectedIngredients = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddIngredient(string ingredient)
    {
        if (!collectedIngredients.Contains(ingredient))
            collectedIngredients.Add(ingredient);
    }
}

