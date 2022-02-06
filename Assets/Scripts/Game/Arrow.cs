using System;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Item collidedObject;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Item>())
            collidedObject = other.gameObject.GetComponent<Item>();
    }
}