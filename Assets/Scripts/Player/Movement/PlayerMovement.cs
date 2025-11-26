using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private InputAction move;
    private InputAction jump;
    private InputAction throwPickaxe;
    public GameObject pickaxePrefab;
    public Vector2 horizontalMovement;
    public Animator animator;
    
    [Header("Movement floats")]
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField] float moveSpeed = 3f;
    
    [Header("Throw cooldown")]
    [SerializeField] float throwCooldown = 1f;
    private float throwCooldownTimer = 0f;
    Transform throwPoint;
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
        throwPickaxe = InputSystem.actions.FindAction("Attack");
        playerRB = GetComponent<Rigidbody2D>();
        move.Enable();
        jump.Enable();
        throwPickaxe.Enable();
        jump.performed += Jump;
        jump.canceled += Jump;
        animator = GetComponent<Animator>();
        throwPoint = transform.Find("pickthrowpoint");

    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
        jump.performed -= Jump;
        jump.canceled -= Jump;
    }

    // Update is called once per frame
    void Update()
    {
        // Update throw cooldown timer
        if (throwCooldownTimer > 0f)
            throwCooldownTimer -= Time.deltaTime;

        if (throwPickaxe.WasPressedThisFrame() && throwCooldownTimer <= 0f)
        {
            var pickaxeObj = Instantiate(pickaxePrefab, throwPoint.position, Quaternion.identity);
            // Launch pickaxe in the direction player sprite is facing
            var throwScript = pickaxeObj.GetComponent<PickaxeThrow>();
            if (throwScript != null)
            {
                float directionMultiplier = spriteRenderer.flipX ? -1f : 1f; // -1 for left, 1 for right
                throwScript.LaunchWithDirection(throwScript.launchAngle, throwScript.speed, directionMultiplier);
            }
            throwCooldownTimer = throwCooldown;
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
          
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
         
        }
        if (spriteRenderer.flipX)
        {
            throwPoint.localPosition = new Vector3(-Mathf.Abs(throwPoint.localPosition.x), throwPoint.localPosition.y, throwPoint.localPosition.z);
        }
        else
        {
            throwPoint.localPosition = new Vector3(Mathf.Abs(throwPoint.localPosition.x), throwPoint.localPosition.y, throwPoint.localPosition.z);
        }

        animator.SetBool("IsJumping", !IsGrounded());
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded() && gameObject != null)
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.y, jumpForce);
        }
        else if (context.canceled && playerRB.linearVelocity.y > 0 && gameObject != null)
        {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, playerRB.linearVelocity.y * 0.6f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.9f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    } 

}
