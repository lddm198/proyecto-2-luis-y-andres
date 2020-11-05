using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPosicion : MonoBehaviour
{
    private Vector3 moverPosicion;

    public void DefPosicion(Vector3 moverPosicion)
    {
        this.moverPosicion = moverPosicion;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 moverPos = (moverPosicion - transform.position).normalized;
        GetComponent<RangoMovimiento>().DefRango(moverPos);
    }
}
