using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    // private member variables
    Vector2 movementVector = Vector2.zero;
    Vector2 dashDirection = Vector2.zero;
    Rigidbody2D rb;
    // this speed variable will change depending on whether the player is dashing or not
    float currentSpeed;
    bool isDashing = false;
    float currentDashTimer = 0f;
    public int score = 0;

    // public member variables
    [SerializeField] float walkingSpeed = 6f;
    [SerializeField] float dashDuration = 0.25f;
    [SerializeField] float dashSpeed = 18f;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = walkingSpeed;
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
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
    void Update()
    {

        if (isDashing)
        {

            // all this dash does is increment the speed for a short time
            runDashCountdown();

            rb.linearVelocity = dashDirection * currentSpeed;
        }
        else
        {
            // update the player's velocity based on input
            rb.linearVelocity = movementVector * currentSpeed;
        }
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

    public void AddScore(int val)
    {
        score += val;
    }


}
