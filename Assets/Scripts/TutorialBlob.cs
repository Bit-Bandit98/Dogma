using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TutorialBlob : MonoBehaviour
{
    [SerializeField] private GameObject Blob = null;
    [SerializeField] private TextMeshProUGUI TutorialText;
    [SerializeField] private TutorialInfo[] Tutorials;
    [SerializeField] private Button ButtonToDisable = null;

    private TurnMaster TM = null;
    private void OnEnable()
    {
        TM = FindObjectOfType<TurnMaster>();
        
        if (!TutorialSettings.TutorialFinished) TurnMaster.OnNextTurn += DisplayBlob;
    }

   
    
    private void OnDisable()
    {
        TurnMaster.OnNextTurn -= DisplayBlob;
    }

    private void Start()
    {
        
       if(!TutorialSettings.TutorialFinished) DisplayBlob();
       else Blob.SetActive(false);
    }

    private void DisplayBlob()
    {
        //if (TutorialSettings.TutorialFinished)
        //{
        //    Blob.SetActive(false); 
        //    return;
        //}
        TutorialInfo TInfo = FindMessageWithTurn(TM.GetCurrentTurn());
        if(TInfo != null) { 
           TutorialText.text = TInfo.GetMessage();
            Blob.SetActive(true);
            if (TInfo.CanEndTutorial) TutorialSettings.TutorialFinished = true;
            if(TInfo.GetForceUseSkillID() != Skill.SkillTypes.None) ButtonToDisable.interactable = false;
        }
        else
        {
            Blob.SetActive(false);
        }
        TutorialSettings.DisableSkills = false;
    }

    private TutorialInfo FindMessageWithTurn(int Turn)
    {
        foreach(TutorialInfo TInfo in Tutorials)
        {
            if (Turn == TInfo.GetTurnShown()) return TInfo;
        }

        return null;
    }

    public TutorialInfo GetCurrentTutorial()
    {
        if (TM.GetCurrentTurn() >= Tutorials.Length) return null;
        return Tutorials[TM.GetCurrentTurn()];
    }
}