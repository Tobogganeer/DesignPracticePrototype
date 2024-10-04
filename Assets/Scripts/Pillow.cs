using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            CollectPillow();
    }

    private void CollectPillow()
    {
        Destroy(gameObject);
    }
}
