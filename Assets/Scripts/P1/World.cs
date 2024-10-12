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

    [Space]
    public float offScreenMoveThreshold = -10f;
    public float offScreenMoveSpeed = 1f;

    public static Vector3 GetObjectMovement(FallingObject obj) => GetMovement(obj.fallingDrag, obj.windMultiplier);

    public static Vector3 GetMovement(float fallingDrag, float windMultiplier)
    {
        Vector2 wind = Wind.CurrentWind * windMultiplier;
        Vector2 fall = Vector2.up * (GetFallSpeed(fallingDrag) - PlayerMovement.VerticalWorldVelocity) * PillowStack.SpeedMultiplier;
        return wind + fall;
    }

    static float GetFallSpeed(float drag) => Mathf.Lerp(instance.minFallSpeed, instance.maxFallSpeed, 1f - drag);
}
