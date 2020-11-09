using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecturaDeMouse : MonoBehaviour
{
    public List<Vector3> bloqueados;
    
    //public Pathfinding pathfinding = new Pathfinding(20, 10);
    // Update is called once per frame
    void Update()
    {  
        if (Input.GetMouseButtonDown(0)) {
           
            GetComponent<MovimientoPathfinding>().DefPosicion(UtilsClass.GetMouseWorldPosition(), bloqueados); //Le envia la posicion del mouse para moverlo mas adelante
        }

        if (Input.GetMouseButtonDown(1))
        {
            bloqueados.Add(UtilsClass.GetMouseWorldPosition());
            Debug.Log(UtilsClass.GetMouseWorldPosition());
        }
    }
}
