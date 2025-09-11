using UnityEngine;
using TMPro;
using System.Collections;
public class Loading : MonoBehaviour
{
    [SerializeField] TMP_Text dots;
    private int dotCount;
    [SerializeField] private float dotDelay = 0.8f;
    void Start()
    {
        StartCoroutine(AnimateDots());
    }
    IEnumerator AnimateDots()
    {
        while (true)
        {
            dots.text = "Connecting" + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4;
            yield return new WaitForSeconds(dotDelay);
        }
    }
}
