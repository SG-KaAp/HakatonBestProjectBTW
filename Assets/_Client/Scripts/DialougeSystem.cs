using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private DialougeSO[] dialougeSOs;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private Image dialougeBackground;

    private void Awake()
    {
        StartCoroutine(ShowDialouge());
    }

    private IEnumerator ShowDialouge()
    {
        foreach(DialougeSO dialougeSO in dialougeSOs)
        {
            foreach(string phrase in dialougeSO.phrases)
            {
                yield return StartCoroutine(TypeText(phrase));
            }
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialougeText.text = "";
        foreach(char c in text.ToCharArray())
        {
            dialougeText.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
