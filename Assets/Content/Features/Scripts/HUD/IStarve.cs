using System;
using System.Collections;

public interface IStarve
{
    event Action<int> OnStarveChanged;

    int Hunger { get; set; }

    IEnumerator UpdateStarve();

    int CalculateDynamicRate();
}
