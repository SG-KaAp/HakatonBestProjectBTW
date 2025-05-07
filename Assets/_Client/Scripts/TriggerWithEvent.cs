using UnityEngine;
using UnityEngine.Events;
public class TriggerWithEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent EventToInvoke;
    [SerializeField] private PlayerController Player;
    [SerializeField] private DarkDirector Dark;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dark.Dark();
        Player.StopPlayer();
        Invoke(nameof(StartEvent),1);
    }
    private void StartEvent() => EventToInvoke.Invoke();
}
