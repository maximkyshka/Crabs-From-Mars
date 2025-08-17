using UnityEngine;

public class RobotControler : MonoBehaviour
{
    [SerializeField, Range(0, 50)] private float speed = 10;
    [SerializeField, Range(0, 50)] private float speedRot = 10;

    void Update()
    {
        Vector3 moveDirection = GetMoveDirection();
        transform.position += moveDirection * speed * Time.deltaTime;
        
        float rotateInput = GetRotateInput();
        float rotationAmount = rotateInput * speedRot * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }

    Vector3 GetMoveDirection()
    {
        return (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
    }

    float GetRotateInput()
    {
        if (Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
        {
            return -1f;
        }
        else if (!Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
        {
            return 1f;
        }
        else
        {
            return 0f;
        }
    }
}