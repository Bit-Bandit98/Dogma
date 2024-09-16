using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillBarUI : MonoBehaviour
{
    [SerializeField] private GameObject ActionCardPrefab = null, ContentPanel = null, NamePanel = null;
    [SerializeField] private UiMover MoverAnimes = null;
    [SerializeField] private int NumberOfCards = 5;
    private GameObject[] ActionCards = null;
    private GameStatus GS = null;
    private void Awake()
    {
        GS = FindObjectOfType<GameStatus>();
        CreateCards();
        //CloseActionBar();
        TurnMaster.OnNextTurn += CloseActionBar;
    }

    private void OnDestroy()
    {
        TurnMaster.OnNextTurn -= CloseActionBar;
    }
    private void SetActivity(bool Condition)
    {
        NamePanel.SetActive(Condition);
        gameObject.SetActive(Condition);
    }
    private void CreateCards()
    {
        List<GameObject> TempCards = new List<GameObject>();
        for(int i = 0; i < NumberOfCards; i++)
        {
            GameObject TempOBJ = Instantiate(ActionCardPrefab);
            TempOBJ.transform.SetParent(ContentPanel.transform);
            TempCards.Add(TempOBJ);
            TempOBJ.SetActive(false);
        }
        ActionCards = TempCards.ToArray();
    }

    private void SetCards(IHasSkill[] Skills)
    {
        DeactivateCards();
        if (TutorialSettings.DisableSkills) return;
        if (GS.StateOfTheGame == GameStatus.GameState.Lose || GS.StateOfTheGame == GameStatus.GameState.Win) return;
        SkillCard TempCard = null;
        for (int i = 0; i < Skills.Length; i++)
        {
            if (!Skills[i].Getskill().Available) continue;

            TempCard = ActionCards[i].GetComponent<SkillCard>();
            TempCard.Initialize(Skills[i].Getskill(), Skills[i].GetSkillSlot());
            TempCard.AddTurnOff(this);
            ActionCards[i].SetActive(true);

          
        }
        
       // SetActivity(true);
    }

    public void OpenActionBar(IHasSkill[] Skills, string GivenName)
    {
        
        if (Skills.Length <= 0) return;
        if (Targeter.InTargetMode) return;
        
        NamePanel.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GivenName;
        MoverAnimes.LerpInOrOut(true);
        SetCards(Skills);
    }

    public void CloseActionBar()
    {
        DeactivateCards();
        MoverAnimes.LerpInOrOut(false);
    }

    private void DeactivateCards()
    {
        foreach(GameObject OBJ in ActionCards)
        {
            OBJ.SetActive(false);
        }
    }
}