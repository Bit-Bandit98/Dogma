using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private KeyCode PauseKey = KeyCode.Escape;
    [SerializeField] private GameObject PauseMenuOBJ = null;
    [SerializeField] private UiMover Mover = null;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(PauseKey))
        {
            PauseGame();
        } 
    }


    public void PauseGame()
    {
        
        Mover.LerpInOrOut(!Mover.In);
    }
}
