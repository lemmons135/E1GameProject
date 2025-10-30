using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    // private member variables
    Vector2 movementVector = Vector2.zero;
    Rigidbody2D rb;
    float speed;
    bool isDashing = false;
    float currentDashTime = 0.1f; //0.1 to avoid zero multiplication

    // public member variables
    [SerializeField] float walkingSpeed = 6f;
    [SerializeField] float dashDuration = 0.5f;
    [SerializeField] float dashMultiplier = 2f;
    [SerializeField] AudioManager audioManager;

    void Start()
    {
        dashDuration += currentDashTime; // to account for initial value
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
        if (currentDashTime <= dashDuration)
        {
            speed = dashMultiplier * currentDashTime * currentDashTime ;
            currentDashTime += Time.deltaTime;
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
        currentDashTime = 0f;
    }


}
