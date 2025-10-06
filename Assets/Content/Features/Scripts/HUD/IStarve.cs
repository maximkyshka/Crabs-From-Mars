using System;
using UnityEngine;

public interface IStarve
{
    public event Action<int> OnStarveChanged;
    public System.Collections.IEnumerator UpdateStarve();
    public int CalculateDynamicRate();
}
