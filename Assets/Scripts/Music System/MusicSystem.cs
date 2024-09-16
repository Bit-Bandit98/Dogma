using UnityEngine;
using System.Collections;
using System;
public class MusicSystem : MonoBehaviour
{
    private MusicCD CurrentCD = null;
    [SerializeField] private MusicSettings Settings;
    private AudioSource AS = null;
    private float StartingVolume;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
        StartingVolume = AS.volume;
        DontDestroyCheck();
    }

    private void DontDestroyCheck()
    {
        PlayerList[] objs = FindObjectsOfType<PlayerList>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (AS.isPlaying) return;
        PlayMusic(CurrentCD);
    }

    public void PlayMusic(MusicCD CD)
    {
        
        CurrentCD = CD;
        if (AS.isPlaying)
        {
            StopAllCoroutines();
            StartCoroutine(FadeSwap(CD.GetNextSong()));
        }
        else
        {
            AS.clip = CD.GetNextSong(Settings.Shuffle);
            AS.Play();
        }
        AS.loop = Settings.Loop;
    }

    public void SetLoop(bool Condition)
    {
        Settings.Loop = Condition;
    }

    private IEnumerator FadeSwap(AudioClip NextTrack)
    {

        while(AS.volume > 0f)
        {
            AS.volume -= Time.deltaTime/6;
            yield return null;
        }
        AS.Stop();
        AS.clip = NextTrack;
        AS.Play();
        while(AS.volume < StartingVolume)
        {
            AS.volume += Time.deltaTime/6;
            yield return null;
        }
        yield return null;
    }

    public AudioSource GetAudioSource() { return AS; }

}