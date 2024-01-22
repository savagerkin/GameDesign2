using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float Cost = 1; //If you want to remove cost just change the prefabs cost to 0 and hide the slider of values.
    public float maxLength = 1f;
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;

    public HingeJoint2D StartJoint;

    public HingeJoint2D EndJoint;

    // Update is called once per frame
    float StartJointCurrentLoad = 0f;
    float EndJointCurrentLoad = 0f;
    MaterialPropertyBlock propBlock;
    public float actualCost;

    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        transform.position = (ToPosition + StartPosition) / 2;

        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float Length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;
        actualCost = Length * Cost;
    }

    public void UpdateMaterial()
    {
        if (StartJoint != null) StartJointCurrentLoad = StartJoint.reactionForce.magnitude / StartJoint.breakForce;
        if (EndJoint != null) EndJointCurrentLoad = EndJoint.reactionForce.magnitude / EndJoint.breakForce;
        float maxLoad = Mathf.Max(StartJointCurrentLoad, EndJointCurrentLoad);
        propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Load", maxLoad);
        barSpriteRenderer.SetPropertyBlock(propBlock);
    }

    public void Update()
    {
        if (Time.timeScale == 1)
        {
            UpdateMaterial();
        }
    }
}