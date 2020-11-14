using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovimientoPathfinding : MonoBehaviour
{
    private List<Nodo_PathF> lisCaminoNod;
    private int indCamino = -1;
    public Pathfinding pathfinding;
    private Action EnPosicionFinal;
    public List<Vector3> bloqueados;
    private int xIni, yIni, xFin, yFin;
    public Animator animacion;
    Vector3 sgtePosicion;
    Vector3 moverposicion;

    public void DefPosicion(Vector3 moverPosicion, List<Vector3> bloq, Action EnPosicionFinal) {
        this.EnPosicionFinal = EnPosicionFinal;
        this.moverposicion = moverPosicion;
        pathfinding = new Pathfinding(34, 14);
        bloqueados = bloq.ToList();
        while(bloqueados.Count > 0) {
            if(bloqueados[0] != Vector3.zero)
            {
                Block(bloqueados[0], pathfinding);
                bloqueados.RemoveAt(0);
            }
        }

        pathfinding.ObtCuadricula().GetXY(transform.position, out xIni, out yIni);  //Se saca en x,y la posicion del objeto actualmente
        pathfinding.ObtCuadricula().GetXY(moverPosicion, out xFin, out yFin);  //Se saca en x,y la posicion final

        lisCaminoNod = pathfinding.EnconCamino(xIni, yIni, xFin, yFin);    //Lista del camino en Nodos de pathfinding

        if (lisCaminoNod.Count > 0) indCamino = 0;
    }

    public void Block(Vector3 posicion, Pathfinding pathfinding) {
        pathfinding.ObtCuadricula().GetXY(posicion, out int x1, out int y1);
        pathfinding.ObtNodo(x1, y1).DefSeCamina(false);
    }
   
    void FixedUpdate()
    {
        if (indCamino != -1) {
            //Moverse a la siguiente posicion
            animacion.SetBool("Movimiento", true);
            sgtePosicion = pathfinding.ObtCuadricula().GetPosicionMundo(lisCaminoNod[indCamino].x, lisCaminoNod[indCamino].y) + Vector3.one * 5f;
            pathfinding.ObtCuadricula().GetXY(transform.position, out int x, out int y);
            pathfinding.ObtCuadricula().GetXY(moverposicion, out int x2, out int y2);

            if (x > x2) {
                transform.eulerAngles = Vector3.up * 180;
            }
            if (x < x2) {
                transform.eulerAngles = Vector3.zero;
            }

            Vector3 velocidad = (sgtePosicion - transform.position).normalized;
            GetComponent<VelocidadMovimiento>().DefVelocidad(velocidad);

            float distanciaPosicionAlcanzada = 1f;
            if (Vector3.Distance(transform.position, sgtePosicion) < distanciaPosicionAlcanzada) {
                indCamino++;
                if (indCamino >= lisCaminoNod.Count) {
                    indCamino = -1; //Fin del camino
                    EnPosicionFinal();
                }
            }
        }
        else {
            //Quieto
            animacion.SetBool("Movimiento", false);
            GetComponent<VelocidadMovimiento>().DefVelocidad(Vector3.zero);
        }
    }
}
