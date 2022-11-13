using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public static Tutorial Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void DisableTutorial() 
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
