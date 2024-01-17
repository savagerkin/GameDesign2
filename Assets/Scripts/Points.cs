using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class Points : MonoBehaviour
{
    public bool Runtime = true;
    public Rigidbody2D rbd;
    public Vector2 PointID;
    public List<Bar> ConnectedBars;
    // Update is called once per frame
    private void Start()
    {
        if (Runtime == false)
        {
            rbd.bodyType = RigidbodyType2D.Static;
            PointID = transform.position;
            
            if (GameManager.AllPoints.ContainsKey(PointID) == false)
            {
                GameManager.AllPoints.Add(PointID, this);
            }
        }
    }
    void Update()
    {
        if (Runtime == false)
        {
            if (transform.hasChanged == true)
            {
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
    }
}
