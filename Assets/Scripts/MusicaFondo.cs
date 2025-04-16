using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    // Instancia est�tica para mantener un �nico objeto persistente en todo el juego
    public static MusicaFondo instancia;

    private AudioSource audioSource;

    // Clips de m�sica para diferentes escenas
    public AudioClip musicaMenu;
    public AudioClip musicaNivel1;
    public AudioClip musicaNivel2;

    void Awake()
    {
        // Si no existe una instancia, este objeto se convierte en la instancia global
        if (instancia == null)
        {
            instancia = this;

            // Evita que este objeto se destruya al cambiar de escena
            DontDestroyOnLoad(gameObject);

            // Obtiene el componente AudioSource del objeto
            audioSource = GetComponent<AudioSource>();

            // Se suscribe al evento que se dispara al cargar una escena
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            // Si ya hay una instancia activa, destruye la nueva para evitar duplicados
            Destroy(gameObject);
        }
    }

    // Se ejecuta autom�ticamente cada vez que se carga una nueva escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama a la funci�n para cambiar la m�sica seg�n el nombre de la escena
        CambiarMusicaPorEscena(scene.name);
    }

    // Cambia la m�sica dependiendo de la escena actual
    void CambiarMusicaPorEscena(string nombreEscena)
    {
        AudioClip nuevoClip = null;

        // Selecciona el clip adecuado seg�n el nombre de la escena
        switch (nombreEscena)
        {
            case "UI": // Men� principal
                nuevoClip = musicaMenu;
                break;
            case "Nivel1": // Primer nivel
                nuevoClip = musicaNivel1;
                break;
            case "Game2": // Segundo nivel
                nuevoClip = musicaNivel2;
                break;
        }

        // Si hay un nuevo clip y es diferente al actual, se realiza el cambio
        if (nuevoClip != null && audioSource.clip != nuevoClip)
        {
            audioSource.Stop();        // Detiene el clip actual
            audioSource.clip = nuevoClip; // Asigna el nuevo clip
            audioSource.Play();        // Lo reproduce
        }
    }
}
