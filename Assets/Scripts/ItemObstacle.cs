using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemObstacle : MonoBehaviour
{
    private AudioSource _audio;

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 50 * Time.time, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        // _audio.Play();
        Invoke(nameof(LoadMenu), .2f);
        Destroy(gameObject, .2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
