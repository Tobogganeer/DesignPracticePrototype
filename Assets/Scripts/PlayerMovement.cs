using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    private void Awake()
    {
        instance = this;
    }

    public float maxHorizontalSpeed = 5f;
    public float upwardsSpeed = 2f;
    public float downwardsSpeed = 5f;

    [Space]
    public float horizontalForce = 100f;
    public float upwardsAcceleration = 1f;
    public float downwardsAcceleration = 2f;

    [Space]
    public float verticalCorrectionStiffness = 1f;
    public float verticalCorrectionDamping = 0.1f;
    public float baselineY = 3f;

    Rigidbody2D rb;
    float verticalWorldVelocity;
    Vector2 input;

    public static float VerticalWorldVelocity => instance.verticalWorldVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Set speed that the world should move at
        float vertAcceleration = input.y > 0f ? upwardsAcceleration : downwardsAcceleration;
        float vertSpeed = input.y > 0f ? upwardsSpeed : downwardsSpeed;
        verticalWorldVelocity = Mathf.Lerp(verticalWorldVelocity, vertSpeed * input.y, Time.deltaTime * vertAcceleration);
    }

    private void FixedUpdate()
    {
        // Stick us to the center of the screen
        AdjustRBVerticalVelocity();

        // Make sure we are going slow enough or in the opposite direction
        if (Mathf.Abs(rb.velocity.x) < maxHorizontalSpeed || Mathf.Sign(rb.velocity.x) != Mathf.Sign(input.x))
        {
            rb.AddForce(Vector2.right * input.x * horizontalForce * rb.mass * Time.deltaTime);
        }
    }

    // We want the player to actually remain in the center of the screen, adjust that here
    void AdjustRBVerticalVelocity()
    {
        // https://discussions.unity.com/t/spring-float-value/655315/4

        float currentVelocity = rb.velocity.y;

        float dampingFactor = Mathf.Max(0f, 1f - verticalCorrectionDamping * Time.deltaTime);
        float acceleration = (baselineY - rb.position.y) * verticalCorrectionStiffness * Time.deltaTime;
        currentVelocity = currentVelocity * dampingFactor + acceleration;
        rb.velocity = rb.velocity.WithY(currentVelocity);
    }
}
