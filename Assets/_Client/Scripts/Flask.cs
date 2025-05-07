using DG.Tweening.Core.Easing;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    [SerializeField] private Transform[] layerPositions; // позиции слоёв сверху вниз
    [SerializeField] private GameObject layerPrefab;
    [SerializeField] private int maxLayers = 4;

    private Stack<LiquidLayer> layers = new Stack<LiquidLayer>();

    public bool IsFull => layers.Count >= maxLayers;
    public bool IsEmpty => layers.Count == 0;
    public int CurrentCount => layers.Count;

    public Color? TopColor()
    {
        return IsEmpty ? (Color?)null : layers.Peek().liquidColor;
    }

    public bool CanPourInto(Flask target)
    {
        if (this.IsEmpty || target.IsFull) return false;

        Color? topFrom = this.TopColor();
        Color? topTo = target.TopColor();

        return target.IsEmpty || topFrom == topTo;
    }

    public void PourTo(Flask target)
    {
        if (!CanPourInto(target)) return;

        LiquidLayer topLayer = layers.Pop();
        target.AddLayer(topLayer.liquidColor);
        Destroy(topLayer.gameObject);
    }

    public void AddLayer(Color color)
    {
        if (IsFull) return;

        GameObject layerGO = Instantiate(layerPrefab, layerPositions[layers.Count].position, Quaternion.identity, transform);
        LiquidLayer newLayer = layerGO.GetComponent<LiquidLayer>();
        newLayer.SetColor(color);
        layers.Push(newLayer);
    }

    void OnMouseDown()
    {
        GameManager.Instance.OnFlaskClicked(this);
    }
}

