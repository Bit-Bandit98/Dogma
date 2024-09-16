using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoTowardsAnim : MonoBehaviour
{
    private Vector3 StartingLocation, TargetLocation;
    private float Timer = 0f;
    private Color StartingColour, FinishedColour;
    private bool IsSet = false;

    [SerializeField] private Image GivenImage;
    [SerializeField] private float Length = 1f, Speed = 1f;

    public void SetLocations(Vector3 GivenStartingLocation, Vector3 GivenTarget)
    {
        StartingLocation = GivenStartingLocation;
        TargetLocation = GivenTarget;
        StartingColour = GivenImage.color;
        FinishedColour = new Color(GivenImage.color.r, GivenImage.color.g, GivenImage.color.b, 0);

        IsSet = true;

    }

    private void OnEnable()
    {
        if(IsSet)StartAnime();
    }
    private void OnDisable()
    {
        if (IsSet) StopAllCoroutines();
    }
    public void StartAnime()
    {
        StartCoroutine(BeginAnimation());
    }
    

    private IEnumerator BeginAnimation()
    {
        Timer = 0f;
        while (Timer < Length)
        {
            transform.localPosition = Vector3.Lerp(StartingLocation, TargetLocation, Timer);
            GivenImage.color = Color.Lerp(StartingColour, FinishedColour, Timer / Length);
            Timer += Time.deltaTime*Speed;
            yield return null;
        }
        Timer = 0f;
        StartCoroutine(BeginAnimation());
    }
}