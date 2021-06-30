using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public static int coinCounter = 0;
    public static int delivery = 3;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void ContadorDeMoedas()
    {
        coinCounter++;
    }

    public void ContadorDeEntregas()
    {
        delivery--;
        coinCounter += 5;
        if (delivery <= 0)
        {
            SceneManager.LoadScene(5);
        }
    }
}
