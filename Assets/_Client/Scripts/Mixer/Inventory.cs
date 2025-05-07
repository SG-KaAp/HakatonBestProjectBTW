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
            DontDestroyOnLoad(gameObject); // сохраняем объект при смене сцены
        }
        else
        {
            Destroy(gameObject); // защищаем от дубликатов
        }
    }

    public void AddIngredient(string ingredient)
    {
        if (!collectedIngredients.Contains(ingredient))
            collectedIngredients.Add(ingredient);
    }
}
