using UnityEngine;

public class ItemPlayerProjectile : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
