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

    public Vector2 changeTime = new Vector2(1f, 5f);
    public float maxStrengthX = 2f;
    public float maxStrengthY = 0.5f;

    public static Vector2 CurrentWind;

    Vector2 targetWind;

    IEnumerator Start()
    {
        while (true)
        {
            targetWind = new Vector2(Random.Range(-maxStrengthX, maxStrengthX), Random.Range(-maxStrengthY, maxStrengthY));
            yield return new WaitForSeconds(Random.Range(changeTime.x, changeTime.y));
        }
    }

    private void Update()
    {
        CurrentWind = Vector2.Lerp(CurrentWind, targetWind, Time.deltaTime * 2f);
    }
}
