using Popcron;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gizmos = Popcron.Gizmos;

public class Yelling : MonoBehaviour
{
    public GameObject yellPrefab;
    public UnityEngine.UI.Image fillBar;

    public float cooldown = 1.5f;
    float timer;

    Vector2 aimDirection = Vector2.right;

    private void Update()
    {
        timer -= Time.deltaTime;

        UpdateAimDirection();

        if (Input.GetKeyDown(KeyCode.Space) && timer < 0f)
        {
            timer = cooldown;
            Quaternion rot = Quaternion.LookRotation(Vector3.forward, aimDirection);
            GameObject yell = Instantiate(yellPrefab, transform.position, rot);
            yell.GetComponent<Yell>().direction = aimDirection;
        }

        fillBar.fillAmount = timer / cooldown;
        Gizmos.Line(transform.position, transform.position + (Vector3)aimDirection, Color.magenta);
    }

    private void OnRenderObject()
    {
        //Gizmos.Line(transform.position, transform.position + (Vector3)aimDirection, Color.magenta);
    }

    void UpdateAimDirection()
    {
        Vector2 desired = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            desired += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            desired += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            desired += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            desired += Vector2.right;

        desired.Normalize();

        // Only update if we are aiming somewhere
        if (desired.sqrMagnitude != 0)
            aimDirection = Vector2.Lerp(aimDirection, desired, Time.deltaTime * 10f);
    }
}
