using UnityEngine;
using UnityEngine.SceneManagement;

public class AvanzarNivel : MonoBehaviour
{
    public string SiguienteNivel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ContadorPremios.instancia.GetCorazonesRecolectados() == 3)
            {
                SceneManager.LoadScene(SiguienteNivel);
            }
            else
            {
                Debug.Log("¡Aún te faltan corazones para avanzar!");
            }
        }
    }
}
