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
    [SerializeField] private Animator animatorController;
    [SerializeField] private AudioSource footstepsAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;
    private float VelocityX;
    private Vector2 Movement;
    private Rigidbody2D RigidBody;
    private bool CanJump = true;

    private void Awake() => RigidBody=GetComponent<Rigidbody2D>();

    public void StopPlayer()
    {
        Speed = 0;
        JumpForce = 0;
    }
    private void Update()
    {
        Movement = InputHandler.Movement.ReadValue<Vector2>();
        UpdateFriction();
        VelocityX = Mathf.Lerp(VelocityX, Movement.x * Speed, 10 * Time.deltaTime);
        RigidBody.linearVelocityX = VelocityX;
        if (Movement.x.Equals(1))
            transform.eulerAngles = Vector3.zero;
        else if (Movement.x.Equals(-1))
            transform.eulerAngles = Vector3.up * 180;
        if (!footstepsAudioSource.isPlaying && Movement.x != 0)
                footstepsAudioSource.Play();
        animatorController.SetBool("isRunning", !Movement.x.Equals(0) && !Speed.Equals(0));
        if (InputHandler.Jump.WasPressedThisFrame() && Collider.IsTouchingLayers(Ground) && CanJump)
        {
            Jump();
            animatorController.SetTrigger("jump");
            if (!jumpAudioSource.isPlaying)
                jumpAudioSource.Play();
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
        Invoke(nameof(MayIJump), 0.3f);
    }

    private void MayIJump() => CanJump = true;
}
