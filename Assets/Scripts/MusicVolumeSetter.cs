using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicVolumeSetter : MonoBehaviour
{
    private Slider UISlider = null;

    
    private void Start()
    {
        UISlider = GetComponent<Slider>();
    }
    public void SetVolume()
    {
        AudioListener.volume = UISlider.value;
    }
}
