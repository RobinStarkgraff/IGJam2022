using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerEvent : AbstractEvent
{
    public new const int Progress = 100;

    public float duration = 1.5f;

    private bool _executedAction = false;

    private void Awake()
    {
        transform.position = new Vector3(0, 4.4f, 0);
    }

    public void Update()
    {
        if (!(transform.position.x <= EndPoint.x) || _executedAction) return;

        ExecutePlayerAction();
        _executedAction = true;
    }

    private void ExecutePlayerAction()
    {
        Player.Instance.Jump(duration);
    }
}
