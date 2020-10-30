using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoMovimiento : MonoBehaviour
{

    [SerializeField] private float rangoMov;

    private Vector3 vectorRango;

    // Start is called before the first frame update
    //private void Awake()
    //{
        
   //}

    public void DefRango(Vector3 vectorRango)
    {
        this.vectorRango = vectorRango;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vectorRango * rangoMov * Time.deltaTime;
    }
}
