using UnityEngine;

public class BuildingSpawnerLeft : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Lista de predios
    public GameObject[] building;
    // 2) Numero de assets de predios
    private int numberOfBuildingAssets = 4;
    // 3) Posicao onde termina um predio e comeca o proximo
    private Vector3 nextSpawnPoint;
    // 4) Numero inicial de predios a ser mantido no jogo
    // na medida em que outros são criados na frente e destruidos atras
    private int numberOfBuildings = 20;

    // Funcao que instancia novos predios na cena
    // Obs: eh utilizada no script Buildings, por isso eh public
    public void SpawnBuildingLeft()
    {
        // Instancia o predio
        // Declarado como objeto para obter o nextSpawnPoint que eh componente do prefab
        GameObject tempLeft = Instantiate(building[Random.Range(0, numberOfBuildingAssets)], nextSpawnPoint, Quaternion.identity);
        // Posicao do proximo tile: esta no segundo filho do prefab,
        // por isso o 1 em GetChild(1), lembrando que conta a partir do zero
        nextSpawnPoint = tempLeft.transform.GetChild(1).transform.position;
    }

    // Funcao para instanciar os predios iniciais da cena
    private void Start()
    {
        // Loop com numero predefinido de tiles
        for (int i = 0; i < numberOfBuildings; i++)
        {
            // Chama as funcao SpawnBuilding()
            SpawnBuildingLeft();
        }
    }

}
