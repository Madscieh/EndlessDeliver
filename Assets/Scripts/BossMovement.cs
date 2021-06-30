using UnityEngine;
using UnityEngine.SceneManagement;

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
    // 8) Marcadores de tempo para loop:
    private readonly float _timeInstantiation = 3f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 9) Velocidade do projetil:
    private readonly float speedProjectile = -10;
    // 10) Componente horizontal do movimento:
    private Vector3 _horizontalMove;
    // 11) Componente vertical do movimento:
    private Vector3 _verticalMove;
    // 12) Numero da cena a ser chamada apos derrotar o boss:
    [SerializeField] private int _sceneNumber;

    // Inicializa variaveis _animator e _killBossButton
    private void Awake()
    {
        _bossAnimator = GetComponent<Animator>();
        playerMovement = _player.GetComponent<PlayerMovement>();
        _verticalMove = transform.position;
    }

    // Funcao que implementa o movimento do boss
    private void Update()
    {
        // Componentes vetoriais do movimento:
        // 1) Componente profundidade (eixo z: frente = positivo)
        _verticalMove += Vector3.forward * playerMovement.speedForward * Time.deltaTime;
        // 2) Componente horizontal (eixo x: direita = positivo)
        _horizontalMove = Vector3.MoveTowards(_horizontalMove, _lanePosition[0], .1f);
        if (Vector3.Distance(_horizontalMove, _lanePosition[0]) < .1f)
            _lanePosition[0] *= -1.0f;
        // 3) Movimento Resultante:
        transform.position = _verticalMove + _horizontalMove;

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
            SceneManager.LoadScene(_sceneNumber);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Funcao que implementa dano
        if (other.gameObject.CompareTag("Projectile"))
        {
            _healthBoss--;
            Destroy(other);
        }
    }
}
