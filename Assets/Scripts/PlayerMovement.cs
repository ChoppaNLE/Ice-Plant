using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float jumpForce ;
    [SerializeField] private float moveSpeed ;
    [SerializeField] private float fallMultiplier ;
    [SerializeField] private float lowJumpMultiplier ;
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isDoor;
    private bool isBox;
    private bool canJump ;
    private int jumpsLeft = 0;
    private bool hasJumpedInAir;

    private Transform knight;
    private CapsuleCollider2D capsuleCollider2D;

    private void Start()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        knight = transform.Find("Knight");
    }

    private void Update()
    {

        isGrounded =  capsuleCollider2D.IsTouchingLayers(whatIsGround);


        if (isGrounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        jumpsLeft = canJump ? 1 : 0;
        
        float horizontal =0f;
        
        if (gameObject.CompareTag("Player1"))
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
                jumpsLeft=0;
            }
        }

        else if (gameObject.CompareTag("Player2"))
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
                jumpsLeft=0;
            }
        }

        
        if (rb.velocity.y < 0) // Cae m�s r�pido que cuando salta
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.UpArrow)) // Salto bajo
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        

        Vector2 movement = new Vector2(horizontal, 0f);
        knight.GetComponent<Animator>().SetBool("walk", movement.x != 0f);
        //if (isGrounded)
        if (true)
        {
            rb.velocity = new Vector2(movement.normalized.x * moveSpeed, rb.velocity.y);
        }
        
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