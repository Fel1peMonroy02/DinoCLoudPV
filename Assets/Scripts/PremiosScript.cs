using UnityEngine;

public class Premios : MonoBehaviour
{
    public AudioClip premioSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Busca el AudioSource en el mismo objeto o lanza advertencia
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("No hay AudioSource en el objeto del premio.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("¡Premio recolectado!");

            // Reproduce sonido si está todo asignado
            if (audioSource != null && premioSound != null)
            {
                audioSource.PlayOneShot(premioSound);
            }
            else
            {
                Debug.LogWarning("Falta AudioSource o AudioClip para reproducir el sonido del premio.");
            }

            // Sumar puntaje
            if (GameOver.instancia != null)
                GameOver.instancia.SumarCorazon();

            if (ContadorPremios.instancia != null)
                ContadorPremios.instancia.SumarCorazon();

            // Destruye el objeto después de que el sonido se reproduce
            Destroy(gameObject, 0.2f);
        }
    }
}