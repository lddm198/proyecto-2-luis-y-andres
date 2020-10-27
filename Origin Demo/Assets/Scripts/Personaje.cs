using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
// caracteres que me indican el tipo de habilidad que posee el jugador   
string[] ventajasJ1= new string []{"velocidad", "alcance"};
string[] ventajasJ2= new string []{"fuerza", "alcance"};
string[] ventajasJ3= new string []{"fuerza", "velocidad"};

//arreglo de valores que me indican las stats del jugador
//orden{velocidad,alcance,fuerza,escudo}
int[] statsJ1=new int[]{15,2,25,0,100};
int[] statsJ2=new int[]{15,2,25,0,100};
int[] statsJ3=new int[]{15,2,25,0,100};

void enUso()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        Debug.Log("Presionó espacio");
    }
}

}



