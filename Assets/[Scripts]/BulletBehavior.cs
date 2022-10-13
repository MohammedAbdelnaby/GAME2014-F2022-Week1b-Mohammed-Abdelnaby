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
    public BulletDirection BulletDirection;
    public float speed;
    public ScreenBounds bounds;
    public BulletManager bulletManager;
    public BulletType type;

    private Vector3 Velocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
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
            (transform.position.y < bounds.vertical.min))
        {
            bulletManager.ReturnBullet(this.gameObject, type);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


    public void SetDirection(BulletDirection direction)
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
}
