using UnityEngine;

public class FanSpin : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 300f;
    
    public Vector3 spinAxis = new Vector3(0, 1, 0); 

    void Update()
    {
        transform.Rotate(spinAxis * speed * Time.deltaTime);
    }
}