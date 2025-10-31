/*using UnityEngine;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    [SerializeField] private InputAction inputVector;
    [SerializeField] private InputAction inputShift;
    
    private Character character;
    
    private float speedTurn;
    private float speedWalk;
    private float speedRun;
    private AnimationCurve speedCurve;

    private void Start()
    {
        character = GetComponent<Character>();
        Setup();
    }

    private void Walk()
    {
        if (inputVector.ReadValue<Vector2>() != Vector2.zero)
        {
            float coficient = ( !inputShift.ReadValue<bool>() ? speedWalk : speedRun ) * speedCurve.Evaluate( Mathf.Abs( ( transform.rotation.x + transform.rotation.z ) / 2 ) / 90 );
            Vector3 direction = new Vector3( inputVector.ReadValue<Vector2>().x, 0, inputVector.ReadValue<Vector2>().y );
        }
    }

    private void Setup()
    {
        speedTurn = character.SpeedTurn;
        speedWalk = character.SpeedWalk;
        speedRun = character.SpeedRun;
        speedCurve = character.SpeedCurve;
    }
}*/
