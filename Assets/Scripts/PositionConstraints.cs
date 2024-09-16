using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionConstraints : MonoBehaviour
{
    [SerializeField] private Vector3 MinCoordinates, Maxcoordinates;
   

    // Update is called once per frame
    void LateUpdate()
    {
        CheckCoordinates();
    }

    private void CheckCoordinates()
    {
        float x = Mathf.Clamp(transform.localPosition.x, MinCoordinates.x, Maxcoordinates.x);
        float y = Mathf.Clamp(transform.localPosition.y, MinCoordinates.y, Maxcoordinates.y);
        float z = Mathf.Clamp(transform.localPosition.z, MinCoordinates.z, Maxcoordinates.z);

        
        transform.localPosition = new Vector3(x, y, z);
    }
}
