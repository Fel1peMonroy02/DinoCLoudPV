using TMPro;
using UnityEngine;

public class ContadorPremios : MonoBehaviour
{
    public static ContadorPremios instancia;

    public TMP_Text textoContador;
    private int corazones = 0;
    private int maxCorazones = 3;

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

    private void Start()
    {
        ActualizarTexto();
    }

    public void SumarCorazon()
    {
        corazones++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textoContador.text = ""+ corazones.ToString() + "/" + maxCorazones;
    }

    public int GetCorazonesRecolectados()
    {
        return corazones;
    }
}
