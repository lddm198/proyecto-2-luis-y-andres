using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioVelocidad : MonoBehaviour, MiVelocidad //extendemos "MiVelocidad" para implementar las interfaces 
{
   [SerializeField] private float velocidadMov;// espacio para la velocidad

    private Vector3 vectorVelocidad;

    public void setVelocidad(Vector3 vectorVelocidad){
        this.vectorVelocidad= vectorVelocidad; //declaramos el método para los valores del vector de velocidad
    }

    private void Update(){
        transform.position += vectorVelocidad * velocidadMov * Time.deltaTime;
    }
}
