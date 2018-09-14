using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDevice : MonoBehaviour
{
    [SerializeField] private Vector3 openPos;
    private bool doorOpen;

    public void Operate()
    {
        if(doorOpen)
        {
            Vector3 pos = transform.position - openPos;
            transform.position = pos;
        } else 
        {
            Vector3 pos = transform.position + openPos;
            transform.position = pos;
        }
        doorOpen = !doorOpen;
    }
}
