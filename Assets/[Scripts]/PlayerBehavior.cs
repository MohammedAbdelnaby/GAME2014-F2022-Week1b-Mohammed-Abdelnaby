using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerBehavior : Ship
{
    [Header("Player Properties")]
    public float VerticalPostions;

    private bool UsingMobileInput = false;
    private ScoreManager scoreManager;
    private Camera camera;
    private void Start()
    {
        speed = 10.0f;
        ScreenBoundray.min = -1.9f;
        ScreenBoundray.max = 1.9f;
        FireRate = 0.1f;
        BulletSpawnPoint = transform.Find("BulletSpawnPoint");
        scoreManager = FindObjectOfType<ScoreManager>();
        bulletManager = FindObjectOfType<BulletManager>();
        camera = Camera.main;

        UsingMobileInput = Application.platform == RuntimePlatform.Android || 
                           Application.platform == RuntimePlatform.IPhonePlayer;

        InvokeRepeating("FireBullet", 0.0f, FireRate);
    }
    // Update is called once per frame
    void Update()
    {
        if (UsingMobileInput)
        {
            MobileInput();
        }
        else
        {
            ConventionalInput();
        }
        Move();

        if (Input.GetKeyDown(KeyCode.K))
        {
            scoreManager.AddPoints(1);
        }
    }

    protected override void Move()
    {
        var clampedPostion = Mathf.Clamp(transform.position.x, ScreenBoundray.min, ScreenBoundray.max);
        transform.position = new Vector2(clampedPostion, VerticalPostions);
    }

    protected override void CheckBounds()
    { 
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
            var distination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, distination, Time.deltaTime * speed);
        }
    }

    protected override void FireBullet()
    {
        var bullet = bulletManager.GetBullet(BulletSpawnPoint.position, BulletType.PLAYER);
    }
}
