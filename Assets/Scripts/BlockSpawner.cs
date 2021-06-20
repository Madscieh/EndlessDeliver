using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    // Declaracao de variavel:
    // 1) Objeto do script BuildingSpawner
    private SceneSpawner _blockSpawner;

    // Inicializa a variavel buildingSpawner
    private void Start()
    {
        // Declara variavel como objeto sujeito ao script SceneSpawner
        _blockSpawner = GameObject.FindObjectOfType<SceneSpawner>();
    }

    // Funcao que cria quadras na frente e destroi aquelas
    // com quem o jogador acabou de colidir com delay de 2s
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Cria buildings com funcao SpawnBlocks do script SceneSpawner
            _blockSpawner.SpawnBlocks();
            // Destroi building colidido, com espera de 5s
            Destroy(gameObject, 5);
        }
    }
}
