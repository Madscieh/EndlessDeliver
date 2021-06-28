using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        Destroy(gameObject, 8f);
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 75 * Time.time, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MainManager.instance.ContadorDeMoedas();
            _audio.Play();
            Destroy(gameObject, .2f);
        }
    }
}
