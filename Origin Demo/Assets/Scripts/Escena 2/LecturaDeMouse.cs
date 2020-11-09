using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecturaDeMouse : MonoBehaviour
{
    public List<Vector3> bloqueados;

    private void Start()
    {
        bloqueados = new List<Vector3>()
        {
        new Vector3(134.9f, 23f, 0f),
        new Vector3(94.1f, 113.7f, 0f),
        new Vector3(185.7f, 96.6f, 0f),
        new Vector3(85.1f, 66.2f, 0f),
        new Vector3(82.7f, 74.3f, 0f),
        new Vector3(24.3f, 14f, 0f),
        new Vector3(62.7f, 64.8f, 0f),
        new Vector3(64.2f, 73.8f, 0f),
        new Vector3(75.1f, 75.1f, 0f),
        new Vector3(75.1f, 66.2f, 0f),
        new Vector3(154.4f, 137.4f, 0f),
        new Vector3(185.3f, 138.9f, 0f),
        new Vector3(215.7f, 127f, 0f),
        new Vector3(267f, 96.1f, 0f),
        new Vector3(264.1f, 45.3f, 0f),
        new Vector3(264.6f, 37.7f, 0f),
        new Vector3(274.5f, 43.4f, 0f),
        new Vector3(285.9f, 47.2f, 0f),
        new Vector3(275f, 34.4f, 0f),
        new Vector3(283.1f, 34.4f, 0f)
        };
    }

    
    
    //public Pathfinding pathfinding = new Pathfinding(20, 10);
    // Update is called once per frame
    void Update()
    {  
        if (Input.GetMouseButtonDown(0)) {
           
            GetComponent<MovimientoPathfinding>().DefPosicion(UtilsClass.GetMouseWorldPosition(), bloqueados); //Le envia la posicion del mouse para moverlo mas adelante
        }

        if (Input.GetMouseButtonDown(1))
        {
            //bloqueados.Add(UtilsClass.GetMouseWorldPosition());
            //Debug.Log(UtilsClass.GetMouseWorldPosition());
        }
    }
}
