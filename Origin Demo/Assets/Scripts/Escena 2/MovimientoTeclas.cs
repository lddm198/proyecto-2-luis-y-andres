using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTeclas : MonoBehaviour
{
    private void Update()
    {
        float movX = 0f;
        float movY = 0f;


        if (Input.GetKey(KeyCode.W)) movY = +1f;
        if (Input.GetKey(KeyCode.S)) movY = -1f;
        if (Input.GetKey(KeyCode.A)) movX = -1f;
        if (Input.GetKey(KeyCode.D)) movX = +1f;

        Vector3 vectorMov = new Vector3(movX,movY).normalized;
        GetComponent<MiVelocidad>().setVelocidad(vectorMov);
    }
}
