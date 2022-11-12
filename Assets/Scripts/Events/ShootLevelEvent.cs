using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLevelEvent : LevelEvent
{
    private void Awake()
    {
        startPoint = ownEndPoint;
        endPoint = ownStartPoint;
    }
}
