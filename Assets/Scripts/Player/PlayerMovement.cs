using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction move;
    private InputAction jump;
    Vector2 horizontalMovement;
    [Header("Movement floats")]
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField] float moveSpeed = 3f;
    [Header("Player Component referencer")]
    Rigidbody2D playerRB;
    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        playerRB = GetComponent<Rigidbody2D>();
        move.Enable();
        jump.Enable();
        jump.performed += Jump;
        jump.canceled += Jump;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }
    void Move()
    {
        float horizontalMovement = move.ReadValue<Vector2>().x;
        playerRB.linearVelocity = new Vector2(horizontalMovement * moveSpeed, playerRB.linearVelocity.y);

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpForce);
            SoundEffectManager.Play("Jump", true);
        }
        else if (context.canceled && playerRB.linearVelocity.y > 0)
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, playerRB.linearVelocity.y * 0.3f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    } 
}
