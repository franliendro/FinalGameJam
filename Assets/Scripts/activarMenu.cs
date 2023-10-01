using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarMenu : MonoBehaviour
{
    public GameObject panelPausa;
    private bool juegoPausado = false;

    void Start()
    {
        panelPausa.SetActive(false); // Asegúrate de que el panel de pausa esté desactivado al principio.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Verifica si se presiona la tecla "Escape".
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0; // Pausa el juego.
        panelPausa.SetActive(true); // Activa el panel de pausa.
    }

    public void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1; // Reanuda el juego a velocidad normal.
        panelPausa.SetActive(false); // Desactiva el panel de pausa.
    }
}
