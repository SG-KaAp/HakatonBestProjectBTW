using UnityEngine;

public class LiquidLayer : MonoBehaviour
{
     public Color liquidColor;

    public void SetColor(Color color)
    {
        liquidColor = color;
        GetComponent<SpriteRenderer>().color = color;
    }
}

