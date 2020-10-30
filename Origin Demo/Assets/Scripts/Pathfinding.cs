using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    private const int CostoRecto = 10;  //Costo al moverse en linea recta
    private const int CostoDiagonal = 14; //Costo al moverse diagonalmente

    private Cuadricula<Nodo_PathF> cuadricula;
    private List<Nodo_PathF> lisAbierta;  //Lista de los cuadros que faltan por evaluar
    private List<Nodo_PathF> lisCerrada;  //Lista de los cuadros ya evaluados

    public Pathfinding(int ancho, int alto){
        cuadricula = new Cuadricula<Nodo_PathF>(ancho, alto, 10f, Vector3.zero, (Cuadricula<Nodo_PathF> c, int x, int y) => new Nodo_PathF(c, x, y));
    }

    public Cuadricula<Nodo_PathF> ObtCuadricula()
    {
        return cuadricula;
    }


    public List<Nodo_PathF> EnconCamino(int incioX, int inicioY, int finalX, int finalY) {
        Nodo_PathF nodoInicio = cuadricula.ObtObjeto(incioX, inicioY);   //El cuadro desde donde se inica la busqueda
        Nodo_PathF nodoFinal = cuadricula.ObtObjeto(finalX, finalY);   //El cuadro desde donde se termina la busqueda

        lisAbierta = new List<Nodo_PathF> { nodoInicio };
        lisCerrada = new List<Nodo_PathF>();

        for (int x = 0; x < cuadricula.ObtAncho(); x++) {      //Ciclo para inicar la lista
            for (int y = 0; y < cuadricula.ObtAlto(); y++) {
                Nodo_PathF nodo = cuadricula.ObtObjeto(x, y);
                nodo.costoG = int.MaxValue;
                nodo.CalcularCostoF();
                nodo.nodoAnterior = null;
            }
        }

        nodoInicio.costoG = 0;
        nodoInicio.costoH = CalcularDistancia(nodoInicio, nodoFinal);
        nodoInicio.CalcularCostoF();

        while (lisAbierta.Count > 0) {
            Nodo_PathF nodoActual = MenorCostoF(lisAbierta);
            if (nodoActual == nodoFinal) {  //Si se llega al nodo final, se devuelde el camino
                return CaminoCalculado(nodoFinal);                    
            }

            lisAbierta.Remove(nodoActual);    //Se elimina el actual de la lista por buscar y se añade a la de buscados ya que no es el final
            lisCerrada.Add(nodoActual);

            foreach (Nodo_PathF nodoVecino in ObtListaVecinos(nodoActual)) {
                if (lisCerrada.Contains(nodoVecino)) continue;  //Si ya revizamos este nodo solo se ignora
                if (!nodoVecino.seCamina) {  //Si el nodo vecino esta bloqueado, se ignora y se sigue con el resto
                    lisCerrada.Add(nodoVecino);
                    continue;
                }

                int posibleCostoG = nodoActual.costoG + CalcularDistancia(nodoActual, nodoVecino);   //Un posible costo g con el vecino evaluado en ese momento
                if (posibleCostoG < nodoVecino.costoG) {   //Si se encuentra un camino mas corto
                    nodoVecino.nodoAnterior = nodoActual;
                    nodoVecino.costoG = posibleCostoG;
                    nodoVecino.costoH = CalcularDistancia(nodoVecino, nodoFinal);
                    nodoVecino.CalcularCostoF();

                    if (!lisAbierta.Contains(nodoVecino)) lisAbierta.Add(nodoVecino);  //Si no esta en la lista por buscar, se agrega
                }
            }
        }

        //Si se acaban los nodos por buscar, quiere decir que no hay ruta posible
        return null;
    }

    private List<Nodo_PathF> ObtListaVecinos(Nodo_PathF nodoActual) {    //Funcion para obtener todos los nodos alrededor del actual
        List<Nodo_PathF> lisVecinos = new List<Nodo_PathF>();

        if (nodoActual.x - 1 >= 0) { //Se verifica que existan nodos en esa posicion
            //Izquierda
            lisVecinos.Add(ObtNodo(nodoActual.x - 1, nodoActual.y));
            //Izquierda abajo
            if (nodoActual.y - 1 >= 0) lisVecinos.Add(ObtNodo(nodoActual.x - 1, nodoActual.y - 1));
            //Izquierda arriba
            if (nodoActual.y + 1 < cuadricula.ObtAlto()) lisVecinos.Add(ObtNodo(nodoActual.x - 1, nodoActual.y + 1));
        }

        if (nodoActual.x + 1 < cuadricula.ObtAncho()) { //Se verifica que existan nodos en esa posicion
            //Derecha
            lisVecinos.Add(ObtNodo(nodoActual.x + 1, nodoActual.y));
            //Derecha abajo
            if (nodoActual.y - 1 >= 0) lisVecinos.Add(ObtNodo(nodoActual.x + 1, nodoActual.y - 1));
            //Derecha arriba
            if (nodoActual.y + 1 < cuadricula.ObtAlto()) lisVecinos.Add(ObtNodo(nodoActual.x + 1, nodoActual.y + 1));
        }

        //Abajo
        if (nodoActual.y - 1 >= 0) lisVecinos.Add(ObtNodo(nodoActual.x, nodoActual.y - 1));
        //Arriba
        if (nodoActual.y + 1 < cuadricula.ObtAlto()) lisVecinos.Add(ObtNodo(nodoActual.x, nodoActual.y +  1));

        return lisVecinos;
    }

    public Nodo_PathF ObtNodo(int x, int y) {   //Funcion para obtener un nodo
        return cuadricula.ObtObjeto(x, y);
    }

    private List<Nodo_PathF> CaminoCalculado(Nodo_PathF nodoFinal) {
        List<Nodo_PathF> camino = new List<Nodo_PathF>();
        camino.Add(nodoFinal);
        Nodo_PathF nodoActual = nodoFinal;

        while (nodoActual.nodoAnterior != null) { //Ciclo para ir marcha atras entre los nodos hasta llegar al del inicio, agregando los nodos del camino posible
            camino.Add(nodoActual.nodoAnterior);
            nodoActual = nodoActual.nodoAnterior;
        }
        camino.Reverse();    //Para darle vuelta al camino ya que lo buscamos de atras para adelante
        return camino;
    }

    private int CalcularDistancia(Nodo_PathF a, Nodo_PathF b) {  //Funcion para calcular la distancia mas corta
        int DistanciaX = Mathf.Abs(a.x - b.x);
        int DistanciaY = Mathf.Abs(a.y - b.y);
        int restante = Mathf.Abs(DistanciaX - DistanciaY);

        return CostoDiagonal * Mathf.Min(DistanciaX, DistanciaY) + CostoRecto * restante;
    }

    private Nodo_PathF MenorCostoF(List<Nodo_PathF> lisNodos) {  //Funcion para returnar el costo f mas bajo
        Nodo_PathF nodoCostoFBajo = lisNodos[0];

        for (int i = 1; i < lisNodos.Count; i++) {    //Ciclo para comparar los costos f de todos los nodos y elegir el mas bajo
            if (lisNodos[i].costoF < nodoCostoFBajo.costoF) {
                nodoCostoFBajo = lisNodos[i];
            }
        }
        return nodoCostoFBajo;
    }

}
