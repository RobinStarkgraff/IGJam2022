using System;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractEvent : MonoBehaviour
{
    public float progress;

    public void Start()
    {
        progress = 8;
        SpriteRenderer spriteRenderer = this.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = GameController.Instance.shape;
    }

    public void Update()
    {
        UpdatePosition();
    }

    protected void UpdatePosition()
    {
        //Some position calculation
        Vector3 worldPos = transform.position;
        worldPos.x = progress;
        transform.position = worldPos;   
    }
}
