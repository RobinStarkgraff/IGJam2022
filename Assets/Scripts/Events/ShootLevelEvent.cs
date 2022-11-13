using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLevelEvent : LevelEvent
{
    public override int pointsForEvent { get; } = 0;
}
