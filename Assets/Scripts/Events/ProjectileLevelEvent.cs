using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLevelEvent : LevelEvent
{
    protected override int pointsForEvent { get; } = 0;

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
