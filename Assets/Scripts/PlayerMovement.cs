using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float RunMultiplier = 1.5f;

    Vector2 moveInput;

    float move;
    private bool isRunning;

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
        //walk with addforce
        /*moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);*/

        /*IsJumping = !Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //use rigidbody2d to move left and right (x-axis)
        move = Input.GetAxis("Horizontal"); //x - axis
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        //jump
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            //rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, JumpForce);

            Debug.Log("Jump");
        }*/

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
}
