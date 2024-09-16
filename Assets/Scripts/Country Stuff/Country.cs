using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour, IInfluenceHome<Country>
{
    [SerializeField] private NameAndDescription Details = null;
    [SerializeField] private PopulationData Population = null;
    [SerializeField] private Neighbours<Country> Neighbours = null;
    private Discoverability DiscoverState = null;

    private void Awake()
    {
        DiscoverState = gameObject.transform.root.GetComponentInChildren<Discoverability>();

    }

    public NameAndDescription GetDetails() { return Details; }
    public int GetPopulation() { return Population.GetPopulation(); }
    public Country[] GetNeighbours() { return Neighbours.GetNeighbours(); }
    public Discoverability GetDiscoverState() { return DiscoverState; }
}