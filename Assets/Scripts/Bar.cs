using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxLength = 1f;
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    // Update is called once per frame
    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        transform.position = (ToPosition + StartPosition) / 2;
        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation =Quaternion.Euler(new Vector3(0,0, angle));

        float Length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);
    }
}
