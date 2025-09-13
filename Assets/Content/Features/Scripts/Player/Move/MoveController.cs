using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField, Range(0, 50)] private float speed = 10;
    [SerializeField, Range(0, 50)] private float speedRot = 10;
    [SerializeField, Range(0, 50)] private float jumpForce = 10;

    [SerializeField] private LayerMask layerGround;
    private bool isGround;
    public bool IsGround { get => isGround; }
    
    Rigidbody rb;
    MouseControler mouseControler;
    Camera camera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouseControler = GetComponent<MouseControler>();
        camera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        IsGroundDetec();
        Move();
        Jump();
        Rotate();
    }

    private void Move()
    {
        Vector3 t = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
        Debug.Log(t);
        rb.linearVelocity = t * speed;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Rotate()
    {
        MouseData rotateInput = mouseControler.GetMousePosition();
        
        float rotationAmountBody = rotateInput.GetPositionRelativeToCenterForce.x * speedRot * Time.deltaTime;
        float rotationAmountCam = rotateInput.GetPositionRelativeToCenterForce.y * speedRot * Time.deltaTime;
        
        transform.Rotate(0, rotationAmountBody, 0);
        camera.transform.Rotate(rotationAmountCam, 0, 0);
    }

    private void IsGroundDetec()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.25f, layerGround))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
}