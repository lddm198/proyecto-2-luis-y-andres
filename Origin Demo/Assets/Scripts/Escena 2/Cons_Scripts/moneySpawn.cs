using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneySpawn : MonoBehaviour
{
    public GameObject moneda;
    public GameObject comida;
    public GameObject coleccionables;
    public int cantMoneda, cantComida, cantColeccionables;
    public float rangoGenerar = 0f;
    

    private float  spawnTimeMoneda = 0f,spawnTimeComida = 0f,spawnTimeColeccionables = 0f ;

    void Start(){
        for (int x = 0; x < cantMoneda; x++)
        {
            InvokeRepeating("generarMoneda",0.0f,spawnTimeMoneda);
        }
        //for (int i = 0; i < cantComida; i++)
        //{
            //InvokeRepeating("generarComida",0.0f,spawnTimeComida);
        //}
        //for (int j = 0; j < cantColeccionables; j++)
        //{
            //InvokeRepeating("generarColeccionables",0.0f,spawnTimeColeccionables);
        //}
        
            
    }
    void Update()
    {
        
    }
    public void generarMoneda(){
        
        
        Vector3 spawnMoneda = new Vector3(0,0,0);
        spawnMoneda = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnMoneda = new Vector3(spawnMoneda.x, spawnMoneda.y,160);

        GameObject Moneda = Instantiate (moneda,spawnMoneda,Quaternion.identity);
         
    }
    public void generarComida(){

        Vector3 spawnComida = new Vector3(0,0,0);
        spawnComida = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnComida = new Vector3(spawnComida.x, spawnComida.y,160);

        GameObject Espora = Instantiate (comida,spawnComida,Quaternion.identity);
         
    }
    public void generarColeccionables(){
        
        Vector3 spawnColeccionables = new Vector3(0,0,0);
        spawnColeccionables = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnColeccionables = new Vector3(spawnColeccionables.x, spawnColeccionables.y,160);
        
        GameObject Coleccionables = Instantiate (coleccionables,spawnColeccionables,Quaternion.identity);
         
    }
}
