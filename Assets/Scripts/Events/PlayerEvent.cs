using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerEvent : AbstractEvent
{
    public float duration = 1.5f;

    private bool _executedAction = false;

    public new void Update()
    {
        UpdatePosition();

        if (transform.position.x <= 0 && !_executedAction)
        {
            ExecutePlayerAction();
            _executedAction = true;
        }
    }

    private void ExecutePlayerAction()
    {
        Player.Instance.Jump(duration);
    }
}
