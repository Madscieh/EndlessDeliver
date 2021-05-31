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
    // 4) Distancia: para controlar indiretamente a duracao
    public float distance = 50f;

    // Funcao que implementa o movimento na cena
    private void FixedUpdate()
    {
        // Input Horizontal Padrão da Unity: a = esquerda, d = direita
        horizontalInput = Input.GetAxis("Horizontal");

        // Componentes vetoriais do movimento:

        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.forward * speedForward * Time.fixedDeltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        Vector3 horizontalMove = transform.right * horizontalInput * speedHorizontal * Time.fixedDeltaTime;
        // Condicao de parada: rb.transform.position.z >= distance
        if (rb.transform.position.z < distance)
        {
            // 3) Movimento Resultante:
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        }
        else
        {
            // 3) Movimento Resultante (só na horizontal):
            rb.MovePosition(rb.position + horizontalMove);
        }
    }
}
