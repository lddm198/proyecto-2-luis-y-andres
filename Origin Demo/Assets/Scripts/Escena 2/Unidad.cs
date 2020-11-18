using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Tipos { Personaje, Enemigo }

public class Unidad : MonoBehaviour
{
    public string Nombre;
    public Tipos tipo;
    public int Daño;
<<<<<<< HEAD
=======
    public Slider sliderVida;
>>>>>>> 2f221ae97e0e37387b7ca96ceb8e12e0e09d175d
    public float VidaMax;
    public float VidaActual;
    public bool seMovio;
    public bool ataco;
    public Animator animacion;

    public void Morir() {
        animacion.SetBool("Muerte", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Debug.Log("El " + Nombre + " ha muerto!!");
    }
}
