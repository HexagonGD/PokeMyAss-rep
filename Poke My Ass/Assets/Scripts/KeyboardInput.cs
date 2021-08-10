using UnityEngine;

public class KeyboardInput : IInput
{
    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }
}
