using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float FlySpeed = 20;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;
    }
}