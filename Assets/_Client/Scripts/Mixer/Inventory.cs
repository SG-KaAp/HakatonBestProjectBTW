using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<string> collectedIngredients = new();

    public void AddIngredient(string ingredient)
    {
        if (!collectedIngredients.Contains(ingredient))
            collectedIngredients.Add(ingredient);
    }
}
