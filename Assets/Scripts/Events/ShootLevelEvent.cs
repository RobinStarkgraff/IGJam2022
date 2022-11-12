using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLevelEvent : LevelEvent
{
    private void Start()
    {
        startPoint = ownEndPoint;
        endPoint = ownStartPoint;
    }
}
