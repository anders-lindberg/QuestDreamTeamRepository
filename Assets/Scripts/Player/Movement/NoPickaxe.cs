using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoPickaxe : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private InputAction move;
    private InputAction jump;
    public InputActionAsset playerActions;
    public Animator animator;


    public Vector2 horizontalMovement;
    
    [Header("Movement floats")]
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField] float moveSpeed = 3f;
    
    
    [Header("Player Component referencer")]
    private Rigidbody2D playerRB;
    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    
    public void Move()
    {
        float horizontalMovement = move.ReadValue<Vector2>().x;
        playerRB.linearVelocity = new Vector2(horizontalMovement * moveSpeed, playerRB.linearVelocity.y);
        if (horizontalMovement != 0)
        {
            spriteRenderer.flipX = horizontalMovement < 0;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        animator.SetBool("IsJumping", !IsGrounded());
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.y, jumpForce);
        }
        else if (context.canceled && playerRB.linearVelocity.y > 0)
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, playerRB.linearVelocity.y * 0.6f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    } 

}
