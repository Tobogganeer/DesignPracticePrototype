using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yell : MonoBehaviour
{
    public float speed = 5f;
    public float growSpeed = 1f;

    [HideInInspector]
    public Vector3 direction;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Person"))
            collision.GetComponent<Person>().HitByYell(direction);
    }
}
