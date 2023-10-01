using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class accionesBotones : MonoBehaviour
{
    // Start is called before the first frame update
    public void iniciarJuego()
    {
        Time.timeScale = 1; // Reanuda el juego a velocidad normal.
        SceneManager.LoadScene(1);
    }
    public void instrucciones()
    {
        SceneManager.LoadScene(2);
    }
    public void cerrarJuego()
    {
        Application.Quit();
    }
    public void regresarInicio()
    {
        SceneManager.LoadScene(0);
    }
}
