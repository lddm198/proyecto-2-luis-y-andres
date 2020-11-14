using Boo.Lang;
using CodeMonkey.Utils;
using System.Linq;
using UnityEngine;

public class TilemapMovimiento : MonoBehaviour
{
    public int Rango;
    [SerializeField] private VisualTilemap visualTilemap;
    private Tilemap tilemap;
    private Pathfinding pathfinding;
    private List<Vector3> bloqueados;

    private void Start()
    {
        ValidarPosicionParaMover();
    }

    public void ValidarPosicionParaMover()
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

        pathfinding = new Pathfinding(34, 14);
        tilemap = new Tilemap(34, 14, 10f, Vector3.zero);

        while (bloqueados.Count > 0)
        {
            if (bloqueados[0] != Vector3.zero)
            {
                GetComponent<MovimientoPathfinding>().Block(bloqueados[0], pathfinding);
                bloqueados.RemoveAt(0);
            }
        }

        tilemap.DefVisualTM(visualTilemap);
        tilemap.ObtCuadricula().GetXY(transform.position, out int xPos, out int yPos);

        //Se definen todas las posiciones como fuera de rango
        for (int x1 = 0; x1 <= 34; x1++)
        {
            for (int y1 = 0; y1 <= 14; y1++)
            {
                //visualTilemap.cuadricula2.ObtObjeto(x1, y1).DefPosicionEnRango(false);
            }
        }

        //Se crea un ciclo para revisar si la posicion se puede caminar
        for (int x = xPos - Rango; x <= xPos + Rango; x++)
        {
            for (int y = yPos - Rango; y <= yPos + Rango; y++)
            {
                if (x >= 0 && y >= 0 && x < 34 && y < 14)
                {
                    //Si la posisicon esta dentro de la cuadricula
                    if (pathfinding.ObtNodo(x, y).seCamina)
                    {
                        //Se camina
                        if (pathfinding.EnconCamino(xPos, yPos, x, y) != null)
                        {
                            //Tiene camino valido
                            if (pathfinding.EnconCamino(xPos, yPos, x, y).Count <= Rango)
                            {
                                //Esta dentro del rango
                                tilemap.DefSpriteTM(tilemap.ObtCuadricula().GetPosicionMundo(x, y), Tilemap.ObjetoTilemap.SpriteTilemap.Mover);
                                visualTilemap.cuadricula2.ObtObjeto(x, y).DefPosicionEnRango(true);
                            }
                            else
                            {
                                //No esta dentro del rango
                            }
                        }
                        else
                        {
                            //No tiene camino valido
                        }
                    }
                    else
                    {
                        //No se camina
                    }
                }
            }
        }
    }

    public class ObjetoCuadricula
    {
        private Cuadricula<ObjetoCuadricula> cuadricula;
        private int x;
        private int y;
        private bool enRango = false;

        public ObjetoCuadricula(Cuadricula<ObjetoCuadricula> cuadricula, int x, int y) {
            this.cuadricula = cuadricula;
            this.x = x;
            this.y = y;
        }

        public void DefPosicionEnRango(bool def) {
            enRango = def;
        }

        public bool ObtPosicionEnRango() {
            return enRango;
        }
    }

}
