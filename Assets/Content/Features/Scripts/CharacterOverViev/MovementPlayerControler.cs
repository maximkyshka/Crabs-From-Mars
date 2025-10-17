using UnityEngine;

public class MovementPlayerControler : MonoBehaviour, IMovement
{
    [field: SerializeField] public float SpeedTurn { get; set; } = 500f;
    [field: SerializeField] public float SpeedWalk { get; set; } = 5f;
    [field: SerializeField] public float SpeedRun { get; set; } = 10f;
    [field: SerializeField] public AnimationCurve SpeedCurve { get; set; } = AnimationCurve.Linear(0, 0, 1, 1);
    
    public CharacterController controller;
    public float Gravity = -19.62f;
    public float turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;
    private Vector3 _velocity;
    private float _currentMovementSpeed;
    private float _speedCurveTime = 0f;

    void Awake()
    {
        if (controller == null)
        {
            controller = GetComponent<CharacterController>();
        }

        _currentMovementSpeed = SpeedWalk;
    }

    void Update()
    {
        HandleGravity();
        HandleMovementInput();
        HandleRunningToggle();
        HandleRotation();
        
        controller.Move(_velocity * Time.deltaTime);
    }
    
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            _speedCurveTime += Time.deltaTime;
            _speedCurveTime = Mathf.Clamp01(_speedCurveTime);

            float targetSpeed = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? SpeedRun : SpeedWalk;
            float curvedFactor = SpeedCurve.Evaluate(_speedCurveTime);
            _currentMovementSpeed = Mathf.Lerp(SpeedWalk, targetSpeed, curvedFactor);

            Vector3 moveDir = transform.forward * verticalInput;

            Vector3 horizontalMove = moveDir.normalized * _currentMovementSpeed * Mathf.Abs(verticalInput);
            
            controller.Move(horizontalMove * Time.deltaTime);
            
            float turnAngle = horizontalInput * SpeedTurn * Time.deltaTime;
            transform.Rotate(0f, turnAngle, 0f);
        }
        else
        {
            _speedCurveTime -= Time.deltaTime * 2f;
            _speedCurveTime = Mathf.Clamp01(_speedCurveTime);
            _currentMovementSpeed = Mathf.Lerp(SpeedWalk, SpeedWalk, SpeedCurve.Evaluate(_speedCurveTime));
        }
    }

    private void HandleRunningToggle()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
             _speedCurveTime += Time.deltaTime;
        }
        else if (controller.isGrounded)
        {
            _speedCurveTime -= Time.deltaTime * 1.5f; 
        }

        _speedCurveTime = Mathf.Clamp01(_speedCurveTime);
    }
    
    private void HandleGravity()
    {
        if (controller.isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        _velocity.y += Gravity * Time.deltaTime;
    }
    
    private void HandleRotation()
    {
        float rotateInput = Input.GetAxis("Rotation");
        
        if (rotateInput != 0)
        {
            transform.Rotate(Vector3.up * rotateInput * SpeedTurn * Time.deltaTime);
        }
    }
}