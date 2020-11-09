using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MovimientoRandom : MonoBehaviour
{
    private Vector3 posInicial;
    private Vector3 posObjetivo;

    private void Awake(){
        posInicial = transform.position;
    }

    private void Start(){
        setMovRandom();
    }

    private void setMovRandom(){
        posObjetivo = posInicial + UtilsClass.GetRandomDir() * Random.Range(30f, 100f);
    }

    private void Update(){
        setMovDireccion(posObjetivo);

        float llegada = 1f;
        if (Vector3.Distance(transform.position, posObjetivo)< llegada){
            setMovRandom();
        }
    }
    private void setMovDireccion(Vector3 movDireccion){
        GetComponent<MiDireccion>().setMovDireccion(movDireccion);
    }
}
