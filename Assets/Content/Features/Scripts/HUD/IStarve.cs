using UnityEngine;

public interface IStarve
{
    public System.Collections.IEnumerator UpdateStarve();
    public int CalculateDynamicRate();
}
