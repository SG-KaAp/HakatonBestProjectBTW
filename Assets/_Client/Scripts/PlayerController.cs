using UnityEngine;
using Game.Input;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D Collider;
    [SerializeField] private float Speed = 10;
    private Vector2 Velocity;
    private Rigidbody2D Rigidbody;
    private void Awake() => Rigidbody = gameObject.GetComponent<Rigidbody2D>();
    void Update()
    {
        Velocity = InputHandler.Movement.ReadValue<Vector2>();
        Rigidbody.linearVelocity = Velocity * Speed;
        if(Velocity.x > 0)
            Rigidbody.rotation = 90;
        else if (Velocity.x < 0)
            Rigidbody.rotation = -90;
    }
}
