using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLevelEvent : LevelEvent
{
    public override int pointsForEvent { get; } = 0;

    private void Awake()
    {
        startPoint = ownEndPoint;
        endPoint = ownStartPoint;
        progress = Progress - 10;
    }

    public override void UpdateProgress(float relativeSpeed)
    {
        progress -= relativeSpeed * 2;
    }
}
