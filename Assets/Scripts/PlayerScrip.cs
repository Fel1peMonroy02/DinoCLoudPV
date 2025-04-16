using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrip : MonoBehaviour
{
    // Variables públicas configurables desde el inspector
    public float velocidad = 5f;                 // Velocidad de movimiento horizontal
    public float FuerzaSalto = 7f;               // Fuerza del salto
    public float LongitudRaycast = 0.1f;         // Longitud del raycast hacia abajo para detectar el suelo
    public LayerMask capaSuelo;                  // Capa que representa el suelo
    private bool enSuelo;                        // ¿Está el jugador en el suelo?
    private Rigidbody2D rb;                      // Componente de física 2D del jugador
    public Animator animator;                    // Referencia al componente Animator

    // Audio
    public AudioSource pasosAudio;               // Audio que se reproduce al caminar
    public AudioClip premioSound;                // Clip para cuando recoge un premio (no se usa aquí)
    public AudioClip saltoSound;                 // Clip para el salto
    public AudioClip muerteSound;                // Clip para la muerte

    private AudioSource audioSource;             // Componente de AudioSource del jugador

    void Start()
    {
        // Obtener referencias a los componentes necesarios al iniciar
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Obtener el valor del eje horizontal (-1 a 1) y escalarlo por la velocidad y el tiempo
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        // Guardar la posición actual del jugador
        Vector2 posicion = transform.position;

        // Cambiar animación entre idle y correr según el movimiento horizontal
        animator.SetFloat("Movimiento", velocidadX * velocidad);

        // Cambiar dirección visual del personaje (flip horizontal) según hacia dónde se mueve
        if (velocidadX < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        if (velocidadX > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

        // Sonido de pasos: solo si se está moviendo horizontalmente y está en el suelo
        if (Input.GetAxis("Horizontal") != 0 && enSuelo)
        {
            if (!pasosAudio.isPlaying)
                pasosAudio.Play();
        }
        else
        {
            pasosAudio.Stop();
        }

        // Actualizar posición del jugador (movimiento horizontal)
        transform.position = new Vector2(velocidadX + posicion.x, posicion.y);

        // Lanzar un raycast hacia abajo para detectar si está en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        // Si está en el suelo y se presiona espacio, el jugador salta
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
            audioSource.PlayOneShot(saltoSound); // Reproducir sonido de salto
        }

        // Enviar al Animator si el jugador está en el suelo
        animator.SetBool("Ensuelo", enSuelo);
    }

    // Dibuja en el editor una línea para visualizar el raycast hacia el suelo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LongitudRaycast);
    }

    // Detectar colisión con un objeto tipo trigger
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el jugador cae en una zona etiquetada como "CaidaMuerte"
        if (collision.CompareTag("CaidaMuerte"))
        {
            // Detener por completo el movimiento y congelarlo físicamente
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;

            // Mostrar mensaje, animación y sonido de muerte
            Debug.Log("¡Moriste!");
            animator.SetTrigger("CaidaMuerte");
            audioSource.PlayOneShot(muerteSound);

            // Mostrar pantalla de Game Over (se asume que existe un objeto con este script)
            FindAnyObjectByType<GameOver>().MostrarGameOver();

            // Desactivar este script para que deje de responder en Update
            this.enabled = false;
        }
    }
}
