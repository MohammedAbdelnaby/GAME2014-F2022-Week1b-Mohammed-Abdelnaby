using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Sprite PlayerBulletSprite;
    public Sprite EnemyBulletSprite;


    public Transform BulletParent;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        PlayerBulletSprite = Resources.Load<Sprite>("Sprite/Bullet");
        EnemyBulletSprite = Resources.Load<Sprite>("Sprite/EnemySmallBullet");
        BulletPrefab = Resources.Load<GameObject>("Prefabs/PlayerBullet");
        BulletParent = GameObject.Find("Bullets").transform;
    }

    public GameObject CreateBullet(BulletType type)
    {
        GameObject bullet = Instantiate(BulletPrefab, Vector3.zero, Quaternion.identity, BulletParent); ;

        switch (type)
        {
            case BulletType.ENEMY:
                bullet.GetComponent<SpriteRenderer>().sprite = EnemyBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(BulletDirection.DOWN);
                break;
            case BulletType.PLAYER:
                bullet.GetComponent<SpriteRenderer>().sprite = PlayerBulletSprite;
                bullet.GetComponent<BulletBehavior>().SetDirection(BulletDirection.UP);
                bullet.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
                break;
            default:
                break;
        }
        bullet.SetActive(true);
        return bullet;
    }
}
