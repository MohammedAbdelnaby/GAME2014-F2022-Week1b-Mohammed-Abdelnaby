using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    [Header("Bullet Properties")]
    public Queue<GameObject> BulletPool;
    public GameObject bulletPrefab;
    public int BulletNumber = 50;
    public Transform BulletParent;
    public int BulletCount = 0;
    public int activeBullets = 0;

    // Start is called before the first frame update
    void Start()
    {
        BulletPool = new Queue<GameObject>();
        BuildBulletPool();
    }

    void BuildBulletPool()
    {
        for (int i = 0; i < BulletNumber; i++)
        {
            CreateBullet();
        }
        BulletCount = BulletPool.Count;
    }

    public GameObject GetBullet(Vector2 postion, BulletDirection direction)
    {
        if (BulletPool.Count < 1)
        {
            CreateBullet();
        }
        var bullet = BulletPool.Dequeue();
        bullet.SetActive(true);
        bullet.transform.position = postion;
        bullet.GetComponent<BulletBehavior>().SetDirection(direction);
        BulletCount = BulletPool.Count;
        activeBullets++;
        return bullet;
    }

    private void CreateBullet()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        bullet.transform.SetParent(BulletParent);
        BulletPool.Enqueue(bullet);
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        BulletPool.Enqueue(bullet);
        BulletCount = BulletPool.Count;
        activeBullets--;
    }
}
