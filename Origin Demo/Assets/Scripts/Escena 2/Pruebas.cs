using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using CodeMonkey.Utils; //De aca se saca una funcion que me da la posicion del click del mouse
using CodeMonkey;

public class Pruebas : MonoBehaviour
{

    [SerializeField] private VisualTilemap visualTilemap;
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = new Tilemap(22, 12, 10f, Vector3.zero);

        tilemap.DefVisualTM(visualTilemap);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Vector3 posicionMouse = UtilsClass.GetMouseWorldPosition();
            tilemap.DefSpriteTM(posicionMouse, Tilemap.ObjetoTilemap.SpriteTilemap.Suelo);
        }

    }

}
