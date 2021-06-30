using System.Collections;
using UnityEngine;

public class SpawnerControllerPizza : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Player:
    [SerializeField] private GameObject _player;
    // 2) Script PlayerMovement: (precisamos da velocidade do jogador)
    public PlayerMovementPizza playerMovementPizza;
    // 3) Lista de objetos:
    [SerializeField] private GameObject[] _items;
    // 4) Delivery:
    [SerializeField] private GameObject[] _client;
    // 5) Posicao inicial:
    private Vector3 _initialPosition = new Vector3(0f, 0f, 35f);
    // 6) Posicoes das pistas:
    [SerializeField] private Vector3[] _lanePosition;
    // 7) Marcadores de tempo:
    private readonly float _timeInstantiation = .5f;
    private readonly float _timeDelivery = 2;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 8) Bool para spawn itens:
    private bool _spawnItems = true;
    // 9) Bool para spawn entregas:
    private bool _spawnDelivery = false;

    private void Awake()
    {
        // Posicao do Spawner na cena
        transform.position = _initialPosition;
        playerMovementPizza = _player.GetComponent<PlayerMovementPizza>();
    }

    private void Update()
    {

        if (_spawnItems)
        {
            _timeInterval = Time.time - _timeLast;
            if (_timeInterval >= _timeInstantiation)
            {
                transform.position = transform.position + transform.forward * playerMovementPizza.speedForward / 2f;
                SpawnItems();
                _timeLast = Time.time;
            }
        }

        if (_spawnDelivery)
        {
            _timeInterval = Time.time - _timeLast;
            if (_timeInterval >= _timeDelivery)
            {
                transform.position = transform.position + transform.forward * playerMovementPizza.speedForward * 2;
                SpawnDelivery();
                _timeLast = Time.time;
            }
        }

        StartCoroutine(DeliveryTime());
    }

    public void SpawnItems()
    {
        Instantiate(_items[Random.Range(0, _items.Length)], _lanePosition[Random.Range(0, _lanePosition.Length)] + transform.position, Quaternion.identity);
    }

    public void SpawnDelivery()
    {
        GameObject temp = Instantiate(_client[Random.Range(0, _client.Length)], _lanePosition[Random.Range(0, _lanePosition.Length)] + transform.position + transform.forward * 35, Quaternion.identity);
        Destroy(temp, 3);
    }

    private IEnumerator DeliveryTime()
    {
        yield return new WaitForSeconds(15);
        _spawnItems = false;
        yield return new WaitForSeconds(5);
        UIManager.activateUI = true;
        _spawnDelivery = true;
    }
}
