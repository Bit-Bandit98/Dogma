using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NeighbouringInfluenceUI : MonoBehaviour, ISelectable
{
    private InfluenceSystem IS = null;
    [SerializeField] GameObject NeighbourIcon = null;
    [SerializeField] Material LineRender;
    private List<GameObject> PlacedIcons;
    private IInfluenceHome<Country> ConnectedCountry = null;

    private void Awake()
    {
        ConnectedCountry = gameObject.transform.root.GetComponentInChildren<IInfluenceHome<Country>>();
        if (ConnectedCountry.GetNeighbours().Length <= 0) Destroy(this);
        IS = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        PlaceIcons();
        

    }
    private void Start()
    {
        //IS.GetDiscoverState().OnDiscovery += PlaceIcons;
        IS.GetDiscoverState().OnDiscovery += (() => { IS.OnUpdate += UpdateIconImages; });
    }

    public void PlaceIcons()
    {
       PlacedIcons = new List<GameObject>();
       foreach(Country Neighbour in ConnectedCountry.GetNeighbours())
        {
            GameObject NewOBJ = Instantiate(NeighbourIcon);
            NewOBJ.transform.position = Vector3.Lerp(gameObject.transform.position, Neighbour.gameObject.transform.position, 0.1f);
            NewOBJ.GetComponent<GoTowardsAnim>().SetLocations(NewOBJ.transform.position, Neighbour.gameObject.transform.position);
            PlacedIcons.Add(NewOBJ);
            NewOBJ.GetComponent<Canvas>().sortingLayerName = "Lines";
            NewOBJ.SetActive(false);
        }
        AddLines();
    }

    private void UpdateIconImages()
    {
        if (PlacedIcons.Count <= 0) return;
        

            foreach (GameObject Icon in PlacedIcons)
            {
                Icon.GetComponentInChildren<Image>().sprite = IS.GetListOfIdeologies().GetFollowedIdeologies()[0].GetFollowedIdeology().GetIcon();
            }
        
        
    }


    public void AddLines()
    {
        Country[] Neighbours = ConnectedCountry.GetNeighbours();

        foreach(Country Neigh in Neighbours)
        {
            GameObject NewOBJ = new GameObject();
            NewOBJ.transform.parent = this.gameObject.transform;
            LineRenderer LR = NewOBJ.AddComponent<LineRenderer>();
            LR.positionCount = 2;
            LR.SetPosition(0, gameObject.transform.position );
            LR.SetPosition(1, Neigh.transform.position );
            LR.sortingLayerName = "Lines";
            LR.material = LineRender;
            LR.useWorldSpace = false;
            LR.numCapVertices = 10;
            LR.SetWidth(0.050f, 0.050f);
            NewOBJ.SetActive(false);
        }
    }

    public void OnSelect()
    {
        if (PlacedIcons.Count <= 0 || !IS.GetDiscoverState().GetIsDiscovered()) return;


        foreach (GameObject Icon in PlacedIcons)
        {
            Icon.SetActive(true);
            
        }
    }

    public void OnDeselect()
    {
        if (PlacedIcons.Count <= 0 || !IS.GetDiscoverState().GetIsDiscovered()) return;


        foreach (GameObject Icon in PlacedIcons)
        {
            Icon.SetActive(false);
        }
    }
}