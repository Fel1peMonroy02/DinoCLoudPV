using UnityEngine;
using TMPro; // Solo si usas TextMeshPro

public class PausaJuego : MonoBehaviour
{
    public GameObject panelPausa;
    public TMP_Text textoPausa; // Asigna el texto en el inspector
    private bool juegoPausado = false;

    void Start()
    {
        panelPausa.SetActive(false);
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        panelPausa.SetActive(true);
        textoPausa.text = "Juego Pausado \nPresione ESC para volver al juego"; 
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }
}