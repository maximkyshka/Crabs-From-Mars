using UnityEngine;

public class HealsePlayerControler : MonoBehaviour, IHealse
{
    public int MaxHealse { get; set; }
    public int Healse { get; set; }
    public int RegenerationSpeed { get; set; }
    public void Healsed(int healsed)
    {
        Healse += healsed;
        Healse = Mathf.Clamp(Healse, 0, MaxHealse);
    }

    public void Hit(int damage)
    {
        Healse -= damage;
        
    }
    
    [ContextMenu("Die")]
    public void Die()
    {
        Debug.Log($"I'm dead {((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}{((Letar)Random.Range(0, 52)).ToString()}");
    }

    enum Letar
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
    }
}