using UnityEngine;

public class MetaFinal : MonoBehaviour
{
    public GameObject pantallaFinal;

    private void Start()
    {
        pantallaFinal.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pantallaFinal.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
        }
    }
}