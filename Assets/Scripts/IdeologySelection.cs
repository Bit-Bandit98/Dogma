using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class IdeologySelection : MonoBehaviour
{
    [SerializeField] private GameObject SelectionPrefab = null, NextMenu;
    [SerializeField] private UnityEvent AccompaniedActions;
    private void Start()
    {
        PopulateTable();
    }


    private void PopulateTable()
    {
        PredefinedIdeologies PI = FindObjectOfType<PredefinedIdeologies>();

        foreach(Ideology GivenIdea in PI.GetExistingIdeologies())
        {
            GameObject GM = Instantiate(SelectionPrefab);
            GM.GetComponentInChildren<Image>().sprite = GivenIdea.GetIcon();
            GM.GetComponentInChildren<Button>().onClick.AddListener(() => { ChangeSettings(GivenIdea);
                NextMenu.SetActive(true);
                transform.parent.gameObject.SetActive(false);
                if (AccompaniedActions != null) AccompaniedActions.Invoke();
                FindObjectOfType<PlayerList>().PopulatePlayers();
            });
            GM.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = GivenIdea.GetDetails().GetName();
            GM.transform.SetParent(this.transform);
            GM.transform.localScale = Vector3.one;
        }
    }

    private void ChangeSettings(Ideology GivenIdea)
    {
        PlayerSettings.PlayerIdea = GivenIdea;
    }
}
