using UnityEngine;

public class Player_movement : MonoBehaviour
{ 
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;
    
    public float Movement_speed = 5f;
    public float jump_force = 10f;
   
    private Rigidbody2D rb;
    private float horizontalInput;

    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
       
        // Capture movement input here
        horizontalInput = Input.GetAxisRaw("Horizontal");
        SetAnimation(horizontalInput);
        
        rb.velocity = new Vector2(horizontalInput * Movement_speed, rb.velocity.y);

        // 3. Trigger jump in Update so it never misses a click
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_force);
        }
    }

    void FixedUpdate()
    {
        
        // Update the isGrounded status every frame
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

    }

    private void SetAnimation(float horizontalInput)
    {
        if (isGrounded)
        {
            if (horizontalInput == 0)
            {
                animator.Play("Player_standing");
            }
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                animator.Play("Player_jumping");
            }
            else
            {
                animator.Play("Player_fall");
            }
                
        }
        
        
    }
}