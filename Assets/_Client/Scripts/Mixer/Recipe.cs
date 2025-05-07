using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Alchemy/Recipe")]
public class Recipe : ScriptableObject
{
    public string ingredient1;
    public string ingredient2;
    public string resultName;
    public Sprite resultIcon;
}
