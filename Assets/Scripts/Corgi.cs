using System.Collections;
using UnityEngine;

public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    
    private SpriteRenderer corgiSpriteRenderer;
    private bool isDrunk = false;
    private Coroutine soberUpCoroutine;

    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkeness(direction);
        FaceCorrectDirection(direction);
        
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime;
        
        corgiSpriteRenderer.transform.Translate(movementAmount.x, movementAmount.y,0);
        
        corgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(corgiSpriteRenderer);
    }

    private Vector2 ApplyDrunkeness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }

        return direction;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Beer")
        {
            GetDrunk();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bone")
        {
            print("do bone things");
        }
        else if (other.tag == "Pill")
        {
            print("do pill things");
        }
}

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartsoberingUp();
    }

    private void StartsoberingUp()
    {
        if (soberUpCoroutine != null)
            StopCoroutine(soberUpCoroutine);
        soberUpCoroutine = StartCoroutine(CountdownUnitlSober());
    }

    IEnumerator CountdownUnitlSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSecond);
        SoberUp();
        
    }

    private void SoberUp()
    {
        ChangeToSoberSprite();
        isDrunk = false;
    }

    private void ChangeToSoberSprite()
    {
        corgiSpriteRenderer.sprite = SoberSprite;
    }

    private void ChangeToDrunkSprite()
    {
        corgiSpriteRenderer.sprite = DrunkSprite;
    }

    private void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            corgiSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            corgiSpriteRenderer.flipX = true;
        }
    }
    
    public Vector3 GetPosition()
    {
        return corgiSpriteRenderer.transform.position;
    }
}
