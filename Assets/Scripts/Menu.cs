using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject PanelInstrucciones;

    void Start()
    {
        PanelInstrucciones.SetActive(false);
    }
    public void Iniciar()
    {
        SceneManager.LoadScene(1);

    }

    public void Instrucciones()
    {
        PanelInstrucciones.SetActive(true);
    }

 
    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

}
