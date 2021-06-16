using UnityEngine;

public class BossMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Velocidade:
    private readonly float speedForward = 8;
    // 2) Lista de objetos:
    [SerializeField] private GameObject _projectile;
    // 5) Posicoes das pista:
    [SerializeField] private Vector3[] _lanePosition;
    // 6) Marcadores de tempo para instanciacao de items:
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;

    // Funcao que implementa o movimento do boss
    private void Update()
    {
        // Componentes vetoriais do movimento:
        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.position + transform.forward * speedForward * Time.deltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        // Obs.: por ora, parado
        Vector3 horizontalMove = Vector3.zero;
        // 3) Movimento Resultante:
        transform.position = forwardMove + horizontalMove;

        _timeInterval = Time.time - _timeLast;
        if (_timeInterval >= _timeInstantiation)
        {
            Instantiate(_projectile, _lanePosition[Random.Range(0, _lanePosition.Length)] + transform.position, Quaternion.identity);
            _timeLast = Time.time;
        }
    }
}
