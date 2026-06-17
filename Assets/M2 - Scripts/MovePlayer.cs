using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float FlySpeed = 20;
    public float TurnSpeed = 20;
    public float TiltAngleUp = 25;
    public float TiltAngleSide = 25;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Move left & right, up & down and keep moving forward
        transform.position += Vector3.right * horizontal * TurnSpeed * Time.deltaTime;
        transform.position += Vector3.up * vertical * TurnSpeed * Time.deltaTime;
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        //Roate up & down, left & right
        float roateX = -vertical * TiltAngleUp;
        float roateZ = -horizontal * TiltAngleSide;
        transform.rotation = Quaternion.Euler(roateX, 0, roateZ);
    }
}