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
    public Vector2 horizontalMovement;
    
    [Header("Movement floats")]
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField] float moveSpeed = 3f;
    [Header("Fall")]
    public float fallMultiplier = 2f; // multiplier to increase fall speed (1 = normal gravity)
    [Header("Throw cooldown")]
    
    [Header("Player Component referencer")]
    private Rigidbody2D playerRB;
    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
    void Update()
    {
       
        
        //if (playerRB.linearVelocity.y < 0.1f && !IsGrounded())
        {
            // Apply a small downward force to increase fall speed
           // playerRB.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1f) * Time.deltaTime;
        }
        
        
    }
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
            
        }


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
