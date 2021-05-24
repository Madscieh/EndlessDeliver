using UnityEngine;

public class BuildingsLeft : MonoBehaviour
{
    // Declaracao de variavel:
    // 1) Objeto do script BuildingSpawner
    private BuildingSpawnerLeft buildingSpawnerLeft;

    // Inicializa a variavel buildingSpawner
    void Start()
    {
        // Declara variavel como objeto sujeito ao script GroundSpawner
        buildingSpawnerLeft = GameObject.FindObjectOfType<BuildingSpawnerLeft>();
    }

    // Funcao que cria predios na frente e destroi aqueles
    // com quem o jogador acabou de colidir com delay de 2s
    private void OnTriggerExit(Collider other)
    {
        // Cria buildings com funcao SpawnBuilding do script BuildingSpawner
        buildingSpawnerLeft.SpawnBuildingLeft();
        // Destroi building colidido, com espera de 2s
        Destroy(gameObject, 2);
    }
}
