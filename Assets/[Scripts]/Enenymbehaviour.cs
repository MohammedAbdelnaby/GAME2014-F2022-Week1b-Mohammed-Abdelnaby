using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enenymbehaviour : Ship
{
    public Boundray horizontalBoundray;
    public Boundray verticalBoundray;

    private Boundray horizontalSpeedRange;
    private Boundray verticalSpeedRange;
    private float VerticalSpeed;
    private Color RandomColor;
    private SpriteRenderer spriteRenderer;
    private float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
        FireRate = 0.2f;
        ScreenBoundray.min = -6.0f;
        BulletSpawnPoint = transform.Find("BulletSpawnPoint");
        bulletManager = FindObjectOfType<BulletManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ResetShip();
        InvokeRepeating("FireBullet", 0.0f, FireRate);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    protected override void Move()
    {
        float horizontalLength = horizontalBoundray.max - horizontalBoundray.min;
        transform.position = new Vector3(Mathf.PingPong(Time.time * horizontalSpeed, horizontalLength) - horizontalBoundray.max,
                                         transform.position.y - VerticalSpeed * Time.deltaTime,
                                         transform.position.z);
    }

    protected override void CheckBounds()
    {
        if (transform.position.y < ScreenBoundray.min)
        {
            ResetShip();
        }
    }

    public void ResetShip()
    {
        var RandomXPostion = Random.Range(horizontalBoundray.min, horizontalBoundray.max);
        var RandomYPostion = Random.Range(verticalBoundray.min, verticalBoundray.max);
        horizontalSpeedRange.min = Random.Range(0.5f, 2.0f);
        horizontalSpeedRange.max = Random.Range(2.0f, 6.0f);
        verticalSpeedRange.min = Random.Range(0.5f, 2.0f);
        verticalSpeedRange.max = Random.Range(2.0f, 6.0f);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        VerticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        transform.position = new Vector3(RandomXPostion, RandomYPostion, 0.0f);
        List<Color> ColorList = new List<Color>() { Color.red, Color.yellow, Color.magenta, Color.white, Color.white };

        RandomColor = ColorList[Random.Range(0, ColorList.Count)];
        spriteRenderer.material.SetColor("_Color", RandomColor);
    }

    protected override void FireBullet()
    {
        var bullet = bulletManager.GetBullet(BulletSpawnPoint.position, BulletType.ENEMY);
    }
}
