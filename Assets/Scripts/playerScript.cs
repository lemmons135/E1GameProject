using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    // private member variables
    Vector2 movementVector = Vector2.zero;
    Rigidbody2D rb;
    float speed;
    bool isDashing = false;
    float currentDashTime = 0f;

    // public member variables
    [SerializeField] float walkingSpeed = 6f;
    [SerializeField] float dashDuration = 0.5f;
    [SerializeField] float dashSpeed = 12f;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = walkingSpeed;
    }

    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (!isDashing)
        {
            isDashing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) { runDashCountdown(); }

        rb.linearVelocity = movementVector * speed;
    }

    void runDashCountdown()
    {
        // from 0 to dashDuration
        if (currentDashTime <= dashDuration)
        {
            // increment the dash timer
            currentDashTime += Time.deltaTime;

            // calculate the slope of the speed decrease
            float slope = ((dashSpeed - walkingSpeed) / dashDuration);
                // y = mx + b
                // x = time and currentDashTime is decreasing from dashDuration + 0.1 to 0.1
            speed = slope * currentDashTime + dashSpeed;
        }
        else
        {
            resetDash();
        }
    }

    void resetDash()
    {
        isDashing = false;
        speed = walkingSpeed;
        currentDashTime = 0;
        Debug.Log(speed);
    }


}
