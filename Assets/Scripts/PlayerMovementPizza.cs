using UnityEngine;

public class PlayerMovementPizza : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Rigidbody do Player:
    [SerializeField] private Rigidbody rb;
    // 2) Projetil:
    [SerializeField] private GameObject _projectile;
    // 3) Controle Horizontal:
    private float _horizontalInput;
    // 4) Velocidades do player:
    public float speedForward = 8;
    private readonly float speedHorizontal = 8;
    // 5) Marcadores de tempo para projetil:
    private readonly float _timeInstantiation = .3f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 6) Velocidade do projetil:
    private readonly float speedProjectile = 15;
    // 7) Animator do jogador:
    public Animator animatorPlayer;
    // 8) Animator das pizzas:
    public Animator animatorPizza;
    // 9) Bool para vericar se esta no chao para poder pular:
    private bool _isGrounded = true;
    
    // Funcao que implementa o movimento do jogador
    private void FixedUpdate()
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

        // Verifica se esta no chao antes de pular
        _isGrounded = Physics.Raycast(rb.position, Vector3.down, 1f, LayerMask.GetMask("Ground"));

        // Salto:
        if (Input.GetKeyDown(KeyCode.Space)/* && _isGrounded*/)
        {
            // Salto por AddForce
            rb.AddForce(transform.up * 50);
        }

        // Animacao das pizzas
        // Jogador vai para esquerda -> pizzas para direita
        if (_horizontalInput < 0)
        {
            animatorPizza.SetBool("VaiEsq", true);
            animatorPlayer.SetBool("Left", true);
        }
        // Jogador vai para direita -> pizzas para a esquerda
        else if (_horizontalInput > 0)
        {
            animatorPizza.SetBool("VaiDir", true);
            animatorPlayer.SetBool("Right", true);
        }
        // Jogador parado
        else
        {
            animatorPizza.SetBool("VaiEsq", false);
            animatorPizza.SetBool("VaiDir", false);
            animatorPlayer.SetBool("Left", false);
            animatorPlayer.SetBool("Right", false);
        }
    }

    // Funcao que implementa o projetil
    // Condicao de tempo para limitar a frequencia dos tiros
    public void DeliveryTime()
    {
        _timeInterval = Time.time - _timeLast;
        if (_timeInterval >= _timeInstantiation)
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
    }
}
