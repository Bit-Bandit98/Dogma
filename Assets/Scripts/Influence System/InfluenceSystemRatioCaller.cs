using UnityEngine;

public class InfluenceSystemRatioCaller : MonoBehaviour, ISelectable, IClickable
{
    private InfluenceSystem ConnectedInfluenceSystem = null;
    private Discoverability DiscoverStatus = null;

    private bool Added = false;
    private void Awake()
    {
        ConnectedInfluenceSystem = gameObject.transform.root.GetComponentInChildren<InfluenceSystem>();
        DiscoverStatus = gameObject.transform.root.GetComponentInChildren<Discoverability>();
       
    }

 

    public void OnSelect()
    {
       // if (!DiscoverStatus.GetIsDiscovered()) return;
       // ConnectedInfluenceSystem.OnUpdate += CallRatioMaker;
       // CallRatioMaker();
       // SetRatioActivity(true);
    }

    public void OnClick()
    {
        
        if (!Added)
        {
            // ConnectedInfluenceSystem.OnUpdate += CallRatioMaker;
            ConnectedInfluenceSystem.OnUpdate += CloseRatioMaker;
            Added = true;
        }
        if (!DiscoverStatus.GetIsDiscovered()) return;
        CallRatioMaker();
        SetRatioActivity(true);

    }
    public void OnDeselect()
    {
        if (!DiscoverStatus.GetIsDiscovered()) return;
        Added = false;
        ConnectedInfluenceSystem.OnUpdate -= CloseRatioMaker;
        SetRatioActivity(false);
    }

    private void CallRatioMaker()
    {
        RatiosPanel.Singleton.SetIdeologyPanels(ConnectedInfluenceSystem);
    }

    private void SetRatioActivity(bool Condition)
    {
        
        RatiosPanel.Singleton.SetPanelActivity(Condition);
    }

    private void CloseRatioMaker()
    {
        SetRatioActivity(false);
    }

}