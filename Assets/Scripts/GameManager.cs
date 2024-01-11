using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public Dictionary<Vector2, Points> AllPoints = new Dictionary<Vector2, Points>();
    // Start is called before the first frame update
    void Awake()
    {
        AllPoints.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
