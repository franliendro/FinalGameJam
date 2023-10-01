using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escalarTexto : MonoBehaviour
{
    public float distanciaVertical = 2.0f; // Distancia vertical que el objeto debe recorrer
    public float velocidadMovimiento = 2.0f; // Velocidad de movimiento del objeto
    public float escalaMaxima = 1.5f; // Escala máxima del objeto
    public float duracionEscalado = 1.0f; // Duración del escalado en segundos

    private Vector3 posicionInicial;
    private Vector3 escalaInicial;

    void Start()
    {
        posicionInicial = transform.position;
        escalaInicial = transform.localScale;
        StartCoroutine(MoverYEscalar());
    }

    IEnumerator MoverYEscalar()
    {
        while (true)
        {
            // Escala hacia arriba
            float escalaActual = transform.localScale.y;
            float t = 0;
            while (t < duracionEscalado)
            {
                t += Time.deltaTime;
                float factorEscala = Mathf.Lerp(escalaActual, escalaMaxima, t / duracionEscalado);
                transform.localScale = new Vector3(factorEscala, factorEscala, 1);
                yield return null;
            }

            // Mueve hacia arriba
            while (transform.position.y < posicionInicial.y + distanciaVertical)
            {
                transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }

            // Escala hacia abajo
            t = 0;
            while (t < duracionEscalado)
            {
                t += Time.deltaTime;
                float factorEscala = Mathf.Lerp(transform.localScale.y, escalaInicial.y, t / duracionEscalado);
                transform.localScale = new Vector3(factorEscala, factorEscala, 1);
                yield return null;
            }

            // Mueve hacia abajo
            while (transform.position.y > posicionInicial.y)
            {
                transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
                yield return null;
            }
        }
    }
}
