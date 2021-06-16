using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Rigidbody: componente do objeto onde a fisica acontece
    [SerializeField] private Rigidbody rb;
    // 2) Controle Horizontal:
    private float _horizontalInput;
    // 3) Velocidades:
    private readonly float speedForward = 8;
    private readonly float speedHorizontal = 8;

    /* Obs.: sem condicao de parada por distancia
    // 4) Distancia: para controlar indiretamente a duracao
    private readonly float distance = 500f;
    */

    // Funcao que implementa o movimento na cena
    private void Update()
    {
        // Input Horizontal Padrão da Unity: a = esquerda, d = direita
        _horizontalInput = Input.GetAxis("Horizontal");

        // Componentes vetoriais do movimento:

        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.forward * speedForward * Time.deltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        Vector3 horizontalMove = transform.right * _horizontalInput * speedHorizontal * Time.deltaTime;
        // 3) Movimento Resultante:
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        /* Obs.: sem condicao de parada por distancia
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
        */

        Input.GetKeyDown(Space)
        {

        }
    }
}
