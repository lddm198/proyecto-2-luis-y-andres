using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap {

    private Cuadricula<ObjetoTilemap> cuadricula;
    
    public Tilemap(int ancho, int alto, float tamCuadro, Vector3 posicionOrigen) {
        cuadricula = new Cuadricula<ObjetoTilemap>(ancho, alto, tamCuadro, posicionOrigen, (Cuadricula<ObjetoTilemap> c, int x, int y) => new ObjetoTilemap(c, x, y));
    }

    public void DefSpriteTM(Vector3 posicion, ObjetoTilemap.SpriteTilemap spriteTilemap) {
        ObjetoTilemap objetoTilemap = cuadricula.ObtObjeto(posicion);
        if (objetoTilemap != null) {
            objetoTilemap.DefSpriteTM(spriteTilemap);
        }
    }

    public Cuadricula<ObjetoTilemap> ObtCuadricula()
    {
        return cuadricula;
    }

    public void DefVisualTM(VisualTilemap visualTilemap) {
        visualTilemap.DefCuad(cuadricula);
    }

    public class ObjetoTilemap {  //Se crea la clase de los objetos tipo Tilemap para usarlos en la cuadricula

        public enum SpriteTilemap {  //Los diferentes tipos de suelo en el tilemap
            Nada,
            Mover
        }

        private Cuadricula<ObjetoTilemap> cuadricula;
        private int x;
        private int y;
        private SpriteTilemap spriteTilemap;

        public ObjetoTilemap(Cuadricula<ObjetoTilemap> cuadricula, int x, int y) {
            this.cuadricula = cuadricula;
            this.x = x;
            this.y = y;
        }
        
        public void DefSpriteTM(SpriteTilemap spriteTilemap) {  //Funcion para definir el sprite en un cuadro del tilemap
            this.spriteTilemap = spriteTilemap;
            cuadricula.ActivarCambioCuadricula(x, y);
        }

        public SpriteTilemap ObtSpriteTilemap()
        {
            return spriteTilemap;
        }

        public override string ToString()
        {
            return spriteTilemap.ToString();
        }

    }


}
