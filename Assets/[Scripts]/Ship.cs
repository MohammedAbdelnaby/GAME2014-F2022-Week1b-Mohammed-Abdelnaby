using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{
    protected float speed;
    protected float FireRate;
    protected BulletManager bulletManager;
    protected Transform BulletSpawnPoint;
    protected Boundray ScreenBoundray;

    protected abstract void Move();
    protected abstract void CheckBounds();
    protected abstract void FireBullet();
}
