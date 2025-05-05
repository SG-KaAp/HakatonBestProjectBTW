using UnityEngine;
using Game.Input;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 10;
    [SerializeField] private float JumpForce = 2;
    private float VelocityX;
    private Vector2 Movement;
    private bool IsGrounded;
    private Rigidbody2D RigidBody;
    private void Awake()=>RigidBody=GetComponent<Rigidbody2D>();
    private void Update()
    {
        Movement=InputHandler.Movement.ReadValue<Vector2>();
        VelocityX=Mathf.Lerp(VelocityX,Movement.x*Speed,10*Time.deltaTime);
        RigidBody.linearVelocityX=VelocityX;
        RigidBody.rotation=Movement.x.Equals(1)?90:-90;
        if(InputHandler.Jump.IsPressed()&&IsGrounded)Jump();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
    }
    private void Jump()
    {   
        IsGrounded = false;
        RigidBody.linearVelocity += JumpForce * Vector2.up;
    }
}
