using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    
    public GameObject mini;
    public GameObject espora;
    public GameObject ogro;

    public GameObject lapida1_1;
    public GameObject lapida2_1;
    public GameObject lapida3_1;
    
    public int cantMini, cantEspora, cantOgro;
    private int x = 0, y = 0, z = 0, pos1 = 0, pos2 = 0, pos3 = 0;

    // creamos tres instancias de listas porque queremos llevar por separado los spawns
    List<Vector3> spawns = new List<Vector3>();
    //Declaramos los spawnpoints para que sean un punto fijo
    



    public float  spawnTimeMini = 5f,spawnTimeEspora = 10f,spawnTimeOgro = 15f;

    void Start(){
        
        InvokeRepeating("generarMini",0.0f,spawnTimeMini);
        InvokeRepeating("generarEspora",10.0f,spawnTimeEspora);
        InvokeRepeating("generarOgro",20.0f,spawnTimeOgro);

        //declaramos en que spawn va a aparecer (x,y,z)

        //se pueden agregar mas lapidas al mapa y más spawns para enemigos

        spawns.Add(new Vector3(lapida1_1.transform.position.x,lapida1_1.transform.position.y,160f));
        spawns.Add(new Vector3(lapida2_1.transform.position.x,lapida2_1.transform.position.y,160f));
        spawns.Add(new Vector3(lapida3_1.transform.position.x,lapida3_1.transform.position.y,160f));


    }
    public void generarMini(){
        //instanciamos un clon
        GameObject Mini = Instantiate (mini,spawns[pos1],Quaternion.identity);

        x++;
        pos1++;
        if (pos1 == 2){pos1=0;}
        if (cantMini == x){CancelInvoke ("generarMini");}
    }

    public void generarEspora(){
        //instanciamos un clon
        GameObject Espora = Instantiate (espora,spawns[pos2],Quaternion.identity);

        y++;      
        pos2++;
        if (pos2 == 2){pos2=0;}  
        if ( cantEspora != y){CancelInvoke ("generarEspora");} 
    }

    public void generarOgro(){
        //instanciamos un clon
        GameObject Ogro = Instantiate (ogro,spawns[pos3],Quaternion.identity);
        
        z++;
        pos3++;
        if (pos3 == 2){pos3=0;}
        if (cantOgro != z){CancelInvoke ("generarEspora");}
    }
}
