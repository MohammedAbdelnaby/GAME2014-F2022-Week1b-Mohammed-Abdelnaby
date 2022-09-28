using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 2.0f;
    public Boundray boundray;
    public float VerticalPostions;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        //ConventionalInput();
        MobileInput();
        Move();
    }

    public void Move()
    {
        var clampedPostion = Mathf.Clamp(transform.position.x, boundray.min, boundray.max);
        transform.position = new Vector2(clampedPostion, VerticalPostions);
    }   

    public void ConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0.0f, 0.0f);
    }

    public void MobileInput()
    {
        foreach (var touch in Input.touches)
        {
            transform.position = camera.ScreenToWorldPoint(touch.position);
        }
    }
}
