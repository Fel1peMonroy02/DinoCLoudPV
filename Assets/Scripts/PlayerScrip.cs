using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    //variables
    public float velocidad = 5f;
    public float FuerzaSalto = 10f;
    public float LongitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    private bool enSuelo;
    private Rigidbody2D rb;
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        //Movimiento
        transform.position = new Vector2(velocidadX + posicion.x, posicion.y);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        
        //Sentencia si el pj esta en el suelo, si apreta la tecla espacio el pj salta
        if (enSuelo && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
        }

        animator.SetBool("Ensuelo", enSuelo);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.position + Vector3.down * LongitudRaycast);
    }



    // Detectar colisión con el objeto "vacío"
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CaidaMuerte"))
        {
            //vidas--;
            //puedeMoverse = false;
            Debug.Log("¡Caíste al vacío!" );

            // (Opcional) podrías desactivar al personaje, reiniciar el nivel, mostrar Game Over, etc.
            gameObject.SetActive(false);
        }

    }
}
