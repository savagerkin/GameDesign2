using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField]
    float _windForce = 10f;
    public void OnTriggerStay2D(Collider other)
    {
        var hitObj = other.gameObject;
        if (hitObj != null)
        {
            var rb = hitObj.GetComponent<Rigidbody2D>();
            var dir = transform.up;
            rb.AddForce(dir * _windForce);
        }
    }
}
