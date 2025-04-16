using UnityEngine;

public class MetaFinal : MonoBehaviour
{
    // Referencia al panel o pantalla final que se muestra al completar el juego
    public GameObject pantallaFinal;

    private void Start()
    {
        // Al comenzar el nivel, se asegura de que la pantalla final esté oculta
        pantallaFinal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el objeto que entró en el trigger tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Muestra la pantalla final
            pantallaFinal.SetActive(true);

            // Pausa el juego (detiene el tiempo)
            Time.timeScale = 0f;
        }
    }
}
