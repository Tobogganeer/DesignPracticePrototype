using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World instance;
    private void Awake()
    {
        instance = this;
    }

    // Slowest vs fastest base speed for objects
    public float minFallSpeed = 2f;
    public float maxFallSpeed = 6f;

    public static Vector2 GetObjectMovement(FallingObject obj)
    {
        Vector2 wind = Wind.CurrentWind * obj.windMultiplier;
        Vector2 fall = Vector2.up * GetFallSpeed(obj) * PillowStack.SpeedMultiplier;
        return wind + fall;
    }

    static float GetFallSpeed(FallingObject obj) => Mathf.Lerp(instance.minFallSpeed, instance.maxFallSpeed, 1f - obj.fallingDrag);
}
