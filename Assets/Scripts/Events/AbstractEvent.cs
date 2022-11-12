using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class AbstractEvent : MonoBehaviour
{
    public const int Progress = 100;

    [DoNotSerialize] public float progress;

    [NonSerialized] public Vector3 startPoint;
    [NonSerialized] public Vector3 endPoint;

    public void Start()
    {
        progress = Progress;
    }

    public void UpdatePosition(float relativeSpeed)
    {
        UpdateProgress(relativeSpeed);

        Vector3 worldPos = transform.position;
        worldPos.x = (startPoint.x - endPoint.x) * progress/Progress + endPoint.x;
        transform.position = worldPos;
    }

    public virtual void UpdateProgress(float relativeSpeed)
    {
        progress -= relativeSpeed;
    }
}
