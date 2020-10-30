using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using CodeMonkey.Utils; //De aca se saca una funcion que me da la posicion del click del mouse
using CodeMonkey;

public class Pruebas : MonoBehaviour
{
    public Pathfinding pathfinding;

    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 posicionMouse = UtilsClass.GetMouseWorldPosition();   //Me guarda la posicion del mouse en la pantalla
            pathfinding.ObtCuadricula().GetXY(posicionMouse, out int x, out int y);
            List<Nodo_PathF> camino = pathfinding.EnconCamino(0, 0, x, y);
            if (camino != null)
            {
                for (int i = 0; i < camino.Count - 1; i++)
                {                    
                    //Ciclo para mostrar con una linea en la cuadricula el camino directo a la posicion del mouse
                    Debug.DrawLine(new Vector3(camino[i].x, camino[i].y) * 10f + Vector3.one * 5f, new Vector3(camino[i + 1].x, camino[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 2f);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 posicionMouse = UtilsClass.GetMouseWorldPosition();   //Me guarda la posicion del mouse en la pantalla
            pathfinding.ObtCuadricula().GetXY(posicionMouse, out int x, out int y);
            pathfinding.ObtNodo(x, y).DefSeCamina(!pathfinding.ObtNodo(x, y).seCamina);
        }
    }
}
