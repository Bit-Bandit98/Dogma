using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionManager : MonoBehaviour
{
    private IRayMaker RayMaker = null;
    private ISelector Selector = null;
    private IHoverSelect HoverSelector = null;
    private Targeter TargetSystem = null;
    private IClicker ClickerSystem = null;

    private RaycastHit TempHit;
    private void Awake()
    {
        Selector = GetComponent<ISelector>();
        ClickerSystem = GetComponent<IClicker>();
        HoverSelector = GetComponent<IHoverSelect>();
        TargetSystem = GetComponent<Targeter>();
        RayMaker = GetComponent<IRayMaker>();
      
    }

    
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (DragMovement.Dragging) return;
        TempHit = RayMaker.CreateRay();
        Hovering();
        Clicker();
    }

    private void Hovering()
    {
        if (TempHit.collider != null && TempHit.collider.GetComponentInChildren<IHoverable>() != null) HoverSelector.OnHover(TempHit.collider.gameObject);
        else HoverSelector.OnUnHover();
    }

    private void Clicker()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(Targeting(TempHit.collider)) return;
            Selector.OnSelect(TempHit);
            if(TempHit.collider != null) ClickerSystem.OnClick(TempHit.collider.gameObject);
        }
    }

    private bool Targeting(Collider OBJ)
    {
       
        if (OBJ == null|| !Targeter.InTargetMode) return false;
        Targeter.SetTarget(OBJ.gameObject);
        Selector.OnDeSelect();
        return true;
    }

}