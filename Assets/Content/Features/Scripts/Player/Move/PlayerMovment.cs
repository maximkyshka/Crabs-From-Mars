using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField, Range(0,100f)] private float speed = 5.0f;
    [SerializeField, Range(0,100f)] private float jumpForce = 8.0f;
    [SerializeField, Range(-10,100f)] private float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            moveDirection = (transform.forward * v) + (transform.right * h);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
    }
}