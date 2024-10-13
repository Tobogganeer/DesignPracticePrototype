using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Person
{
    public float zigzagSpeed = 0.5f;
    public float zigzagHeight = 2f;

    float zigTimer;

    protected override void Move(Vector3 moveFrom, Vector3 to)
    {
        zigTimer += Time.deltaTime * zigzagSpeed * Mathf.PI;

        Vector2 standDir = moveFrom.Dir(to);
        Vector2 normal = new Vector2(standDir.y, -standDir.x);

        Vector3 movement = standDir + (normal * Mathf.Sin(zigTimer) * zigzagHeight);
        transform.position += movement * speed * Time.deltaTime;
    }
}
