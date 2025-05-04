using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float RunMultiplier = 1.5f;

    Vector2 moveInput;

    float move;
    private bool isRunning;
    public bool facingRight = true;

    public float JumpForce;
    public bool IsJumping;

    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;

    //Stamina System
    public float Stamina = 100f;
    public float MaxStamina = 100f;
    public float StaminaDrainRate = 20f;
    public float StaminaRecoverRate = 10f;

    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        IsJumping = !grounded;

        move = Input.GetAxisRaw("Horizontal"); 

        // กด Shift เพื่อวิ่ง
        isRunning = Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Stamina > 0f;

        float currentSpeed = Speed;

        if (isRunning)
        {
            currentSpeed *= RunMultiplier;
            Stamina -= StaminaDrainRate * Time.deltaTime;
            Stamina = Mathf.Clamp(Stamina, 0f, MaxStamina);
        }
        else
        {
            Stamina += StaminaRecoverRate * Time.deltaTime;
            Stamina = Mathf.Clamp(Stamina, 0f, MaxStamina);
        }

        rb2d.linearVelocity = new Vector2(move * currentSpeed, rb2d.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, JumpForce);
        }

        Debug.Log("Stamina: " + Stamina);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
