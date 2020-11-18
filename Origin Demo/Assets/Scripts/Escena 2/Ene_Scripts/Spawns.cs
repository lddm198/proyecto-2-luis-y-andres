using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour
{
    
    public GameObject zombie;
    public GameObject ojoVolador;
    public GameObject demonio;

    public GameObject lapida1_1;
    public GameObject lapida2_1;
    public GameObject lapida3_1;
    
    public int cantZombies, cantOjo, cantDemonio;
    private bool spawnOjo = true, spawnZombie= true, spawnDemonio= true;
    private int x = 0, y = 0, z = 0, pos1 = 0, pos2 = 0, pos3 = 0;

    // creamos tres instancias de listas porque queremos llevar por separado los spawns
    List<Vector3> spawns = new List<Vector3>();
    //Declaramos los spawnpoints para que sean un punto fijo
    



    public float  spawnTimeZombie = 5f,spawnTimeOjo = 1f,spawnTimeDemonio = 1f;
    public SistemaTurnos lista;

    
    void Start(){

        //declaramos en que spawn va a aparecer (x,y,z)
        if (spawnZombie){InvokeRepeating("generarZombie", 0.0f,spawnTimeZombie);}
        if (spawnOjo){InvokeRepeating("generarOjo", 0.0f,spawnTimeOjo);}
        if (spawnDemonio){InvokeRepeating("generarDemonio", 0.0f,spawnTimeDemonio);}
        //se pueden agregar mas lapidas al mapa y más spawns para enemigos

        spawns.Add(new Vector3(lapida1_1.transform.position.x,lapida1_1.transform.position.y,160f));
        spawns.Add(new Vector3(lapida2_1.transform.position.x,lapida2_1.transform.position.y,160f));
        spawns.Add(new Vector3(lapida3_1.transform.position.x,lapida3_1.transform.position.y,160f));


    }
    public void generarZombie(){
        //instanciamos un clon
        GameObject Zombie = Instantiate (zombie,spawns[pos1],Quaternion.identity);
//        lista.AnadirEnemigo(Zombie);

        if (pos1 == 2){pos1=0;}
        x++;
        if (cantZombies == x){CancelInvoke ("generarZombie");spawnZombie= false;}
        pos1++;
        
    }

    public void generarOjo(){
        //instanciamos un clon
        GameObject Ojo = Instantiate (ojoVolador,spawns[pos2],Quaternion.identity);
       // lista.AnadirEnemigo(Ojo);

        if (pos2 == 2){pos2=0;}  
        y++;
        if ( cantOjo == y){CancelInvoke ("generarOjo");spawnOjo= false;}       
        pos2++;
    }
    public void generarDemonio(){
        //instanciamos un clon
        GameObject Demonio = Instantiate (demonio,spawns[pos3],Quaternion.identity);
        //lista.AnadirEnemigo(Demonio);

        z++;
        pos3++;
        if (pos3 == 2){pos3=0;}
        if (cantDemonio == z){CancelInvoke ("generarDemonio");spawnDemonio= false;}
    }
}
