using UnityEngine;

public class MovementPlayerControler : MonoBehaviour, IMovement
{
    public float SpeedTurn { get; set; }
    public float SpeedWalk { get; set; }
    public float SpeedRun { get; set; }
    public AnimationCurve SpeedCurve { get; set; }

    private void FixedUpdate()
    {
        Walk();
    }

    private void Walk()
    {
        Vector2 input;
        
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        
        if (input != Vector2.zero)
        {
            float coficient = ( !Input.GetKeyDown(KeyCode.LeftShift) ? SpeedWalk : SpeedRun ) * SpeedCurve.Evaluate( Mathf.Abs( ( transform.rotation.x + transform.rotation.z ) / 2 ) / 90 );
            Vector3 direction = new Vector3( input.x, 0, input.y );
        }
    }
}