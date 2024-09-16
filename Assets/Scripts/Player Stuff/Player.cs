using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player 
{
    private string Name = "New Player";
    private Ideology PlayerIdeology = null;
    public Player(string GivenName, Ideology Idea)
    {
        Name = GivenName;
        PlayerIdeology = Idea;
        Idea.IsInUse = true;
    }

    public IIdea GetPlayerIdeology() { return PlayerIdeology; }
    public string GetName() { return Name; }
}