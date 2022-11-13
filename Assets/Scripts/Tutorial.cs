using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject TutorialButton;
    // Start is called before the first frame update
    public void DisableTutorial() 
    {
        StartButton.gameObject.SetActive(false);
        TutorialButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }
    

    // Update is called once per frame
    
}
