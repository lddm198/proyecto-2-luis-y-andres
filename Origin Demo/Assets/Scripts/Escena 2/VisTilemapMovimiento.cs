using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using CodeMonkey.Utils; //De aca se saca una funcion que me da la posicion del click del mouse
using CodeMonkey;

public class VisTilemapMovimiento : MonoBehaviour
{

    [SerializeField] private VisualTilemap visualTilemap;
    public Tilemap tilemap;

    private void Start()
    {
        tilemap = new Tilemap(34, 14, 10f, Vector3.zero);

        tilemap.DefVisualTM(visualTilemap);
    }

}
