using System;
using System.Linq.Expressions;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ShootPlayerEvent : PlayerEvent
{
    protected override void ExecutePlayerAction()
    {
        Player.Instance.Shoot();
    }
}