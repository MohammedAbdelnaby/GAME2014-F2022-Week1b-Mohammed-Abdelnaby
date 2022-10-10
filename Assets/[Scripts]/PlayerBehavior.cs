using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Player Properties")]
    public float speed = 2.0f;
    public Boundray boundray;
    public float VerticalPostions;
    public bool UsingMobileInput = false;
    public float HorizontalSpeed = 10.0f;
    public ScoreManager scoreManager;
    private Camera camera;

    [Header("Bullet Properties")]
    public Transform BulletSpawnPoint;
    public GameObject BulletPrefab;
    public float FireRate;
    public Transform BulletParent;

    private void Start()
    {
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
            var distination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, distination, Time.deltaTime * HorizontalSpeed);
        }
    }

    void FireBullet()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity, BulletParent);
    }
}
