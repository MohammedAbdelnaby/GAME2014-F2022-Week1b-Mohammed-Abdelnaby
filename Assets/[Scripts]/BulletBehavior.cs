using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScreenBounds
{
    public Boundray horizontal;
    public Boundray vertical;
}

public class BulletBehavior : MonoBehaviour
{
    public BulletDirection direction;
    public float speed;
    public Vector3 Velocity;
    public ScreenBounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        switch (direction)
        {
            case BulletDirection.UP:
                Velocity = Vector3.up * speed;
                break;
            case BulletDirection.RIGHT:
                Velocity = Vector3.right * speed;
                break;
            case BulletDirection.DOWN:
                Velocity = Vector3.down * speed;
                break;
            case BulletDirection.LEFT:
                Velocity = Vector3.left * speed;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBoundry();
    }

    public void Move()
    {
        transform.position += Velocity * Time.deltaTime;
    }

    public void CheckBoundry()
    {
        if ((transform.position.x > bounds.horizontal.max) ||
            (transform.position.x < bounds.horizontal.min) ||
            (transform.position.y > bounds.vertical.max)   ||
            (transform.position.x < bounds.vertical.min))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
