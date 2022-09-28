using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 2.0f;
    public Boundray boundray;
    public float VerticalPostions;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);

        var clampedPostion = Mathf.Clamp(transform.position.x, boundray.min, boundray.max);
        transform.position = new Vector2(clampedPostion, VerticalPostions);
    }   
}
