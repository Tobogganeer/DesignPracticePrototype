using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogStand : MonoBehaviour
{
    public static List<HotDogStand> all = new List<HotDogStand>();

    private void OnEnable()
    {
        all.Add(this);
    }

    private void OnDisable()
    {
        all.Remove(this);
        if (all.Count == 0)
        {
            // TODO: End game?
        }
    }

    public static HotDogStand GetClosest(Vector3 position)
    {
        float closestDist = Mathf.Infinity;
        HotDogStand closestStand = null;

        foreach (HotDogStand stand in all)
        {
            float dist = Vector3.Distance(stand.transform.position, position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestStand = stand;
            }
        }

        return closestStand;
    }

    public void OnCollidedWith()
    {
        // Kabloom
        if (all.Count > 1)
            Destroy(gameObject);
    }
}
