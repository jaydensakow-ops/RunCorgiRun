using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);
        
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime;
        
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y,0);
        
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            
        }
        else if (direction.x < 0)
        {
            
        }
    }
}
