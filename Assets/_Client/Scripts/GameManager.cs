using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Flask[] flasks;
    [SerializeField] private Color[] baseColors;

    private Flask selectedFlask = null;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InitFlasks();
    }

    void InitFlasks()
    {
        // Пример инициализации
        int colorIndex = 0;
        for (int i = 0; i < flasks.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Color color = baseColors[colorIndex % baseColors.Length];
                flasks[i].AddLayer(color);
                colorIndex++;
            }
        }
    }

    public void OnFlaskClicked(Flask clicked)
    {
        if (selectedFlask == null)
        {
            if (!clicked.IsEmpty)
                selectedFlask = clicked;
        }
        else
        {
            if (clicked != selectedFlask)
            {
                selectedFlask.PourTo(clicked);
            }

            selectedFlask = null;
        }
    }
}

