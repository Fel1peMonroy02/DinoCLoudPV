using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScrip : MonoBehaviour
{
    //variables
    public float velocidad = 5f;
    public float FuerzaSalto = 7f;
    public float LongitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    private bool enSuelo;
    private Rigidbody2D rb;
    public Animator animator;

    public AudioSource pasosAudio;
    public AudioClip premioSound;
    public AudioClip saltoSound;
    public AudioClip muerteSound;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //Horizontal
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        //Vector 2
        Vector2 posicion = transform.position;

        //Funcion del animator par pasar de idle a run
        animator.SetFloat("Movimiento", velocidadX * velocidad);

        //Para cambiar orientacion al correr
        if (velocidadX < 0){
            transform.localScale = new Vector2(-1, 1);
        }
        if(velocidadX > 0){
            transform.localScale = new Vector2(1, 1);
        }

        // Sonido de pasos
        if (Input.GetAxis("Horizontal") != 0 && enSuelo)
        {
            if (!pasosAudio.isPlaying)
                pasosAudio.Play();
        }
        else
        {
            pasosAudio.Stop();
        }

        //Movimiento
        transform.position = new Vector2(velocidadX + posicion.x, posicion.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        
        //Sentencia si el pj esta en el suelo, si apreta la tecla espacio el pj salta
        if (enSuelo && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
            audioSource.PlayOneShot(saltoSound);
        }

        animator.SetBool("Ensuelo", enSuelo);



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.down * LongitudRaycast);
    }



    // Detectar colisión con el objeto "vacío"
    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CaidaMuerte"))
        {

            // Detener completamente el movimiento
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static; // Lo congela físicamente
            

            Debug.Log("¡Moriste!");
            animator.SetTrigger("CaidaMuerte");
            audioSource.PlayOneShot(muerteSound);

            FindAnyObjectByType<GameOver>().MostrarGameOver();
            this.enabled = false;//Para desactivar movimiento desde update.

        }
    }
}
