using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable, CreateAssetMenu(fileName = "New MusicCD", menuName = "ScriptableObjects/MusicCD")]
public class MusicCD : ScriptableObject
{
    [SerializeField] private AudioClip[] MusicTracks = null;
    private int CurrentSong = 0;

    public AudioClip[] GetMusicTracks() { return MusicTracks; }
    public AudioClip GetNextSong(bool Shuffle = false) {
        if (Shuffle) return MusicTracks[Random.Range(0, MusicTracks.Length)];
        if (CurrentSong + 1 >= MusicTracks.Length) CurrentSong = 0;
        else CurrentSong++;
        return MusicTracks[CurrentSong];
    }
}