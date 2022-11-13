using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShootLevelEvent : LevelEvent
{
    protected override int pointsForEvent { get; } = 0;
}
