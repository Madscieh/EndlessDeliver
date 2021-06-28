using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Transform do Boss:
    [SerializeField] private Transform _tf;
    // 2) Animator do Boss:
    [SerializeField] private Animator _bossAnimator;
    // 3) Player: (precisamos da velocidade do jogador)
    [SerializeField] private GameObject _player;
    // 4) Script PlayerMovement: (precisamos da velocidade do jogador)
    public PlayerMovement playerMovement;
    // 5) Vida do Boss:
    private int _healthBoss = 3;
    // 6) Lista de objetos:
    [SerializeField] private GameObject _projectile;
    // 7) Posicoes das pistas:
    [SerializeField] private Vector3[] _lanePosition;
    // 8) Marcadores de tempo para projetil:
    private readonly float _timeInstantiation = 1f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 9) Velocidade do projetil:
    private readonly float speedProjectile = -15;

    // Inicializa variaveis _animator e _killBossButton
    private void Awake()
    {
        _bossAnimator = GetComponent<Animator>();
        playerMovement = _player.GetComponent<PlayerMovement>();
    }

    // Funcao que implementa o movimento do boss
    private void Update()
    {
        // Componentes vetoriais do movimento:
        // 1) Componente profundidade (eixo z: frente = positivo)
        Vector3 forwardMove = transform.position + transform.forward * playerMovement.speedForward * Time.deltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        Vector3 horizontalMove = Vector3.zero;
        // 3) Movimento Resultante:
        transform.position = forwardMove + horizontalMove;

        // Funcao que implementa o projetil
        // Condicao de tempo para limitar a frequencia dos tiros
        _timeInterval = Time.time - _timeLast;
        if (_timeInterval >= _timeInstantiation)
        {
            // Instancia o projetil um pouco para tras (subtrai transform.forward * 2)
            GameObject projectile = Instantiate(_projectile, _tf.transform.position - transform.forward * 2, Quaternion.identity);
            // Deixa o projetil com velocidade speedProjectile (<0) para tras
            projectile.GetComponent<Rigidbody>().velocity = speedProjectile * transform.forward;
            // Atualiza a condicao de tempo
            _timeLast = Time.time;
        }

        // Funcao que habilita o _killBossButton (ver script UIManager)
        if (_healthBoss <= 0)
        {
            UIManager.activateUI = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Funcao que implementa dano
        if (other.gameObject.CompareTag("Projectile"))
        {
            _healthBoss--;
        }
    }
}
