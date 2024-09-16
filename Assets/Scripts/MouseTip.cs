using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MouseTip : MonoBehaviour
{
    private string ToolText = null;
    [SerializeField] private Vector3 Offset;
    [SerializeField] private TextMeshProUGUI TipText = null;
    [SerializeField] private GameObject ToolTipOBJ = null;

    public static MouseTip Singleton = null;
    private void Start()
    {
        
        TurnOffToolText();
        Singleton = this;
    }
    // Update is called once per frame
    void Update()
    {
        ToolTipOBJ.transform.position = Input.mousePosition + Offset;    
    }


    public void SetToolText(string GivenText)
    {
        ToolText = GivenText;
        TipText.text = ToolText;
        ToolTipOBJ.SetActive(true);
        this.enabled = true;
    }

    public void TurnOffToolText()
    {
        ToolText = "";
        TipText.text = ToolText;
        ToolTipOBJ.SetActive(false);
        this.enabled = false;
    }
}
