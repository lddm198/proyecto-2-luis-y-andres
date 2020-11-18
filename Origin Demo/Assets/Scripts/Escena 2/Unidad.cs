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

}
