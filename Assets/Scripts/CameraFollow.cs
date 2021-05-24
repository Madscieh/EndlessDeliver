using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Posicao do jogador
    public Transform player;
    // 2) Vetor distancia da camera ate o jogador
    private Vector3 offset;

    // Inicializa o offset
    void Start()
    {
        // Vetor distancia da camera ate o jogador
        // Obs: constante durante o jogo
        offset = transform.position - player.position;
    }

    // Funcao para definir posicao da camera
    void Update()
    {
        // Vetor da posicao da camera com base na do jogador
        Vector3 cameraPosition = player.position + offset;
        // Fixa a coordenada x da camera para manter no centro da pista,
        // ignorando o movimento horizontal do jogador
        cameraPosition.x = 0;
        // Atualiza a posicao da camera
        transform.position = cameraPosition;
    }
}
