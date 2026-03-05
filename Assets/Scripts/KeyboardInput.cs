using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi corgi;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed)
        {
            corgi.Move(Vector2.up);
        }
        
        if (keyboard.sKey.isPressed)
        {
            corgi.Move(Vector2.down);
        }

        if (keyboard.aKey.isPressed)
        {
            corgi.Move(Vector2.left);
        }

        if (keyboard.dKey.isPressed)
        {
            corgi.Move(Vector2.right);
        }
    }
}