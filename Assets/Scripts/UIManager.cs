using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private bool _pause = false;
    [SerializeField] private Text _coinCounter;

    public void Pause()
    {
        if (!_pause)
        {
            Time.timeScale = 0;
            _pause = true;
        }
        else
        {
            Time.timeScale = 1;
            _pause = false;
        }
    }

    public void Update()
    {
        _coinCounter.text = MainManager.coinCounter.ToString();
    }
}
