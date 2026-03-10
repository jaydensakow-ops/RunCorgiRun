using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    public PoopPlacer PoopPlacer;

    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed)
        {
            Corgi.Move(Vector2.up);
        }
        
        if (keyboard.sKey.isPressed)
        {
            Corgi.Move(Vector2.down);
        }

        if (keyboard.aKey.isPressed)
        {
            Corgi.Move(Vector2.left);
        }

        if (keyboard.dKey.isPressed)
        {
            Corgi.Move(Vector2.right);
        }
        
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
    }
}