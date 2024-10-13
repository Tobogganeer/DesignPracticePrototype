using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : Person
{
    protected override void Move(Vector3 spawnPoint, Vector3 to)
    {
        base.Move(spawnPoint, to);
    }
}
