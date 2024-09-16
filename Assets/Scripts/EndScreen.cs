using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Heading = null;
    [SerializeField] private TextMeshProUGUI Description = null;
    [SerializeField] private Image PlayerIdeologyImage = null;
    [SerializeField] private GameObject Panel = null;
    [SerializeField] private AudioClip[] WinSound, LoseSound;
    [SerializeField] private MusicCD WinMusic, LoseMusic;
    [SerializeField] private UiMover UIM = null;
    private GameStatus GS = null;

    private void OnEnable()
    {
        GS = FindObjectOfType<GameStatus>();
        Panel.SetActive(false);
        GameStatus.OnStatusUpdate += FillUI;
        
    }

    private void OnDestroy()
    {
        GameStatus.OnStatusUpdate -= FillUI;
    }
    public void CloseEnd()
    {
        UIM.LerpInOrOut(false);
    }
    private void FillUI()
    {
        if (GS.StateOfTheGame == GameStatus.GameState.PreGame || GS.StateOfTheGame == GameStatus.GameState.Game) return;
        
        PlayerIdeologyImage.sprite = PlayerSettings.PlayerIdea.GetIcon();
        Panel.SetActive(true);
        UIM.LerpInOrOut(true);

        if (GS.StateOfTheGame == GameStatus.GameState.Win)
        {
            Heading.text = "The World is yours...";
            Description.text = "Against all odds your ideology has succeeded in ensconcing itself into every pocket of the world. Your ideology will ensure a new way of life for everyone on Earth, for better, or for worse. Well done.";
            PlayEachSound(true);

        } else if(GS.StateOfTheGame == GameStatus.GameState.Lose)
        {
            Heading.text = "Your ideology has faded into obscurity...";
            Description.text = "Your ideology has sucumbed to the pressures of your adversaries. Your ideology is lost in the oceans of History...";
            PlayEachSound(false);
        }
        
    }

    private void PlayEachSound(bool Win)
    {
        AudioSource TempAS = GetComponent<AudioSource>();
        MusicSystem MS = FindObjectOfType<MusicSystem>();
        if (Win)
        {
            foreach(AudioClip GivenClip in WinSound)
            {
                TempAS.PlayOneShot(GivenClip);
                MS.PlayMusic(WinMusic);
            }
        }
        else
        {
            foreach (AudioClip GivenClip in LoseSound)
            {
                TempAS.PlayOneShot(GivenClip);
                MS.PlayMusic(LoseMusic);
            }
        }
    }
}