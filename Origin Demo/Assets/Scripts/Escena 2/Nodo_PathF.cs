using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo_PathF{   //Este es un objeto que va a ser un nodo para hacer el pathfinding

    private Cuadricula<Nodo_PathF> cuad;
    public int x;
    public int y;

    public int costoG;   //El costo del camino mas largo al nodo final
    public int costoH;   //El costo del camino mas corto (ignorando partes bloqueadas) al nodo final
    public int costoF;   // F = G + H

    public bool seCamina;
    public Nodo_PathF nodoAnterior;  //Este es el nodo del que se vino

    public Nodo_PathF(Cuadricula<Nodo_PathF> cuad, int x, int y) {
        this.cuad = cuad;
        this.x = x;
        this.y = y;
        seCamina = true;
    }

    public void CalcularCostoF()
    {
        costoF = costoG + costoH;
    }

    public void DefSeCamina(bool seCamina) {
        this.seCamina = seCamina;
        cuad.ActivarCambioCuadricula(x, y);
    }

    public override string ToString()
    {
        return x + "," + y;
    }

}
