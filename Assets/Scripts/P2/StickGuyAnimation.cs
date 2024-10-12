using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickGuyAnimation : MonoBehaviour
{
    public Vector2 bob = new Vector2(0.05f, 0.2f);
    public float speed = 4f;
    public float rotation = 15f;

    float time;

    private void Start()
    {
        time = Random.Range(0f, Mathf.PI);
    }

    private void Update()
    {
        time += Time.deltaTime * Mathf.PI * speed;
        float x = Mathf.Sin(time) * bob.x;
        float y = Mathf.Abs(Mathf.Cos(time)) * bob.y;

        transform.localPosition = new Vector3(x, y);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(time) * rotation);
    }
}
