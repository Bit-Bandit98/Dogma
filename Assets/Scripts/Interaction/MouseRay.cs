using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRay : MonoBehaviour, IRayMaker
{

    public RaycastHit CreateRay()
    {
        RaycastHit HitRay;
        Ray NewRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(NewRay, out HitRay);
        return HitRay;
    }

}