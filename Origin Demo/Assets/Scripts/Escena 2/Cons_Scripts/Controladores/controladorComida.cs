using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorComida : MonoBehaviour
{
     public GameObject cereza;
    public GameObject sandia;
    public GameObject manzana;
    public int cantCerezas, cantSandias, cantManzanas;
    public float rangoGenerar = 0f;
    

    private float  spawnTimeCereza = 0f,spawnTimeSandia = 0f,spawnTimeManzana = 0f ;

    void Start(){
        for (int x = 0; x < cantCerezas; x++)
        {
            InvokeRepeating("generarCerezas",0.0f,spawnTimeCereza);
        }
        for (int i = 0; i < cantSandias; i++)
        {
            InvokeRepeating("generarSandias",0.0f,spawnTimeSandia);
        }
        for (int j = 0; j < cantManzanas; j++)
        {
            InvokeRepeating("generarManzanas",0.0f,spawnTimeManzana);
        }
        
            
    }
    void Update()
    {
        
    }
    public void generarCerezas(){
        
        
        Vector3 spawnCereza = new Vector3(0,0,0);
        spawnCereza = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnCereza = new Vector3(spawnCereza.x, spawnCereza.y,160);

        GameObject Cereza = Instantiate (cereza,spawnCereza,Quaternion.identity);
         
    }
    public void generarSandias(){

        Vector3 spawnSandia = new Vector3(0,0,0);
        spawnSandia = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnSandia = new Vector3(spawnSandia.x, spawnSandia.y,160);

        GameObject Sandia = Instantiate (sandia,spawnSandia,Quaternion.identity);
         
    }
    public void generarManzanas(){
        
        Vector3 spawnManzana = new Vector3(0,0,0);
        spawnManzana = this.transform.position + Random.onUnitSphere * rangoGenerar;
        spawnManzana = new Vector3(spawnManzana.x, spawnManzana.y,160);
        
        GameObject Manzana = Instantiate (manzana,spawnManzana,Quaternion.identity);
         
    }
}
