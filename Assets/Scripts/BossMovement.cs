using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Transform do Boss:
    [SerializeField] private Transform tf;
    // 2) Velocidade do Boss (igual a do Player):
    private readonly float speedForward = 8;
    // 3) Vida do Boss:
    private int _healthBoss = 3;
    // 4) Lista de objetos:
    [SerializeField] private GameObject _projectile;
    // 5) Posicoes das pistas:
    [SerializeField] private Vector3[] _lanePosition;
    // 6) Marcadores de tempo para projetil:
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 7) Velocidade do projetil:
    private readonly float speedProjectile = -15;

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
            GameObject projectile = Instantiate(_projectile, tf.transform.position - transform.forward * 2, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = speedProjectile * transform.forward;
            _timeLast = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            _healthBoss--;
        }

        if (_healthBoss <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
