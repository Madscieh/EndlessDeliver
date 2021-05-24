using UnityEngine;

public class BuildingsRight : MonoBehaviour
{
    // Declaracao de variavel:
    // 1) Objeto do script BuildingSpawner
    private BuildingSpawnerRight buildingSpawnerRight;

    // Inicializa a variavel buildingSpawner
    void Start()
    {
        // Declara variavel como objeto sujeito ao script GroundSpawner
        buildingSpawnerRight = GameObject.FindObjectOfType<BuildingSpawnerRight>();
    }

    // Funcao que cria predios na frente e destroi aqueles
    // com quem o jogador acabou de colidir com delay de 2s
    private void OnTriggerExit(Collider other)
    {
        // Cria buildings com funcao SpawnBuilding do script BuildingSpawner
        buildingSpawnerRight.SpawnBuildingRight();
        // Destroi building colidido, com espera de 2s
        Destroy(gameObject, 2);
    }
}
