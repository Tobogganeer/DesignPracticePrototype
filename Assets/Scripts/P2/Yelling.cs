using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yelling : MonoBehaviour
{
    public GameObject yellPrefab;
    public UnityEngine.UI.Image fillBar;

    public float cooldown = 1.5f;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer < 0f)
        {
            
        }    
    }
}
