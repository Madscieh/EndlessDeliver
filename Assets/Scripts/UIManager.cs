using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // 1) Bool para botao Pause:
    private bool _pause = false;
    // 2) Contador de moedas:
    [SerializeField] private Text _coinCounter;
    // 3) Quantidade de Deliveries ou de Vidas do Boss:
    private int _delivery = 3;
    // 4) Animator do Boss:
    [SerializeField] private Animator _animator;
    // 5) Texto Timer
    public GameObject timer;
    // 6) Bool para ativar Timer:
    public static bool activateUI;
    // 7) Variaveis do Timer:
    private float _currentTime;
    private float _startingTime = 30f;
    [SerializeField] private Text _timerText;

    private void Awake()
    {
        activateUI = false;
        timer.SetActive(false);
        _currentTime = _startingTime;
    }

    public void Update()
    {
        _coinCounter.text = MainManager.coinCounter.ToString();

        if (activateUI)
        {
            timer.SetActive(true);
            _currentTime -= Time.deltaTime;
            _timerText.text = _currentTime.ToString("0");

            if (_currentTime <= 0)
            {
                _currentTime = 0;
            }
        }
    }

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
}
