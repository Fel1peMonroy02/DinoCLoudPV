using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Necesario para usar textos con TextMeshPro
using UnityEngine.SceneManagement; // Para cambiar o recargar escenas

public class GameOver : MonoBehaviour
{
    public TMP_Text textPuntos;       // Texto que muestra los corazones recolectados al morir
    public TMP_Text Corazones;        // Texto que muestra los corazones en pantalla durante el juego
    public GameObject gameOverPanel;  // Panel UI que aparece cuando el jugador muere

    public static GameOver instancia; // Instancia global para acceder desde otros scripts

    private int corazonesRecolectados = 0; // Contador de corazones recogidos

    private void Start()
    {
        // Oculta el panel de Game Over al comenzar el juego
        gameOverPanel.SetActive(false);
    }

    private void Awake()
    {
        // Configura el patrón Singleton para que solo exista una instancia
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye la nueva
        }
    }

    // Función pública para aumentar el contador de corazones
    public void SumarCorazon()
    {
        corazonesRecolectados++;
    }

    // Muestra el panel de Game Over y actualiza el texto de puntos
    public void MostrarGameOver()
    {
        gameOverPanel.SetActive(true);
        textPuntos.text = "Corazones: " + corazonesRecolectados.ToString() + "/3";
    }

    // Muestra en pantalla la cantidad de corazones recolectados durante el juego
    public void MostrarPuntuacion()
    {
        Corazones.gameObject.SetActive(true);
        Corazones.text = "" + corazonesRecolectados.ToString() + "";
    }

    // Reinicia el nivel actual
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; // Por si el juego estaba pausado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Vuelve al menú principal (escena llamada "UI")
    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("UI");
    }
}
