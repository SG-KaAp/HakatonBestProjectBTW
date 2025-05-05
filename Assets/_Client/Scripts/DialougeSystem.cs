using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private DialougeSO[] dialougeSOs;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private Image dialougeBackground;
    [SerializeField] private AudioSource voiceAudioSource;
    [SerializeField] private UnityEvent afterDialouge;

    private void Awake()
    {
        StartCoroutine(ShowDialouge());
    }

    private IEnumerator ShowDialouge()
    {
        foreach(DialougeSO dialougeSO in dialougeSOs)
        {
            dialougeBackground.sprite = dialougeSO.background;
            foreach(string phrase in dialougeSO.phrases)
            {
                yield return StartCoroutine(TypeText(phrase));
            }
        }
        afterDialouge?.Invoke();
    }
    private IEnumerator TypeText(string text)
    {
        dialougeText.text = "";
        foreach(char c in text.ToCharArray())
        {
            voiceAudioSource.Play();
            dialougeText.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
