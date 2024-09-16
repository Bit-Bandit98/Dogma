using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ButtonShine : MonoBehaviour
{
    [SerializeField] private float ShineSpeed = 1f;
    [SerializeField] private Color HighlightColor;
    private Color StartingColor;
    private Button GivenButton = null;
    private Image ButtonImage = null;
    [SerializeField] private GameStatus GS = null;

    private void Awake()
    {
        ButtonImage = GetComponent<Image>();
        StartingColor = GetComponent<Image>().color;
        GivenButton = GetComponent<Button>();
    }

    
    public void BeginShine()
    {
        GivenButton.interactable = true;
        StartCoroutine(Shine());
    }

    public void CancelShine()
    {

        StopAllCoroutines();
       // GivenButton.interactable = Interact;
        ButtonImage.color = StartingColor;
    }
    public void SetEnabledButton(bool GivenCondition)
    {
        GivenButton.interactable = GivenCondition;
    }

    private IEnumerator ButtonCooldown()
    {
        float Timer = 0f;
        GivenButton.interactable = false;

        while(Timer < 1f)
        {

            Timer += Time.deltaTime;
            yield return null;
        }
        if(GS.StateOfTheGame == GameStatus.GameState.Game) GivenButton.interactable = true;
    }
    public void CooldownButton()
    {
        if (GivenButton.interactable == false) return;
        StartCoroutine(ButtonCooldown());
    }
    private IEnumerator Shine()
    {
        float Timer = 0f;
        while (true) { 
        while(Timer < 1f)
        {
            ButtonImage.color = Color.Lerp(StartingColor, HighlightColor, Timer);
            Timer += Time.deltaTime * ShineSpeed;
            yield return null;
        }

        while(Timer > 0f)
        {
            ButtonImage.color = Color.Lerp(StartingColor, HighlightColor, Timer);
            Timer -= Time.deltaTime * ShineSpeed;
            yield return null;
        }
            yield return null;
        }
    }
}
