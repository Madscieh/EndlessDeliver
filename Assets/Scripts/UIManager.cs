using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool pause = false;
    [SerializeField] private Text _coinCounter;

    public void Pause()
    {
        if (!pause)
        {
            Time.timeScale = 0;
            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
        }
    }

    public void Update()
    {
        _coinCounter.text = MainManager.coinCounter.ToString();
    }
}
