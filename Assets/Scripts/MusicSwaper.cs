using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwaper : MonoBehaviour
{
    [SerializeField] private MusicCD TrackToPlay = null;
    [SerializeField] private bool Looping = true;
    private MusicSystem MS = null;
    private void Start()
    {
        MS = FindObjectOfType<MusicSystem>();
        MS.SetLoop(Looping);
        MS.PlayMusic(TrackToPlay);
    }

}