using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Transform do Boss:
    [SerializeField] private Transform tf;
    // 2) Animator do Boss:
    [SerializeField] private Animator _animator;
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
    // 8) Botao de KillBoss:
    private GameObject _killBossButton;

    // Inicializa variaveis _animator e _killBossButton
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        // _killBossButton = GameObject.Find("/Canvas/KillBoss");
    }

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

        // Funcao que implementa o projetil
        // Condicao de tempo para limitar a frequencia dos tiros
        _timeInterval = Time.time - _timeLast;
        if (_timeInterval >= _timeInstantiation)
        {
            // Instancia o projetil um pouco para tras (subtrai transform.forward * 2)
            GameObject projectile = Instantiate(_projectile, tf.transform.position - transform.forward * 2, Quaternion.identity);
            // Deixa o projetil com velocidade speedProjectile (<0) para tras
            projectile.GetComponent<Rigidbody>().velocity = speedProjectile * transform.forward;
            // Atualiza a condicao de tempo
            _timeLast = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Funcao que implementa dano
        if (other.gameObject.CompareTag("Projectile") && _healthBoss > 0)
            _healthBoss--;

        // Funcao que habilita o _killBossButton (ver script UIManager)
        // obs.: por ora, comeca habilitado
        if (_healthBoss <= 0)
        {
            // _killBossButton.SetActive(true);
        }
    }
}
