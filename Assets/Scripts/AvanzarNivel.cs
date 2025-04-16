using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class AvanzarNivel : MonoBehaviour
{
    // Nombre de la escena a cargar cuando se cumplan los requisitos
    public string SiguienteNivel;

    // Método que se ejecuta automáticamente al entrar en un trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica que el objeto que entra sea el jugador
        if (collision.CompareTag("Player"))
        {
            // Verifica si el jugador ha recolectado 3 corazones
            if (ContadorPremios.instancia.GetCorazonesRecolectados() == 3)
            {
                // Si se cumplió la condición, carga la siguiente escena
                SceneManager.LoadScene(SiguienteNivel);
            }
            else
            {
                // Si no ha recolectado los 3 corazones, muestra un mensaje
                Debug.Log("¡Aún te faltan corazones para avanzar!");
            }
        }
    }
}