using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private float value;

    public int ID => id;

}
