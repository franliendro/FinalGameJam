using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class determinarVacio : MonoBehaviour
{
    [SerializeField] GameObject panelNivel;
    public Tilemap tilemap;
    private bool b = true;
    private void Update()
    {
        // Llama a la función para verificar si el Tilemap está vacío
        bool estaVacio = VerificarTilemapVacio(tilemap);

        if (estaVacio&&b)
        {
            Debug.Log("El Tilemap está vacío.");
            StartCoroutine(mostrarSiguienteNivel());
            b = false;
        }
    }

    private bool VerificarTilemapVacio(Tilemap tilemap)
    {
        // Obtén los bounds del Tilemap
        BoundsInt bounds = tilemap.cellBounds;

        // Recorre todas las celdas en el Tilemap
        foreach (Vector3Int position in bounds.allPositionsWithin)
        {
            // Obtén el tile en la posición actual
            TileBase tile = tilemap.GetTile(position);

            // Si se encuentra un tile en la posición actual, el Tilemap no está vacío
            if (tile != null)
            {
                return false;
            }
        }

        // Si no se encontraron tiles en ninguna posición, el Tilemap está vacío
        return true;
    }
    
    IEnumerator mostrarSiguienteNivel()
    {
        yield return new WaitForSeconds(1);
        panelNivel.SetActive(true);
        Time.timeScale = 0;
        
    }
}

