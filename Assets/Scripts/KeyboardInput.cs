using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard.wKey.isPressedThisFrame)
        {
            Corgi.Move(Vector2.up);
        }
        
        if (keyboard.sKey.isPressedThisFrame)
        {
            Corgi.Move(Vector2.down);
        }

        if (keyboard.aKey.isPressedThisFrame)
        {
            Corgi.Move(Vector2.left);
        }

        if (keyboard.dKey.isPressedThisFrame)
        {
            Corgi.Move(Vector2.right);
        }
    }
}
