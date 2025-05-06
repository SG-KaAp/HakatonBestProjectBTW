using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Game.Input;
public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private DialougeSO[] dialougeSOs;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private Image dialougeBackground;
    [SerializeField] private AudioSource voiceAudioSource;
    [SerializeField] private UnityEvent afterDialouge;
    [SerializeField] private AudioClip TextSound;
    private bool isTyping;
    private string currentText;

    private void Awake() => StartCoroutine(ShowDialouge());

    private IEnumerator ShowDialouge()
    {
        foreach(DialougeSO dialougeSO in dialougeSOs)
        {
            dialougeBackground.sprite = dialougeSO.background;
            foreach(string phrase in dialougeSO.phrases)
            {
                currentText = phrase;
                yield return StartCoroutine(TypeText(phrase));
                yield return new WaitUntil(()=>InputHandler.Jump.WasReleasedThisFrame() && !isTyping);
            }
        }
        afterDialouge?.Invoke();
    }
    private IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialougeText.text = null;
        foreach(char c in text.ToCharArray())
        {
            voiceAudioSource.Play();
            dialougeText.text += c;
            yield return new WaitForSeconds(0.1f);
        }
        isTyping = false;
    }
}
