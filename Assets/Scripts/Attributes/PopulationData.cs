using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PopulationData
{
    [SerializeField] private int Population = 1000;

    public int GetPopulation() { return Population; }
}
