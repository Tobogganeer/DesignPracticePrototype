using Popcron;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gizmos = Popcron.Gizmos;

public class FallingObject : MonoBehaviour
{
    [Range(0f, 1f)]
    public float fallingDrag = 0.5f;
    public float windMultiplier = 1f;

    [Space]
    public float movementGizmoMultiplier = 1f;

    private void Update()
    {
        Vector3 movement;
        // Move at constant speed until near screen
        if (transform.position.y < World.instance.offScreenMoveThreshold)
            movement = Vector3.up * World.instance.offScreenMoveSpeed;
        else
            movement = World.GetObjectMovement(this);

        transform.position += movement * Time.deltaTime; // Move!!!

        DrawGizmos(movement);

        // Destroy when offscreen
        if (transform.position.y > 20f)
            Destroy(gameObject);
    }

    private void DrawGizmos(Vector3 movement)
    {
        Vector3 end = transform.position + movement * movementGizmoMultiplier;
        Gizmos.Line(transform.position, end, Color.yellow);
    }
}
