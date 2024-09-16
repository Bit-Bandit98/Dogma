using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerCardUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NameText = null, NumDominated = null;
    [SerializeField] private Image IdeologyImage = null, Panel = null;
    private PlayerCardSettings ConnectedPCS = null;

    private void Awake()
    {
        ConnectedPCS = GetComponent<PlayerCardSettings>();
        ConnectedPCS.OnUpdate += UpdateData;
    }

    private void OnDestroy()
    {
        ConnectedPCS.OnUpdate -= UpdateData;
    }
    private void UpdateData() { SetUI(ConnectedPCS); }
    public void SetUI(PlayerCardSettings PCS)
    {
        IIdea TempIdea = ConnectedPCS.GetPlayerIdeology();
        NameText.text = ConnectedPCS.GetPlayerName();
        NumDominated.text = "Dominations \n" +PCS.GetDominations() + " out of " + PCS.GetAreas();
        IdeologyImage.sprite = TempIdea.GetIcon();
        Panel.color = TempIdea.GetColours().GetSecondaryColour();
        Panel.color = new Color(Panel.color.r, Panel.color.g, Panel.color.b, 0.50f);
    }
}