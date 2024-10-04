using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLayer : MonoBehaviour
{
    public float drag = 1f;
    public float windMult = 0.2f;

    void Update()
    {
        transform.position += World.GetMovement(drag, windMult);
        if (transform.position.y > 10f)
            transform.PositionMut().y -= 20f;
    }
}
