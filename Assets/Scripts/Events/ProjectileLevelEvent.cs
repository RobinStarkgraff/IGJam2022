using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLevelEvent : LevelEvent
{
    private void Awake()
    {
        startPoint = ownEndPoint;
        endPoint = ownStartPoint;
    }

    public override void UpdateProgress(float relativeSpeed)
    {
        progress -= relativeSpeed * 2;
    }
}
