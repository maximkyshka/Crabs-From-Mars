using UnityEngine;

public class MouseControler : MonoBehaviour
{
    private bool isLock;
    public bool IsLock { get => isLock; }
    
    private void Start()
    {
        Lock();
    }

    private void LateUpdate()
    {
        if (isLock)
        {
            Input.mousePosition.Set(0, 0, 0);
            Cursor.visible = false;
        }
    }

    public Mouse GetMousePosition()
    {
        return new Mouse(Input.mousePosition.x, Input.mousePosition.y, isLock);
    }
    
    public void Lock()
    {
        isLock = true;
        Cursor.visible = !isLock;
    }
    public void Unlock()
    {
        isLock = false;
        Cursor.visible = !isLock;
    }
    public void Charge()
    {
        isLock = !isLock;
        Cursor.visible = !isLock;
    }
    public void Set(bool value)
    {
        isLock = value;
        Cursor.visible = !isLock;
    }
}

/// <summary>
/// Mouse by MAX
/// </summary>
/// <param name="Mouse">Mouse</param>

public class Mouse
{
    private static int x;
    private static int y;
    private static bool isLocked;

    public static int X { get => x; }
    public static int Y { get => y; }
    public static bool IsLocked { get => isLocked; }
    
    public static Vector2 Position { get { return new Vector2(x, y); } }
    public static Vector2 GetPositionRelativeToCenter { get { return Screen.GetPositionRelativeToCenter(x, y); } }
    public Vector2 GetPositionRelativeToCenterForce { get { return Screen.GetPositionRelativeToCenterForce(x, y); } }
}

/// <summary>
/// Screen by MAX
/// </summary>
/// <param name="Screen">Screen</param>

public class Screen
{
    public static int Width { get => UnityEngine.Screen.width; }
    public static int Height { get => UnityEngine.Screen.height; }
    
    public static Vector2 Center { get => new Vector2(Width / 2, Height / 2); }
    public static Vector2 GetPositionRelativeToCenter(int x, int y) { return new Vector2(x, y) - Center; }
    public static Vector2 GetPositionRelativeToCenterForce(int x, int y) { return (new Vector2(x, y) - Center) / Center; }
}
