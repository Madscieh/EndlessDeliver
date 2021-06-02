using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Declaracao de variaveis:
    // 1) Unidade basica da pista (tile)
    public GameObject groundTile;
    // 2) Posicao onde termina um tile e comeca o proximo
    private Vector3 nextSpawnPoint;
    // 3) Numero inicial de tiles a ser mantido no jogo
    // na medida em que outros são criados na frente e destruidos atras
    private int numberOfTiles = 20;

    // Funcao que instancia novos tiles na cena
    // Obs: eh utilizada no script GroundTile, por isso eh public
    public void SpawnTile()
    {
        // Instancia o tile
        // Declarado como objeto para obter o nextSpawnPoint que e componente do prefab
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        // Posicao do proximo tile: esta no segundo filho do prefab,
        // por isso o 1 em GetChild(1), lembrando que conta a partir do zero
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Funcao para instanciar os tiles iniciais da cena
    private void Start()
    {
        // Loop com numero predefinido de tiles
        for (int i = 0; i < numberOfTiles; i++)
        {
            // Chama a funcao SpawnTile()
            SpawnTile();
        }
    }

}
