using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDirecto : MonoBehaviour, MiDireccion
{
    private Vector3 movDireccion;

    public void setMovDireccion (Vector3 movDireccion){
        this.movDireccion = movDireccion;
    }

    private void Update(){
        Vector3 movDir = (movDireccion - transform.position).normalized;
        GetComponent<MiVelocidad>().setVelocidad(movDir);
    }
}
