using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasos : MonoBehaviour
{
    public AudioSource pasos;
    Vector3 posInicial = new Vector3(0,0,0);
    GameObject jugador;

    
    void Start()
    {
        pasos = GetComponent<AudioSource>();
        jugador = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update(){
            
        if (posInicial != jugador.transform.position) {
            if (!pasos.isPlaying){
                //pasos.Play();
            }

        }
        posInicial= jugador.transform.position;
    }
        
}

