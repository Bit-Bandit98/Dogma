using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatiosPanel : MonoBehaviour
{
    [SerializeField] private int NumberOfPanels = 5;
    [SerializeField] private GameObject IdeologyRatioPanel = null, RatioHeader;
    [SerializeField] private UiMover UiAnimes = null, HeaderAnimes;
    public static RatiosPanel Singleton = null;
    private void Awake()
    {
        Singleton = this;
        for(int i = 0; i < NumberOfPanels; i++)
        {
            GameObject TempOBJ = Instantiate(IdeologyRatioPanel);
            TempOBJ.transform.SetParent(transform);
            TempOBJ.SetActive(false);
        }
       // SetPanelActivity(false, true);
    }


    public void SetIdeologyPanels(InfluenceSystem IS)
    {
        ListOfProminentIdeologies TempList = IS.GetListOfIdeologies();
        int TempPopulation = IS.GetSituatedIn().GetPopulation();
        for(int i = 0; i < NumberOfPanels; i++)
        {
            if(i < TempList.GetFollowedIdeologies().Count) {
            transform.GetChild(i).GetComponent<IdeologyRatioPanel>().SetIdeaPanel(TempList.GetFollowedIdeologies()[i], TempPopulation);
            transform.GetChild(i).gameObject.SetActive(true);
            } else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void SetPanelActivity(bool Condition)
    {
        
        
            
        UiAnimes.LerpInOrOut(Condition);
        HeaderAnimes.LerpInOrOut(Condition);
        
    }
}