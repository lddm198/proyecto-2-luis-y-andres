using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovimientoPathfinding : MonoBehaviour
{
    private List<Nodo_PathF> lisCaminoNod;
    private int indCamino = -1;
    public Pathfinding pathfinding;
    private List<Vector3> bloqueados;
    public int xIni, yIni, xFin, yFin;
    public Rigidbody2D rb;
    public Animator animacion;
    Vector3 sgtePosicion;
    Vector3 moverposicion;

    public void DefPosicion(Vector3 moverPosicion, List<Vector3> bloq) {
        this.moverposicion = moverPosicion;
        pathfinding = new Pathfinding(34, 14);
        bloqueados = bloq.ToList();
        while(bloqueados.Count > 0) {
            if(bloqueados[0] != Vector3.zero)
            {
                Block(bloqueados[0]);
                bloqueados.RemoveAt(0);
            }
        }

        pathfinding.ObtCuadricula().GetXY(transform.position, out xIni, out yIni);  //Se saca en x,y la posicion del objeto actualmente
        pathfinding.ObtCuadricula().GetXY(moverPosicion, out xFin, out yFin);  //Se saca en x,y la posicion final

        lisCaminoNod = pathfinding.EnconCamino(xIni, yIni, xFin, yFin);    //Lista del camino en Nodos de pathfinding

        if (lisCaminoNod.Count > 0) indCamino = 0;
        if (lisCaminoNod != null) {
            for (int i = 0; i < lisCaminoNod.Count - 1; i++) {
                //Debug.DrawLine(new Vector3(lisCaminoNod[i].x, lisCaminoNod[i].y) * 10f + Vector3.one * 5f, new Vector3(lisCaminoNod[i + 1].x, lisCaminoNod[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 2f);
            }
        }
    }

    public void Block(Vector3 posicion) {
        pathfinding.ObtCuadricula().GetXY(posicion, out int x1, out int y1);
        pathfinding.ObtNodo(x1, y1).DefSeCamina(false);
    }

    // Update is called once per frame
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
            GetComponent<RangoMovimiento>().DefRango(velocidad);

            float distanciaPosicionAlcanzada = 1f;
            if (Vector3.Distance(transform.position, sgtePosicion) < distanciaPosicionAlcanzada) {
                indCamino++;
                if (indCamino >= lisCaminoNod.Count) indCamino = -1; //Fin del camino
            } 
        }
        else {
            //Quieto
            animacion.SetBool("Movimiento", false);
            GetComponent<RangoMovimiento>().DefRango(Vector3.zero);
        }
    }
}
