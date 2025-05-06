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

    private void Awake() => StartCoroutine(ShowDialouge());

    private IEnumerator ShowDialouge()
    {
        foreach(DialougeSO dialougeSO in dialougeSOs)
        {
            dialougeBackground.sprite = dialougeSO.background;
            foreach(string phrase in dialougeSO.phrases)
            {
                yield return StartCoroutine(TypeText(phrase));
                yield return new WaitUntil(()=>InputHandler.Jump.WasReleasedThisFrame());
            }
        }
        afterDialouge?.Invoke();
    }
    private IEnumerator TypeText(string text)
    {
        dialougeText.text = null;
        foreach(char c in text.ToCharArray())
        {
            voiceAudioSource.PlayOneShot(TextSound);
            dialougeText.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
