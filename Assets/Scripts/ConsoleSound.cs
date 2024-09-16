using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleSound : MonoBehaviour
{
    private AudioSource AS = null;
    [SerializeField] private AudioClip SoundToPlay = null;
    private void Start()
    {
        AS = GetComponent<AudioSource>();
        Console.OnConsoleUpdated += MakeSound;
    }

    private void OnDestroy()
    {
        Console.OnConsoleUpdated -= MakeSound;
    }

    private void MakeSound()
    {
        AS.Stop();
        AS.clip = SoundToPlay;
        AS.Play();
    }
}
