using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class LevelEvent : AbstractEvent
{
    protected Vector3 ownStartPoint = new Vector3(9, 0, 0);
    protected Vector3 ownEndPoint = new Vector3(-4, 0, 0);

    private void Awake()
    {
        startPoint = ownStartPoint;
        endPoint = ownEndPoint;
    }

    public override void UpdateProgress(float relativeSpeed)
    {
        progress -= relativeSpeed * 2;
    }
}
