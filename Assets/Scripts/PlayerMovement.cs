using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Rigidbody do Player:
    [SerializeField] private Rigidbody rb;
    // 2) Projetil:
    [SerializeField] private GameObject _projectile;
    // 3) Controle Horizontal:
    private float _horizontalInput;
    // 4) Velocidades do player:
    private readonly float speedForward = 8;
    private readonly float speedHorizontal = 8;
    // 5) Marcadores de tempo para projetil:
    private readonly float _timeInstantiation = .3f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 6) Velocidade do projetil:
    private readonly float speedProjectile = 15;
    // 7) Animator do jogador:
    public Animator _animatorPlayer;
    // 8) Animator das pizzas:
    public Animator animator;
    
    // Funcao que implementa o movimento do jogador
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

        // Funcao que implementa o projetil
        // Condicao de tempo para limitar a frequencia dos tiros
        _timeInterval = Time.time - _timeLast;
        if (Input.GetKeyDown(KeyCode.Space) && _timeInterval >= _timeInstantiation)
        {
            // Instancia o projetil um pouco para a frente (soma transform.forward * 2)
            GameObject projectile = Instantiate(_projectile, rb.transform.position + transform.forward * 2, Quaternion.identity);
            // Deixa o projetil com velocidade speedProjectile para frente
            projectile.GetComponent<Rigidbody>().velocity = speedProjectile * transform.forward;
            // Destroi o projetil depois de algum tempo
            Destroy(projectile, 15f);
            // Atualiza a condicao de tempo
            _timeLast = Time.time;
        }

        // Animacao das pizzas
        // Jogador vai para esquerda -> pizzas para direita
        if (_horizontalInput < 0)
        {
            animator.SetBool("VaiEsq", true);
            _animatorPlayer.SetBool("Left", true);
        }
        // Jogador vai para direita -> pizzas para a esquerda
        else if (_horizontalInput > 0)
        {
            animator.SetBool("VaiDir", true);
            _animatorPlayer.SetBool("Right", true);
        }
        // Jogador parado
        else
        {
            animator.SetBool("VaiEsq", false);
            animator.SetBool("VaiDir", false);
            _animatorPlayer.SetBool("Left", false);
            _animatorPlayer.SetBool("Right", false);
        }
    }
}
