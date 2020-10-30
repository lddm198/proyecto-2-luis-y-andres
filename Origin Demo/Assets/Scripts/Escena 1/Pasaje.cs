using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasaje : MonoBehaviour
{

    public GameObject target;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Personaje1")
        {
            print("Ha chocado el jugador");
            other.transform.position = target.transform.position;
        }
    }
}
