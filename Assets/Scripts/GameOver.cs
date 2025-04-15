using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour 
{
    public TMP_Text textPuntos;

    public TMP_Text Corazones;

    public GameObject gameOverPanel;

    public static GameOver instancia;



    private int corazonesRecolectados = 0;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarCorazon()
    {
        corazonesRecolectados++;
    }
    public void MostrarGameOver()
    {
        gameOverPanel.SetActive(true);
        textPuntos.text = "Corazones: " + corazonesRecolectados.ToString() + "/3";
    }

    public void MostrarPuntuacion()
    {
        Corazones.gameObject.SetActive(true);
        Corazones.text = ""+corazonesRecolectados.ToString()+"";
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrMenuPrincipal()
    {
        SceneManager.LoadScene("UI");
    }

}
