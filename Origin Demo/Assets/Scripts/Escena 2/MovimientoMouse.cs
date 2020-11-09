using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MovimientoMouse : MonoBehaviour
{
   
   private void Update(){
       if (Input.GetMouseButtonDown(1)){
           GetComponent<MiDireccion>().setMovDireccion(UtilsClass.GetMouseWorldPosition());
       }
   }
}
