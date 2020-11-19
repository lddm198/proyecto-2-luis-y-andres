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
    public Slider sliderVida;
    public float VidaMax;
    public float VidaActual;
    public bool seMovio;
    public bool ataco;
    public Animator animacion;
    public bool Muerto;

    public void Morir() {
        animacion.SetBool("Muerte", true);
        Muerto = true;
        ataco = true;
        seMovio = true;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Unidad>().enabled = false;
        GetComponent<reaccionEnemigo>().enabled = false;
        GetComponent<MovimientoPathfindingEnemigos>().enabled = false;
        this.enabled = false;
        Debug.Log("El " + Nombre + " ha muerto!!");
    }
}
