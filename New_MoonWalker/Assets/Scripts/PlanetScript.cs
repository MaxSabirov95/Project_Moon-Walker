using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScript : MonoBehaviour
{
    public float gravity;

    public void Attract(Rigidbody2D rb2D)
    {
        Vector2 gravityUp = (rb2D.transform.position - transform.position).normalized;
        Vector2 localUp = rb2D.transform.up;

        rb2D.AddForce(gravity * gravityUp);

        Quaternion targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * rb2D.transform.rotation;
        rb2D.transform.rotation = Quaternion.Slerp(rb2D.transform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
