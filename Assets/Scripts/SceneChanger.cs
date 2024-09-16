using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneChanger : MonoBehaviour
{

    public void ChangeScene(int Index)
    {
        Fader TempFader = FindObjectOfType<Fader>();
        TempFader.FadeIn();
        SceneManager.LoadScene(Index);
        TempFader.FadeOut();
        
    }

  
}