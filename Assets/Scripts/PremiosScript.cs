using UnityEngine;

public class Premios : MonoBehaviour
{
    // Clip de audio que se reproducirá al recolectar el premio
    public AudioClip premioSound;

    // Componente de audio que reproducirá el clip
    private AudioSource audioSource;

    private void Start()
    {
        // Buscar el componente AudioSource en el mismo GameObject al iniciar
        audioSource = GetComponent<AudioSource>();

        // Si no se encuentra el AudioSource, se lanza una advertencia en consola
        if (audioSource == null)
        {
            Debug.LogWarning("No hay AudioSource en el objeto del premio.");
        }
    }

    // Se ejecuta automáticamente cuando otro objeto con Collider2D y marcado como "Is Trigger" entra en contacto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisionó tiene el tag "Player"
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Premio recolectado!");

            // Si hay audio y clip asignado, reproduce el sonido del premio
            if (audioSource != null && premioSound != null)
            {
                audioSource.PlayOneShot(premioSound);
            }
            else
            {
                Debug.LogWarning("Falta AudioSource o AudioClip para reproducir el sonido del premio.");
            }

            // Sumar un punto o corazón al sistema de GameOver (si está activo en la escena)
            if (GameOver.instancia != null)
                GameOver.instancia.SumarCorazon();

            // También suma en el sistema de contador de premios (si está presente)
            if (ContadorPremios.instancia != null)
                ContadorPremios.instancia.SumarCorazon();

            // Elimina el objeto del premio después de un breve tiempo (0.2 segundos)
            Destroy(gameObject, 0.2f);
        }
    }
}
