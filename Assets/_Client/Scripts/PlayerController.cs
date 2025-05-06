using UnityEngine;
using Game.Input;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 10;
    [SerializeField] private float JumpForce = 2;
    [SerializeField] private Collider2D Collider;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private LayerMask Walls;
    [SerializeField] private PhysicsMaterial2D WallsMaterial;
    private float VelocityX;
    private Vector2 Movement;
    private Rigidbody2D RigidBody;
    private bool CanJump = true;

    private void Awake() => RigidBody=GetComponent<Rigidbody2D>();

    private void Update()
    {
        Movement = InputHandler.Movement.ReadValue<Vector2>();
        VelocityX = Mathf.Lerp(VelocityX, Movement.x * Speed, 10 * Time.deltaTime);
        RigidBody.linearVelocityX = VelocityX;
        if (Movement.x.Equals(1))
            transform.eulerAngles = Vector3.zero;
        else if (Movement.x.Equals(-1))
            transform.eulerAngles = Vector3.up * 180;
        if (InputHandler.Jump.WasPressedThisFrame() && Collider.IsTouchingLayers(Ground) && CanJump)
        {
            Jump();
        }
    }

    private void UpdateFriction()
    {
        Collider.sharedMaterial = Collider.IsTouchingLayers(Walls) ? WallsMaterial : null;
    }

    private void Jump()
    {   
        CanJump = false;
        RigidBody.linearVelocity += JumpForce * Vector2.up;
        Invoke(nameof(MayIJump), 0.25f);
    }

    private void MayIJump() => CanJump = true;
}
