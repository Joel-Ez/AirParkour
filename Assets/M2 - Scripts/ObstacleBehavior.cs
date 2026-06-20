using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [Header("Rotación")]
    public bool rotate = true;
    public float rotateSpeed = 100f;

    [Header("Zigzag")]
    public bool zigzag = true;
    public float moveSpeed = 2f;
    public float moveRange = 3f;

    private Vector3 rotatePivot;
    private float randomZigzagX;
    private float randomZigzagY;

    void Start()
    {
        rotatePivot = new Vector3(Random.Range(-1f, 1f),
            Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        randomZigzagX = Random.Range(0f, 100f);
        randomZigzagY = Random.Range(0f, 100f);
        
        rotateSpeed *= Random.Range(0.8f, 1.2f);
        moveSpeed *= Random.Range(0.8f, 1.2f);
    }

    void Update()
    {
        if (rotate)
        {
            transform.Rotate(rotatePivot * rotateSpeed * Time.deltaTime);
        }

        if (zigzag)
        {
            float movementX = Mathf.Sin(Time.time * moveSpeed + randomZigzagX) * moveRange * Time.deltaTime;
            float movementY = Mathf.Sin(Time.time * moveSpeed + randomZigzagY) * moveRange * Time.deltaTime;

            transform.Translate(Vector3.right * movementX, Space.World);
            transform.Translate(Vector3.up * movementY, Space.World);
        }
    }
}
