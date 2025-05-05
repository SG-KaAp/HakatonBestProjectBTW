using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DialougeSO", menuName = "DialougeSystem/DialougeSO", order = 1)]
public class DialougeSO : ScriptableObject
{
    public Image background;
    public string[] phrases;
}
