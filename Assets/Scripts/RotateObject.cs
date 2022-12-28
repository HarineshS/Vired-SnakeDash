using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 1f; // the speed at which the object should rotate

    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime); // rotate the object along the z-axis
    }
}

