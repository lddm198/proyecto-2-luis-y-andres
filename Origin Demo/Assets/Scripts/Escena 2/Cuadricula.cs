using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;  //Este paquete es el que ayuda a crear el texto de la cuadricula
using System;

public class Cuadricula<TObjetoCuad> {

    public event EventHandler<CuadCambioDeObjetoEventArgs> CuadCambioDeObjeto;
    public class CuadCambioDeObjetoEventArgs : EventArgs {
        public int x;
        public int y;
    }

    int ancho;
    int alto;
    public TObjetoCuad[,] matCuadricula;      //Matriz de la cuadricula
    private float tamCuadro;                  //Tamaño de cada cuadro de la cuadricula
    private Vector3 PosicionOrigen;           //Posicion de origen de la cuadricula
    public TextMesh[,] DebugCuadricula;       //Cuadricula para poder ver los cambios de los valores

    public Cuadricula(int ancho, int alto, float tamCuadro, Vector3 PosicionOrigen, Func<Cuadricula<TObjetoCuad>, int, int, TObjetoCuad> crearObjetoCuad){
        this.ancho = ancho;
        this.alto = alto;
        this.tamCuadro = tamCuadro;
        this.PosicionOrigen = PosicionOrigen;

        matCuadricula = new TObjetoCuad[ancho, alto];
        DebugCuadricula = new TextMesh[ancho, alto];

        for (int x = 0; x < matCuadricula.GetLength(0); x++) { //Ciclo para crear un objeto en cada cuadro de la cuadricula
            for (int y = 0; y < matCuadricula.GetLength(1); y++) {
                matCuadricula[x, y] = crearObjetoCuad(this, x, y);

            }
        }
        bool debug = false;
        if (debug)
        {
            //Ciclos para crear texto en cada espacio de la cuadricula (debug)
            for (int x = 0; x < matCuadricula.GetLength(0); x++)
            {
                for (int y = 0; y < matCuadricula.GetLength(1); y++)
                {
                    DebugCuadricula[x, y] = UtilsClass.CreateWorldText(matCuadricula[x, y]?.ToString(), null, GetPosicionMundo(x, y) + new Vector3(tamCuadro, tamCuadro) * .5f, 30, Color.white, TextAnchor.MiddleCenter); //Aqui se crea el texto
                    Debug.DrawLine(GetPosicionMundo(x, y), GetPosicionMundo(x, y + 1), Color.white, 100f); //Los debug.DrawLine se estan uasndo para hacer 
                    Debug.DrawLine(GetPosicionMundo(x, y), GetPosicionMundo(x + 1, y), Color.white, 100f); //la cuadricula visible 
                }
            }
            Debug.DrawLine(GetPosicionMundo(0, alto), GetPosicionMundo(ancho, alto), Color.white, 100f); //Para rellenar la parte de arriba y de la derecha 
            Debug.DrawLine(GetPosicionMundo(ancho, 0), GetPosicionMundo(ancho, alto), Color.white, 100f); //de la cuadricula
        }

    }

    public Vector3 GetPosicionMundo(int x, int y){
        return new Vector3(x, y) * tamCuadro + PosicionOrigen;
    }

    public void GetXY(Vector3 posicion, out int x, out int y) {  //Se utiliza el out para poder retornar mas de un valor
        x = Mathf.FloorToInt((posicion - PosicionOrigen).x / tamCuadro);
        y = Mathf.FloorToInt((posicion - PosicionOrigen).y / tamCuadro);

    }

    public int ObtAncho()   //Funcion que me devuelve el ancho de la cuadricula
    {
        return ancho;
    }

    public int ObtAlto()   //Funcion que me devuelve el alto de la cuadricula
    {
        return alto;
    }

    public float ObtTamCuadro()
    {
        return tamCuadro;
    }

    public void DefObjeto(int x, int y, TObjetoCuad valor) {  //Funcion para definir el objeto de un cuadro
        if(x >= 0 && y >= 0 && x < ancho && y < alto) {  //Se valida la posicion de la cuadricula para cambiar el objeto
            matCuadricula[x, y] = valor;
            DebugCuadricula[x, y].text = matCuadricula[x, y].ToString();
            if (CuadCambioDeObjeto != null) CuadCambioDeObjeto(this, new CuadCambioDeObjetoEventArgs { x = x, y = y });
        } 
    } 

    public void DefObjeto(Vector3 posicion, TObjetoCuad valor) {  //Funcion para definir el objeto de un cuadro al darle click al mismo
        int x, y;
        GetXY(posicion, out x, out y);
        DefObjeto(x, y, valor);
    }

    public TObjetoCuad ObtObjeto(int x, int y) {  //Funcion para obtener el objeto de un cuadro
        if (x >= 0 && y >= 0 && x < ancho && y < alto) {  //Se valida la posicion de la cuadricula para obtener el objeto
            return matCuadricula[x, y];
        }
        else {
            return default(TObjetoCuad);
        }
    }

    public TObjetoCuad ObtObjeto(Vector3 posicion) {  //Funcion para obtener el objeto de un cuadro segun el click del mouse
        int x, y;
        GetXY(posicion, out x, out y);
        return ObtObjeto(x, y);
    }

    public void ActivarCambioCuadricula(int x, int y)
    {
        if (CuadCambioDeObjeto != null) CuadCambioDeObjeto(this, new CuadCambioDeObjetoEventArgs { x = x, y = y });
    }
}
