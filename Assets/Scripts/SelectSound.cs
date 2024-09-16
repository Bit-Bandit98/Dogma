using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSound : MonoBehaviour, IClickable
{
    private AudioSource AS = null;
    [SerializeField] private AudioClip SelectAudio = null;
    [SerializeField] private Vector2 PitchRange;
  
    public void OnClick()
    {
        AS.pitch = Random.Range(PitchRange.x, PitchRange.y);
        AS.PlayOneShot(SelectAudio);
    }

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }
}
