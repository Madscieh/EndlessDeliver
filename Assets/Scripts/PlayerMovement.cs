using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Rigidbody: componente do objeto onde a fisica acontece
    public Rigidbody rb;
    // 2) Controle Horizontal:
    private float horizontalInput;
    // 3) Velocidades:
    public float speedForward = 8;
    public float speedHorizontal = 8;

    // Funcao que implementa o movimento na cena
    private void FixedUpdate()
    {
        // Componentes vetoriais do movimento:

        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.forward * speedForward * Time.fixedDeltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        Vector3 horizontalMove = transform.right * horizontalInput * speedHorizontal * Time.fixedDeltaTime;
        // 3) Movimento Resultante:
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Funcao para controle do movimento horizontal
    private void Update()
    {
        // Input Horizontal Padrão da Unity: a = esquerda, d = direita
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
