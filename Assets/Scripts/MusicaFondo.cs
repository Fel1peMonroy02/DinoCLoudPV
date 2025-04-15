using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaFondo : MonoBehaviour
{
    public static MusicaFondo instancia;
    private AudioSource audioSource;

    // Clips de música para distintas escenas
    public AudioClip musicaMenu;
    public AudioClip musicaNivel1;
    public AudioClip musicaNivel2;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CambiarMusicaPorEscena(scene.name);
    }

    void CambiarMusicaPorEscena(string nombreEscena)
    {
        AudioClip nuevoClip = null;

        switch (nombreEscena)
        {
            case "UI":
                nuevoClip = musicaMenu;
                break;
            case "Nivel1":
                nuevoClip = musicaNivel1;
                break;
            case "Game2":
                nuevoClip = musicaNivel2;
                break;
        }

        if (nuevoClip != null && audioSource.clip != nuevoClip)
        {
            audioSource.Stop();
            audioSource.clip = nuevoClip;
            audioSource.Play();
        }
    }
}