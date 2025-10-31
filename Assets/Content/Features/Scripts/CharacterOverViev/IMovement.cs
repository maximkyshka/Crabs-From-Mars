using UnityEngine;

public interface IMovement 
{
    public float SpeedTurn { get; set; }
    public float SpeedWalk { get; set; }
    public float SpeedRun { get; set; }
    public AnimationCurve SpeedCurve { get; set; }
}