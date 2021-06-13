using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public static int coinCounter = 0;

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
}
