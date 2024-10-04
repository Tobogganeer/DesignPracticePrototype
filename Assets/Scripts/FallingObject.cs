using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Range(0f, 1f)]
    public float fallingDrag = 0.5f;
    public float windMultiplier = 1f;
}
