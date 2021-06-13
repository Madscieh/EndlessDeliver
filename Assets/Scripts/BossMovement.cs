using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Velocidade:
    private readonly float speedForward = 8;
    
    // Funcao que implementa o movimento do boss
    private void Update()
    {
        // Componentes vetoriais do movimento:

        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.position + transform.forward * speedForward * Time.deltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        Vector3 horizontalMove = Vector3.zero;
        // 3) Movimento Resultante:
        transform.position = forwardMove + horizontalMove;
    }
}
