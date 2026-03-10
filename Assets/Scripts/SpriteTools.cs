using UnityEngine;

public static class SpriteTools
{
    public static Vector3 ConstrainToScreenSimple(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        if (screenPosition.x > Screen.width)
            screenPosition.x = Screen.width;

        if (screenPosition.x < 0)
            screenPosition.x = 0;

        if (screenPosition.y > Screen.height)
            screenPosition.y = Screen.height;

        if (screenPosition.y < 0)
            screenPosition.y = 0;

        return Camera.main.ScreenToWorldPoint(screenPosition);
        
    }
    
    public static Vector3 ConstrainToScreen(SpriteRenderer spriteRenderer)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);

        float halfWidth = SpriteHalfWidth(spriteRenderer);
        float halfHeight = SpriteHalfHeight(spriteRenderer);

        if (screenPosition.x + halfWidth > Screen.width)
            screenPosition.x = Screen.width - halfWidth;

        if (screenPosition.x - halfWidth < 0)
            screenPosition.x = halfWidth;

        if (screenPosition.y + halfHeight > Screen.height)
            screenPosition.y = Screen.height - halfHeight;

        if (screenPosition.y - halfHeight < 0)
            screenPosition.y = halfHeight;

        return Camera.main.ScreenToWorldPoint(screenPosition);
    }

    private static float SpriteHalfWidth(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.width / 2;
    }

    private static float SpriteHalfHeight(SpriteRenderer spriteRenderer)
    {
        return spriteRenderer.sprite.rect.height / 2;
    }
}