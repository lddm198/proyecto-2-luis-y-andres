using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipos { Personaje, Enemigo }

public class Unidad : MonoBehaviour
{
    public string Nombre;
    public Tipos tipo;
    public int Daño;
    public int VidaMax;
    public int VidaActual;
    public bool seMovio;
    public bool ataco;

}
