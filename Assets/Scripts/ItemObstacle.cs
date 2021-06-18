using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemObstacle : MonoBehaviour
{
    private AudioSource _audio;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 75 * Time.time, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // _audio.Play();
            Invoke(nameof(LoadMenu), .2f);
            Destroy(gameObject, .2f);
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
