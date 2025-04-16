using TMPro; // Para utilizar textos con TextMeshPro
using UnityEngine;

public class ContadorPremios : MonoBehaviour
{
    // Instancia estática para que otros scripts accedan fácilmente
    public static ContadorPremios instancia;

    public TMP_Text textoContador; // Texto que se muestra en pantalla con la cantidad de corazones

    private int corazones = 0;         // Contador actual de corazones recolectados
    private int maxCorazones = 3;      // Cantidad total de corazones necesarios para completar el nivel

    private void Awake()
    {
        // Implementación del patrón Singleton para asegurar una única instancia
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject); // Si ya existe, destruye esta nueva para evitar duplicados
        }
    }

    private void Start()
    {
        // Al iniciar el juego, actualiza el texto para mostrar 0/3
        ActualizarTexto();
    }

    // Función pública que aumenta en 1 el contador de corazones
    public void SumarCorazon()
    {
        corazones++;
        ActualizarTexto();
    }

    // Actualiza el texto en pantalla con el formato: "X/3"
    private void ActualizarTexto()
    {
        textoContador.text = "" + corazones.ToString() + "/" + maxCorazones;
    }

    // Devuelve el número actual de corazones recolectados
    public int GetCorazonesRecolectados()
    {
        return corazones;
    }
}
