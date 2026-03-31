using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    public UI Ui;
    
    private SpriteRenderer corgiSpriteRenderer;
    private bool isDrunk = false;
    private bool isPlastered = false;
    private Coroutine soberUpCoroutine;
    private int randomMoveCounter = 0;
    private int lastRandomDirection = 0;

    public void Awake()
    {
        corgiSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = lastRandomDirection;
        
        if (randomMoveCounter == 0)
        {
            direction = Random.Range(0, 4);
            lastRandomDirection = direction;
            randomMoveCounter = Random.Range(20, 60);
        }
        
        switch (direction)
        {
            case 0:
                Move(new Vector2(1, 0));
                break;
            case 1:
                Move(new Vector2(-1, 0));
                break;
            case 2:
                Move(new Vector2(0, 1));
                break;
            case 3:
                Move(new Vector2(0, -1));
                break;

                randomMoveCounter = randomMoveCounter - 1;
        }
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
        {
            Move(direction);
        }
        
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
            ScoreKeeper.AddPoint();
            Ui.SetScoreText(ScoreKeeper.GetScore());
            Destroy(other.gameObject);
        }
        else if (other.tag == "Pill")
        {
            SoberUp();
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Moonshine")
        {
            Destroy(other.gameObject);
            GetPlastered();
        }
    }

    private void GetPlastered()
    {
       isPlastered = true;
       ChangeToDrunkSprite();
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
        isPlastered = false;
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
