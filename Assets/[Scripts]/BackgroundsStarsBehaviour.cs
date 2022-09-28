using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundsStarsBehaviour : MonoBehaviour
{
    public float verticalSpeed;
    public Boundray boundray;

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        transform.position -= new Vector3(0.0f, verticalSpeed * Time.deltaTime);
    }

    public void CheckBounds()
    {
        if (transform.position.y < boundray.min)
        {
            ResetStarts();
        }
    }

    public void ResetStarts()
    {
        transform.position = new Vector2(0.0f, boundray.max);
    }
}
