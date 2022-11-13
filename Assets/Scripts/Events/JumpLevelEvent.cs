using System;
using Unity.VisualScripting;
using UnityEngine;

public class JumpLevelEvent : LevelEvent
{
    protected override int pointsForEvent { get; } = 100;

}
