using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static string PlayerName = "Player";
    public static Ideology PlayerIdea = null;


    public static Player GetPlayer()
    {
        return new Player(PlayerName, PlayerIdea);
    }
}