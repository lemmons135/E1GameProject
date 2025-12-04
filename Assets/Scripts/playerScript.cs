using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    // private member variables
    Vector2 movementVector = Vector2.zero;
    Vector2 dashDirection = Vector2.zero;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    // this speed variable will change depending on whether the player is dashing or not
    float currentSpeed;
    bool isDashing = false;
    bool isDizzy = false;
    float currentDashTimer = 0f;
    float currentDizzyTimer = 0f;
    float direction;
    public int score = 0;

    // public member variables
    [SerializeField] float walkingSpeed = 6f;
    [SerializeField] float dashDuration = 0.25f;
    [SerializeField] float DizzyDuration = 1f;
    [SerializeField] float dashSpeed = 18f;
    [SerializeField] AudioManager audioManager;
    [SerializeField] Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = walkingSpeed;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
        direction = Mathf.Atan2(movementVector.y, movementVector.x)* (180f / Mathf.PI); 
        animator.SetFloat("direction", direction); 
        animator.SetFloat("x", movementVector.x);
        animator.SetFloat("y", movementVector.y);
        animator.SetBool("isRunning", !(Mathf.Approximately(movementVector.x, 0) && Mathf.Approximately(movementVector.y, 0)));
    }

    void OnJump()
    {
        dashDirection = movementVector;

        if (!isDashing)
        {
            isDashing = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movementVector.x > 0)
        {
            //flip the sprite to face right
            spriteRenderer.flipX = true;
        }
        if (movementVector.x < 0)
        {
            //flip the sprite to face right
            spriteRenderer.flipX = false;
        }
        if (isDashing)
        {

            // all this dash does is increment the speed for a short time
            runDashCountdown();

            Vector2 current = rb.linearVelocity;
            Vector2 desired;

            if (!isDizzy)
            {
                desired = dashDirection * currentSpeed;
            }
            else
            {
                desired = Vector2.zero;
            }

            // update the player's velocity based on input
            rb.AddForce((desired - current) * 0.9f, ForceMode2D.Impulse);

        }

        else
        {
            Vector2 current = rb.linearVelocity;
            Vector2 desired;

            if (!isDizzy)
            {
                desired = movementVector * currentSpeed;
            }
            else
            {
                desired = Vector2.zero;
            }

            // update the player's velocity based on input
            rb.AddForce((desired - current) * 0.9f, ForceMode2D.Impulse);
        }
        runDizzyCountdown();

    }


    void runDashCountdown()
    {
        // from 0 to dashDuration
        if (currentDashTimer <= dashDuration)
        {
            // increment the dash timer
            currentDashTimer += Time.deltaTime;

            // calculate the slope of the speed decrease
            float slope = ((dashSpeed - walkingSpeed) / dashDuration);
            // y = mx + b
            // x = time and currentDashTime is decreasing from dashDuration + 0.1 to 0.1
            currentSpeed = slope * currentDashTimer + dashSpeed;
        }
        else
        {
            resetDash();
        }
    }

    void resetDash()
    {
        isDashing = false;
        currentSpeed = walkingSpeed;
        currentDashTimer = 0;
    }

    void resetDizzy()
    {
        isDizzy = false;
        currentDizzyTimer = 0;
    }

    public void AddScore(int val)
    {
        score += val;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == true)
        {
            if (isDashing) 
            {
                Vector2 pushDirection = collision.contacts[0].normal;
                isDizzy = true;
                rb.AddForce(pushDirection * 300f, ForceMode2D.Impulse);
                animator.SetBool("collision", true);
            }

        }
    }

    void runDizzyCountdown()
    {
        // from 0 to dizzyDuration
        if (currentDizzyTimer <= DizzyDuration)
        {
            // increment the dizzy timer
            currentDizzyTimer += Time.deltaTime;
        }
        else
        {
            animator.SetBool("collision", false);
            resetDizzy();
        }
    }

}
