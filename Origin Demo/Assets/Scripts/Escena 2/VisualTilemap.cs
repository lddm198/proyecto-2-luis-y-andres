using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTilemap : MonoBehaviour {

    private Cuadricula<Tilemap.ObjetoTilemap> cuadricula;
    private Mesh mesh;
    private bool actualizarMesh;

    private void Awake() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void DefCuad(Cuadricula<Tilemap.ObjetoTilemap> cuadricula) {
        this.cuadricula = cuadricula;
        ActualizarVisualTM();

        cuadricula.CuadCambioDeObjeto += CuadCambioElValor;
    }

    private void CuadCambioElValor(object sender, Cuadricula<Tilemap.ObjetoTilemap>.CuadCambioDeObjetoEventArgs e) {
        actualizarMesh = true;
    }

    private void LateUpdate() {
        if (actualizarMesh) {
            actualizarMesh = false;
            ActualizarVisualTM();
        }
    }

    private void ActualizarVisualTM() {
        MeshUtils.CreateEmptyMeshArrays(cuadricula.ObtAncho() * cuadricula.ObtAlto(), out Vector3[] vertices, out Vector2[] uv, out int[] triangulos);

        for (int x = 0; x < cuadricula.ObtAncho(); x++) {
            for (int y = 0; y < cuadricula.ObtAlto(); y++) {
                int indice = x * cuadricula.ObtAlto() + y;
                Vector3 tamQuad = new Vector3(1, 1) * cuadricula.ObtTamCuadro();

                Tilemap.ObjetoTilemap objetoCuad = cuadricula.ObtObjeto(x, y);
                Tilemap.ObjetoTilemap.SpriteTilemap spriteTilemap = objetoCuad.ObtSpriteTilemap();
                Vector2 ValorCuadUV;
                if (spriteTilemap == Tilemap.ObjetoTilemap.SpriteTilemap.Nada) { //Si no hay textura en ese cuadro no se muestra
                    ValorCuadUV = Vector2.zero;
                    tamQuad = Vector3.zero;
                }
                else {  //Si no, se muetra verde (el suelo)
                    ValorCuadUV = Vector2.one;
                }
                MeshUtils.AddToMeshArrays(vertices, uv, triangulos, indice, cuadricula.GetPosicionMundo(x, y) + tamQuad * .5f, 0f, tamQuad, ValorCuadUV, ValorCuadUV);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangulos;
    }

}
