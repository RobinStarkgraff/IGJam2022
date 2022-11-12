using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelInputController : MonoBehaviour
{
    public void OnJump()
    {
        GameController.Instance.SpawnLevelEvent();
    }
}
