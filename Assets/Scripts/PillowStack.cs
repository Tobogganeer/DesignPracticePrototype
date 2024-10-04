using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowStack : MonoBehaviour
{
    public static PillowStack instance;
    private void Awake()
    {
        instance = this;
    }

    public static float SpeedMultiplier => 1f;
}
