using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialougeSystem : MonoBehaviour
{
    [SerializeField] private DialougeSO[] dialougeSOs;
    [SerializeField] private TextMeshProUGUI dialougeText;
    [SerializeField] private Image dialougeBackground;
    private bool phraseEnded;

    private void Awake()
    {
        foreach(DialougeSO dialougeSO in dialougeSOs)
        {
            foreach(string phrase in dialougeSO.phrases)
            {
                StartCoroutine(TypeText("В далеком-далеком будущем, в **** году человечество вымерло. От чего, спросите вы меня? От деградации... На смену людям пришли шимпанзе, как самый разумный вид. Мы довольно хорошо обустроились, знаете ли. Исследовали большую часть Земли, некоторые даже науки стали изучать. Так мой рассказ медленно перетекает к нашему главному герою - шимпанзе по имени Допфит. Хоть лично мы с ним не были знакомы, я слышал кучу историй от других шимпанзе, которые общались с ним. Так, я здесь расскажу Вам историю о радужном мосту...  "));
                if (!phraseEnded) return;
            }
        }
        //StartCoroutine(TypeText("В далеком-далеком будущем, в **** году человечество вымерло. От чего, спросите вы меня? От деградации... На смену людям пришли шимпанзе, как самый разумный вид. Мы довольно хорошо обустроились, знаете ли. Исследовали большую часть Земли, некоторые даже науки стали изучать. Так мой рассказ медленно перетекает к нашему главному герою - шимпанзе по имени Допфит. Хоть лично мы с ним не были знакомы, я слышал кучу историй от других шимпанзе, которые общались с ним. Так, я здесь расскажу Вам историю о радужном мосту...  "));
    }

    private IEnumerator TypeText(string text)
    {
        phraseEnded = false;
        dialougeText.text = "";
        foreach(char c in text.ToCharArray())
        {
            dialougeText.text += c;
            yield return new WaitForSeconds(0.1f);
        }
        phraseEnded = true;
    }
}
