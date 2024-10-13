using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float acceleration = 6f;

    Vector2 velocity;

    private void Update()
    {
        Vector2 desired = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        desired.Normalize();

        velocity = Vector2.Lerp(velocity, desired * speed, Time.deltaTime * acceleration);
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
