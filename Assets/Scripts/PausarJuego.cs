using UnityEngine;
using TMPro; // Necesario para usar TMP_Text (TextMeshPro)

public class PausaJuego : MonoBehaviour
{
    public GameObject panelPausa;     // Panel UI que se muestra cuando el juego est� en pausa
    public TMP_Text textoPausa;       // Texto que muestra el mensaje de pausa
    private bool juegoPausado = false; // Bandera para saber si el juego est� pausado o no

    void Start()
    {
        // Al iniciar el juego, el panel de pausa est� oculto
        panelPausa.SetActive(false);
    }

    void Update()
    {
        // Si se presiona la tecla Escape, alterna entre pausar y reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();   // Si ya est� pausado, lo reanuda
            else
                PausarJuego();    // Si no est� pausado, lo pausa
        }
    }

    // M�todo para pausar el juego
    public void PausarJuego()
    {
        panelPausa.SetActive(true);   // Muestra el panel de pausa
        textoPausa.text = "Juego Pausado \nPresione ESC para volver al juego"; // Mensaje personalizado
        Time.timeScale = 0f;          // Detiene el tiempo del juego (pausa real)
        juegoPausado = true;          // Marca el juego como pausado
    }

    // M�todo para reanudar el juego
    public void ReanudarJuego()
    {
        panelPausa.SetActive(false);  // Oculta el panel de pausa
        Time.timeScale = 1f;          // Restaura el tiempo normal del juego
        juegoPausado = false;         // Marca el juego como reanudado
    }
}
