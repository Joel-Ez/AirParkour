using UnityEngine;

public class DestroyOnExit : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
