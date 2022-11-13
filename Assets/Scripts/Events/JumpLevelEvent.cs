using System;
using Unity.VisualScripting;
using UnityEngine;

public class JumpLevelEvent : LevelEvent
{
    public override int pointsForEvent { get; } = 100;
}
