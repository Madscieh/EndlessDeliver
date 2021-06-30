using UnityEngine;

public class ItemClient : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            MainManager.instance.ContadorDeEntregas();
            Destroy(gameObject, .2f);
        }
    }
}
