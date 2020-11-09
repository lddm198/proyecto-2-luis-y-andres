using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : MonoBehaviour, MiVelocidad
{
    [SerializeField] private float velocidadMov;// espacio para la velocidad

    private Vector3 vectorVelocidad;
    private Rigidbody2D rigidbody2D;

    private void Awake(){
        rigidbody2D= GetComponent<Rigidbody2D>(); //llamamos al rigid body, para poder manipularle
    }
    public void setVelocidad(Vector3 vectorVelocidad){
        this.vectorVelocidad= vectorVelocidad; //declaramos el método para los valores del vector de velocidad
    }

    private void FixedUpdate(){
        rigidbody2D.velocity =vectorVelocidad * velocidadMov; // seteamos la velocidad que contendrá el rigis body 

    }
}
