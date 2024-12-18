using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject original;


    public void InstantiateObject()
    {
        Instantiate(original, transform.position, transform.rotation);
    }
}
