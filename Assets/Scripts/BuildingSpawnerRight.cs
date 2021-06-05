using UnityEngine;

public class BuildingSpawnerRight : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Lista de predios
    [SerializeField] private GameObject[] building;
    // 2) Posicao onde termina um predio e comeca o proximo
    private Vector3 _nextSpawnPoint;
    // 3) Numero inicial de predios a ser mantido no jogo
    // na medida em que outros são criados na frente e destruidos atras
    private readonly int numberOfBuildings = 8;

    // Funcao que instancia novos predios na cena
    // Obs: eh utilizada no script Buildings, por isso eh public
    public void SpawnBuildingRight()
    {
        // Instancia o predio
        // Declarado como objeto para obter o nextSpawnPoint que eh componente do prefab
        GameObject tempRight = Instantiate(building[Random.Range(0, building.Length)], _nextSpawnPoint, Quaternion.identity);
        // Posicao do proximo tile: esta no primeiro filho do prefab,
        // por isso o 0 em GetChild(0), lembrando que conta a partir do zero
        _nextSpawnPoint = tempRight.transform.GetChild(0).transform.position;
    }

    // Funcao para instanciar os predios iniciais da cena
    private void Start()
    {
        // Loop com numero predefinido de tiles
        for (int i = 0; i < numberOfBuildings; i++)
        {
            // Chama as funcao SpawnBuilding()
            SpawnBuildingRight();
        }
    }

}
