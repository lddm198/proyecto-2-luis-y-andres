using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
// caracteres que me indican el tipo de habilidad que posee el enemigo (varia por la dificultad)   
string[] ventajasE1= new string []{"velocidad", "alcance"};
string[] ventajasE2= new string []{"fuerza", "alcance"};
string[] ventajasE3= new string []{"fuerza", "velocidad"};

//arreglo de valores que me indican las stats del jugador
//orden{velocidad,alcance,fuerza,escudo}
int[] statsE1=new int[]{15,2,25,0,100};
int[] statsE2=new int[]{15,2,25,0,100};
int[] statsE3=new int[]{15,2,25,0,100};

//determina el estado del enemigo (si ataca, camina o esta en "hold")
public int estado=0;


}