using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    /*[SerializeField] string escenaInicial = null;
    [SerializeField] string escenaInstrucciones = null;
    [SerializeField] string escenaCreditos = null;*/

    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    /*public void Instrucciones()
    {
        print("Botón Instrucciones");
        SceneManager.LoadScene(escenaInstrucciones);
    }

    public void Creditos()
    {
        print("Botón Crédito");
        SceneManager.LoadScene(escenaCreditos);
    }*/

    public void Salir()
    {
        Application.Quit();
    }
}
