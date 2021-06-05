using UnityEngine;

public class EndOfSceneSpawnerController : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Velocidade:
    private readonly float speedForward = 8;
    // 2) Lista de objetos:
    [SerializeField] private GameObject[] _items;
    // 3) Posicao inicial:
    private Vector3 _initialPosition = new Vector3( 0f, 0f, 80f);
    // 3) Posicoes das pista:
    [SerializeField] private Vector3[] _lanePosition;
    // 4) Marcadores de tempo para instanciacao de items:
    private readonly float _timeInstantiation = .5f;
    private float _timeInterval = 0f;
    private float _timeLast = 0f;

    private void Awake()
    {
        transform.position = _initialPosition;
    }

    private void Update()
    {
        // Posicao do Spawner no final da cena
        _timeInterval = Time.time - _timeLast;
        if (_timeInterval >= _timeInstantiation)
        {
            transform.position = transform.position + transform.forward * speedForward / 2f;
            SpawnItems();
            _timeLast = Time.time;
        }
    }

    public void SpawnItems()
    {
        Instantiate(_items[Random.Range(0, _items.Length)], _lanePosition[Random.Range(0, _lanePosition.Length)] + transform.position, Quaternion.identity);
    }
}
