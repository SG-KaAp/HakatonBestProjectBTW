using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DialougeSO", menuName = "DialougeSystem/DialougeSO", order = 1)]
public class DialougeSO : ScriptableObject
{
    public Sprite background;
    public List<string> phrases;
}
