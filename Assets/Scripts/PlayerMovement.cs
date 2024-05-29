using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Controles")]
    [SerializeField] KeyCode movientoDerecha;
    [SerializeField] KeyCode movientoIzquierda;
    [SerializeField] KeyCode movientoArriba;
    [SerializeField] KeyCode movientoAbajo;
    [SerializeField] KeyCode sprint;

    [Header("Cooldowns")]
    [SerializeField] float cooldownMovement;
    float coolDown;
    [SerializeField] float cooldownSprint;

    [Header("Movimiento")]
    Vector3 movimientoLateral = new Vector2 (1 , 0);
    Vector3 sprintMovimientoLateral = new Vector2 (3 , 0);
    Vector3 movimientoArribaAbajo = new Vector2 (0 , 1);
    Vector3 sprintMovimientoArribaAbajo = new Vector2(0 , 3);

    [Header("Rotacion")]
    Vector3 rotacionPlayerIz = new Vector3(0 , 0 , 90);
    Vector3 rotacionPlayerDr = new Vector3(0 , 0 , -90);
    Vector3 rotacionPlayerAr = new Vector3(0 , 0 , 0);
    Vector3 rotacionPlayerAb = new Vector3(0 , 0 , 180);

    [Header("Spawn")]
    [SerializeField] Transform spawnBullets;

    [Header("Disparo")]
    [SerializeField] GameObject bala;
    [SerializeField] KeyCode disparo;
    float velocidadBala = 20f;

    bool GameOver = false;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 rotacionGanador = new Vector3(0, 0, 10f);
    [SerializeField] GameObject JugadorPerdedor;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameOver == false)
        {
            coolDown += Time.deltaTime;

            if (Input.GetKey(movientoArriba))
            {
                if (coolDown > cooldownMovement)
                {
                    transform.position += movimientoArribaAbajo;
                    transform.rotation = Quaternion.Euler(rotacionPlayerAr);
                    coolDown = 0;
                    if (Input.GetKey(sprint))
                    {
                        if (coolDown > cooldownSprint)
                        {
                            transform.position += sprintMovimientoArribaAbajo;
                        }
                    }
                }
            }

            if (Input.GetKey(movientoAbajo))
            {
                if (coolDown > cooldownMovement)
                {
                    transform.position -= movimientoArribaAbajo;
                    transform.rotation = Quaternion.Euler(rotacionPlayerAb);
                    coolDown = 0;
                    if (Input.GetKey(sprint))
                    {
                        if (coolDown > cooldownSprint)
                        {
                            transform.position -= sprintMovimientoArribaAbajo;
                        }
                    }
                }
            }

            if (Input.GetKey(movientoDerecha))
            {
                if (coolDown > cooldownMovement)
                {
                    transform.position += movimientoLateral;
                    transform.rotation = Quaternion.Euler(rotacionPlayerDr);
                    coolDown = 0;
                    if (Input.GetKey(sprint))
                    {
                        if (coolDown > cooldownSprint)
                        {
                            transform.position += sprintMovimientoLateral;
                        }
                    }
                }

            }

            if (Input.GetKey(movientoIzquierda))
            {
                if (coolDown > cooldownMovement)
                {
                    transform.position -= movimientoLateral;
                    transform.rotation = Quaternion.Euler(rotacionPlayerIz);
                    coolDown = 0;
                    if (Input.GetKey(sprint))
                    {
                        if(coolDown > cooldownSprint)
                        {
                            transform.position -= sprintMovimientoLateral;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(disparo))
            {
                GameObject balaInstanciada = Instantiate(
                    bala,
                    spawnBullets.position,
                    Quaternion.identity);

                balaInstanciada.GetComponent<Rigidbody2D>().velocity = transform.up * velocidadBala;
                Destroy(balaInstanciada, 0.5f);
            
            
            }
        
        }
        if(GameOver == true)
        {
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bala"))
        {
            GameOver = true;
            Destroy(JugadorPerdedor);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
    }
} 
