using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridEraser : MonoBehaviour
{
    public Tilemap tilemap;

    private void Update()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
        TileBase tile = tilemap.GetTile(cellPosition);

        // Verifica si la casilla tiene un tile antes de borrarlo
        if (tile != null)
        {
            tilemap.SetTile(cellPosition, null);
        }

        // Agrega aquí tu lógica de movimiento del jugador
    }
}
