using UnityEngine;
using UnityEngine.EventSystems;

namespace _Client.UI.Menu
{
    public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
    {
        [SerializeField] private AudioSource pointerEnterSoundEvent;
        [SerializeField] private AudioSource pointerClickSoundEvent;

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerEnterSoundEvent.Play();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            pointerClickSoundEvent.Play();
        }
    }
}