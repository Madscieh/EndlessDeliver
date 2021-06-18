using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Declaracao de variaveis:
    public Animator animator;

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
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 6) Velocidade do projetil:
    private readonly float speedProjectile = 15;

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
        _timeInterval = Time.time - _timeLast;
        if (Input.GetKeyDown(KeyCode.Space) && _timeInterval >= _timeInstantiation)
        {
            GameObject projectile = Instantiate(_projectile, rb.transform.position + transform.forward * 2, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = speedProjectile * transform.forward;
            Destroy(projectile, 15f);
            _timeLast = Time.time;
        }
    }

    //atualização do movimento da torre de pizza
    private void FixedUpdate()
    {
        //pressionou o botão para esquerda
       if ( _horizontalInput <0)
        {
            Debug.Log("Esquerda");
            animator.SetBool("VaiEsq", true);   //move a torre de pizza para direita
        }else if(_horizontalInput > 0) //pressionou botão para direita
        {
            Debug.Log("Direita");
            animator.SetBool("VaiDir", true);  //move a torre de pizza para a esquerda
        }
        else   //torre de pizza parada
        {
            animator.SetBool("VaiEsq", false);
            animator.SetBool("VaiDir", false);
        }
    }
}
