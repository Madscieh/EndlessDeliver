using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Player: (precisamos da velocidade do jogador)
    [SerializeField] private GameObject _player;
    // 2) Script PlayerMovement: (precisamos da velocidade do jogador)
    public PlayerMovement playerMovement;
    // 3) Lista de objetos:
    [SerializeField] private GameObject[] _items;
    // 4) Boss:
    [SerializeField] private GameObject _boss;
    // 5) Posicao inicial:
    private Vector3 _initialPosition = new Vector3( 0f, 0f, 35f);
    // 6) Posicoes das pistas:
    [SerializeField] private Vector3[] _lanePosition;
    // 7) Marcadores de tempo para items:
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 8) Bool para spawn itens:
    private bool _spawnItems = true;
    // 9) Bool para spawn boss:
    private bool _spawnBoss = true;

    private void Awake()
    {
        // Posicao do Spawner na cena
        transform.position = _initialPosition;
        // Script PlayerMovement onde esta a velocidade do player
        playerMovement = _player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_spawnItems)
        {
            _timeInterval = Time.time - _timeLast;
            if (_timeInterval >= _timeInstantiation)
            {
                transform.position = transform.position + transform.forward * playerMovement.speedForward / 2f;
                SpawnItems();
                _timeLast = Time.time;
            }
        }

        StartCoroutine(SpawnBoss());
    }

    public void SpawnItems()
    {
        Instantiate(_items[Random.Range(0, _items.Length)], _lanePosition[Random.Range(0, _lanePosition.Length)] + transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(15);
        _spawnItems = false;
        yield return new WaitForSeconds(5);
        if (_spawnBoss)
        {
            Instantiate(_boss, _initialPosition + transform.position + transform.up, Quaternion.identity);
            _spawnBoss = false;
        }
    }
}
