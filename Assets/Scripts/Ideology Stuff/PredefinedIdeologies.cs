using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PredefinedIdeologies : MonoBehaviour
{
    [SerializeField] private Ideology[] ExistingIdeologies = null;
    [SerializeField] private Ideology ApatheticIdeology = null;
    public static PredefinedIdeologies Singleton = null;

    private void Awake()
    {
        Singleton = this;
       
        SetAllNotInUse();
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

    public Ideology GetRandomIdeology()
    {
        List<Ideology> Hat = ExistingIdeologies.ToList<Ideology>();
        Ideology RandomIdeology = null;
        while(Hat.Count > 1)
        {
            RandomIdeology = Hat[Random.Range(0, Hat.Count)];
            if (RandomIdeology.IsInUse)
            {
                Hat.Remove(RandomIdeology);
                RandomIdeology = null;
                continue;
            }
            return RandomIdeology;
        }
        return null;
    }

    public void SetAllNotInUse()
    {
        foreach (Ideology Idea in ExistingIdeologies){Idea.IsInUse = false;}
    }
    public Ideology GetApathetic() { return ApatheticIdeology; }
    public Ideology[] GetExistingIdeologies() { return ExistingIdeologies; }
}