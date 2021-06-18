using UnityEngine;

public class GroundTile : MonoBehaviour
{
    // Declaracao de variavel:
    // 1) Objeto do script GroundSpawner
    private GroundSpawner groundSpawner;

    // Inicializa a variavel groundSpawner
    void Start()
    {
        // Declara variavel como objeto sujeito ao script GroundSpawner
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    // Funcao que cria tile na frente e destroi aquele
    // com quem o jogador acabou de colidir com delay de 2s
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Cria tile com funcao SpawnTile do script GroundSpawner
            groundSpawner.SpawnTile();
            // Destroi tile colidido, com espera de 2s
            Destroy(gameObject, 2);
        }
    }

}
