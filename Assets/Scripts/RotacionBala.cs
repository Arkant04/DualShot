using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionBala : MonoBehaviour
{
    Vector3 rotacion = new Vector3(0, 0, 10);
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rotacion);
    }
}
