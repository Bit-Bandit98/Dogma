using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSound : MonoBehaviour
{
    [SerializeField] private AudioSource AS = null;
    [SerializeField] private AudioClip SoundToPlay;

    private void OnEnable()
    {
        AS.PlayOneShot(SoundToPlay);
    }
    
}
