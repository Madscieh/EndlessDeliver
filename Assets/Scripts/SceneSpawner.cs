using UnityEngine;

public class SceneSpawner : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Lista de quadras
    [SerializeField] private GameObject[] blocks;
    // 2) Posicao onde termina uma quadra e comeca a proxima
    private Vector3 _nextSpawnPoint;
    // 3) Numero inicial de predios a ser mantido no jogo
    // na medida em que outros sao criados na frente e destruidos atras
    private readonly int numberOfBuildings = 5;

    // Funcao que instancia novos predios na cena
    // Obs: eh utilizada no script Buildings, por isso eh public
    public void SpawnBlocks()
    {
        // Instancia a quadra
        // Declarado como objeto para obter o nextSpawnPoint que eh componente do prefab
        GameObject tempBlock = Instantiate(blocks[Random.Range(0, blocks.Length)], _nextSpawnPoint, Quaternion.identity);
        // Posicao do proximo tile: esta no primeiro filho do prefab (GetChild(0))
        _nextSpawnPoint = tempBlock.transform.GetChild(0).transform.position;
    }

    // Funcao para instanciar as quadras iniciais da cena
    private void Start()
    {
        // Loop com numero predefinido de tiles
        for (int i = 0; i < numberOfBuildings; i++)
        {
            // Chama as funcao SpawnBlocks()
            SpawnBlocks();
        }
    }
}
