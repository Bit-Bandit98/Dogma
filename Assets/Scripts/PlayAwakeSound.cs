using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAwakeSound : MonoBehaviour
{
   [SerializeField] private AudioSource AS = null;
    private void OnEnable()
    {
        AS.Play();
    }
}
