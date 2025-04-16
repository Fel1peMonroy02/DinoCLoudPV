using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class Menu : MonoBehaviour
{
    // Referencia al panel de instrucciones en la interfaz
    public GameObject PanelInstrucciones;

    void Start()
    {
        // Al iniciar el juego, se asegura de que el panel de instrucciones esté oculto
        PanelInstrucciones.SetActive(false);
    }

    // Método que se llama al presionar el botón "Iniciar"
    public void Iniciar()
    {
        // Carga la escena con índice 1 (se asume que es el primer nivel del juego)
        SceneManager.LoadScene(1);
    }

    // Método que se llama al presionar el botón "Instrucciones"
    public void Instrucciones()
    {
        // Muestra el panel de instrucciones en pantalla
        PanelInstrucciones.SetActive(true);
    }

    // Método que se llama al presionar el botón "Salir"
    public void Salir()
    {
        // Muestra un mensaje en la consola indicando que se está saliendo del juego
        Debug.Log("Saliendo del juego...");
        // Cierra la aplicación (no tiene efecto en el editor de Unity, pero sí en un build)
        Application.Quit();
    }
}
