using System.Collections;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Velocidade:
    private readonly float speedForward = 8;
    // 2) Lista de objetos:
    [SerializeField] private GameObject[] _items;
    // 3) Boss:
    [SerializeField] private GameObject _boss;
    // 4) Posicao inicial:
    private Vector3 _initialPosition = new Vector3( 0f, 0f, 80f);
    // 5) Posicoes das pista:
    [SerializeField] private Vector3[] _lanePosition;
    // 6) Marcadores de tempo para instanciacao de items:
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;
    // 7) Bool para spawn itens:
    private bool _spawnItems = true;
    // 8) Bool para spawn boss:
    private bool _spawnBoss = true;

    private void Awake()
    {
        // Posicao do Spawner no final da cena
        transform.position = _initialPosition;
    }

    private void Update()
    {
        if (_spawnItems)
        {
            _timeInterval = Time.time - _timeLast;
            if (_timeInterval >= _timeInstantiation)
            {
                transform.position = transform.position + transform.forward * speedForward / 2f;
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
        yield return new WaitForSeconds(10);
        if (_spawnBoss)
        {
            Instantiate(_boss, _initialPosition + transform.position, Quaternion.identity);
            _spawnBoss = false;
        }
    }
}
