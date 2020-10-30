using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecturaDeMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GetComponent<MoverPosicion>().DefPosicion(UtilsClass.GetMouseWorldPosition()); //Le envia la posicion del mouse para moverlo mas adelante
        }     
    }
}
