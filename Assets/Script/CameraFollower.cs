using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float MAX_X_DISTANCE;
    public float MAX_Z_DISTANCE;
    public float FOLLOW_SPEED;
    public Transform followee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = followee.position.x - transform.position.x;
        float dz = followee.position.z - transform.position.z;
        if (Mathf.Abs(dx) > MAX_X_DISTANCE)
        {
            transform.Translate(Mathf.Sign(dx) * FOLLOW_SPEED * Time.deltaTime, 0, 0, Space.World);
        }
        if (Mathf.Abs(dz) > MAX_Z_DISTANCE)
        {
            transform.Translate(0, 0, Mathf.Sign(dz) * FOLLOW_SPEED * Time.deltaTime, Space.World);
        }
    }
}
