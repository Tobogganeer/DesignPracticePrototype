using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public static Wind instance;
    private void Awake()
    {
        instance = this;
    }

    public static Vector2 CurrentWind => Vector2.zero;
}
