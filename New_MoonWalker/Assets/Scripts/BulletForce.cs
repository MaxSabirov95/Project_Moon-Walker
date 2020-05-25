using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public float bulletForce;

    void Update()
    {
        transform.Translate(Vector2.right * bulletForce * Time.deltaTime);
        Destroy(gameObject, 1f);
    }
}
