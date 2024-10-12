using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Person : MonoBehaviour
{
    public float speed = 3f;
    public int health = 2;

    HotDogStand targetStand;
    Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        targetStand = HotDogStand.GetClosest(transform.position);
    }

    protected virtual void Update()
    {
        if (targetStand == null)
            targetStand = HotDogStand.GetClosest(transform.position);

        // Go home if all stands are destroyed
        Vector3 target = targetStand == null ? spawnPoint : targetStand.transform.position;
        Move(spawnPoint, target);
    }

    protected virtual void Move(Vector3 spawnPoint, Vector3 to)
    {
        transform.position += transform.position.Dir(to) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stand"))
        {
            targetStand.OnCollidedWith();
        }
    }

    public virtual void HitByYell(Vector3 direction)
    {
        health--;
        if (health <= 0)
            Kill();
    }

    public virtual void Kill()
    {
        // TODO: Explode?
        Destroy(gameObject);
    }
}
