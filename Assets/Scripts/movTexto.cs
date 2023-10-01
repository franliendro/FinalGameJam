using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movTexto : MonoBehaviour
{
    public float distanciaVertical = 4.0f; // Distancia vertical que el objeto debe recorrer
    public float velocidadMovimiento = 4.0f; // Velocidad de movimiento del objeto

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(MoverCiclicamente());
    }

    IEnumerator MoverCiclicamente()
    {
        while (true)
        {
            // Mueve hacia arriba
            while (transform.position.y < posicionInicial.y + distanciaVertical)
            {
                transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Espera un momento en la posición superior
            yield return new WaitForSeconds(1.0f);

            // Mueve hacia abajo
            while (transform.position.y > posicionInicial.y)
            {
                transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Espera un momento en la posición inferior
            yield return new WaitForSeconds(1.0f);
        }
    }
}