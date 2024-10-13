using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Person : MonoBehaviour
{
    public float speed = 3f;
    public int health = 2;

    [Space]
    public float pushBackDistance = 3f;
    public float pushBackTime = 0.5f;

    [Space]
    public GameObject explosionPrefab;
    public GameObject scorchMark;

    bool beingPushedBack;
    HotDogStand targetStand;
    Vector3 spawnPoint;
    Vector3 moveOrigin;

    private void Start()
    {
        spawnPoint = moveOrigin = transform.position;
        targetStand = HotDogStand.GetClosest(transform.position);
    }

    protected virtual void Update()
    {
        if (targetStand == null)
            targetStand = HotDogStand.GetClosest(transform.position);

        // Go home if all stands are destroyed
        if (!beingPushedBack)
        {
            Vector3 target = targetStand == null ? spawnPoint : targetStand.transform.position;
            Move(moveOrigin, target);
        }
    }

    protected virtual void Move(Vector3 moveFrom, Vector3 to)
    {
        transform.position += transform.position.Dir(to) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stand"))
        {
            targetStand.OnCollidedWith();
            Kill(); // Kaboom
        }
    }

    public virtual void HitByYell(Vector3 direction)
    {
        health--;
        if (health <= 0)
            Kill();
        else if (pushBackDistance > 0f)
            StartCoroutine(PushBack(direction));
    }

    IEnumerator PushBack(Vector3 direction)
    {
        beingPushedBack = true;

        Vector3 start = transform.position;
        Vector3 end = transform.position + direction * pushBackDistance;
        moveOrigin = end; // Reset move origin for child to zigzag from

        float timer = 0;
        while (timer < pushBackTime)
        {
            timer += Time.deltaTime;
            float fac = timer / pushBackTime;
            transform.position = Vector3.Lerp(start, end, fac);

            yield return null;
        }

        beingPushedBack = false;
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
        Instantiate(scorchMark, transform.position, Quaternion.identity);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
