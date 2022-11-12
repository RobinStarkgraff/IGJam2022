using System;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractEvent : MonoBehaviour
{
    public const int Progress = 200;

    public float progress;

    public Vector3 StartPoint;
    public Vector3 EndPoint;

    public void Start()
    {
        this.transform.position = StartPoint;
        progress = Progress;
        SpriteRenderer spriteRenderer = this.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = GameController.Instance.shape;
    }

    public void UpdatePosition()
    {
        //Some position calculation
        Vector3 worldPos = transform.position;

        worldPos.x = (StartPoint.x - EndPoint.x) * progress/Progress + EndPoint.x;
        transform.position = worldPos;   
    }
}
