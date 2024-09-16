using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    [SerializeField] private float Speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Movement();   
    }

    private void Movement()
    {
        Vector3 AddPosition = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Speed;
        AddPosition = transform.TransformDirection(AddPosition);
        transform.localPosition += AddPosition * Time.deltaTime;
    }
}
