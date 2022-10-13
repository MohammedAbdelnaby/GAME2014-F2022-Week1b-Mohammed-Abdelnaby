using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Player Properties")]
    [Range(10, 50)]
    public int PlayerBulletNumber = 50;
    public int PlayerBulletCount = 0;
    public int PlayerActiveBullets = 0;

    [Header("Enemy Properties")]
    [Range(10, 50)]
    public int EnemyBulletNumber = 50;
    public int EnemyBulletCount = 0;
    public int EnemyActiveBullets = 0;


    private BulletFactory factory;
    private Queue<GameObject> PlayerBulletPool;
    private Queue<GameObject> EnemyBulletPool;
    // Start is called before the first frame update
    void Start()
    {
        PlayerBulletPool = new Queue<GameObject>();
        EnemyBulletPool = new Queue<GameObject>();
        factory = GameObject.FindObjectOfType<BulletFactory>();
        BuildBulletPools();
    }

    void BuildBulletPools()
    {
        for (int i = 0; i < PlayerBulletNumber; i++)
        {
            PlayerBulletPool.Enqueue(factory.CreateBullet(BulletType.PLAYER));
        }
        for (int i = 0; i < EnemyBulletNumber; i++)
        {
            EnemyBulletPool.Enqueue(factory.CreateBullet(BulletType.ENEMY));
        }
        PlayerBulletCount = PlayerBulletPool.Count;
        EnemyBulletCount = EnemyBulletPool.Count;
    }

    public GameObject GetBullet(Vector2 postion, BulletType type)
    {
        GameObject bullet = null;

        switch (type)
        {
            case BulletType.ENEMY:
                {
                    if (EnemyBulletPool.Count < 1)
                    {
                        EnemyBulletPool.Enqueue(factory.CreateBullet(BulletType.ENEMY));
                    }
                    bullet = EnemyBulletPool.Dequeue();
                    EnemyBulletCount = EnemyBulletPool.Count;
                    EnemyActiveBullets++;
                }
                break;
            case BulletType.PLAYER:
                {
                    if (PlayerBulletPool.Count < 1)
                    {
                        PlayerBulletPool.Enqueue(factory.CreateBullet(BulletType.PLAYER));
                    }
                    bullet = PlayerBulletPool.Dequeue();
                    PlayerBulletCount = PlayerBulletPool.Count;
                    PlayerActiveBullets++;
                }
                break;
        }

        bullet.SetActive(true);
        bullet.transform.position = postion;
        return bullet;
    }

    public void ReturnBullet(GameObject bullet, BulletType type)
    {
        bullet.SetActive(false);
        switch (type)
        {
            case BulletType.ENEMY:
                EnemyBulletPool.Enqueue(bullet);
                EnemyBulletCount = EnemyBulletPool.Count;
                EnemyActiveBullets--;
                break;
            case BulletType.PLAYER:
                PlayerBulletPool.Enqueue(bullet);
                PlayerBulletCount = PlayerBulletPool.Count;
                PlayerActiveBullets--;
                break;
            default:
                break;
        }
    }
}
