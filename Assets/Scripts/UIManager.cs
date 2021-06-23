using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private bool _pause = false;
    [SerializeField] private Text _coinCounter;
    private int _killBoss = 3;
    // 2) Animator do Boss:
    [SerializeField] private Animator _animator;

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

    public void KillBoss()
    {
        _killBoss--;
        if (_killBoss <= 0)
        {
            SceneManager.LoadScene(0);
            // StartCoroutine(EndLevel());
        }
    }

    private IEnumerator EndLevel()
    {
        _animator.SetBool("Die", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    public void Update()
    {
        _coinCounter.text = MainManager.coinCounter.ToString();
    }
}
