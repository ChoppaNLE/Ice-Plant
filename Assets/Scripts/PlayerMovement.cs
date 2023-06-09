using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpsLeft = 0;
    private bool hasJumpedInAir;

    private Transform knight;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        knight = transform.Find("Knight");
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(0.9f, 0.1f), 0f, whatIsGround);

        if (isGrounded)
        {
            jumpsLeft = 1;
        }
        else
        {
            jumpsLeft = 0;
        }
        
        float horizontal =0f;
        
        if (gameObject.tag == "Player1")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = +1f;
            }
            
            
            if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpsLeft--;
            }
        }
        else if (gameObject.tag == "Player2")
        {
            
            if (Input.GetKey(KeyCode.A))
            {
                horizontal = -1f;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                horizontal = +1f;
            }
            
            if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpsLeft--;
            }
        }


        if (rb.velocity.y < 0) // Cae más rápido que cuando salta
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.UpArrow)) // Salto bajo
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }


        
       
        Vector2 movement = new Vector2(horizontal, 0f);
        knight.GetComponent<Animator>().SetBool("walk", movement.x != 0f);
        rb.velocity = new Vector2(movement.normalized.x * moveSpeed, rb.velocity.y);
        if (movement.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
        }
        else if (movement.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }


    }
}