using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    private List<IIdea> Enemies = new List<IIdea>();
   
    private void Start()
    {

        Panel.SetActive(false);
    }

   
    public void TurnOnUI()
    {
        Panel.SetActive(true);
        SetEnemyUI();
    }

    public void AddEnemy(IIdea GivenIdeology)
    {
        
        Enemies.Add(GivenIdeology);
        SetEnemyUI();
    }
    public void RemoveEnemy(IIdea GivenIdeology)
    {
        Enemies.Remove(GivenIdeology);
        SetEnemyUI();
    }
    public void SetEnemyUI()
    {
        for(int i = 0; i < Panel.transform.childCount; i++)
        {
            if(i < Enemies.Count)
            {
                Transform TempTransform = Panel.transform.GetChild(i);
                TempTransform.gameObject.GetComponent<Image>().sprite = Enemies[i].GetIcon();

                TempTransform.gameObject.SetActive(true);
            }
            else
            {
                Panel.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }
}
