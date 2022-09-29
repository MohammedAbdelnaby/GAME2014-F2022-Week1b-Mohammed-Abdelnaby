using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 4)]
    public int AmountEnemy = 3;
    public GameObject EnemyPrefab;
    public List<GameObject> EnemyList;
    // Start is called before the first frame update
    void Start()
    {
        BuildEnemyList();
    }

    public void BuildEnemyList()
    {
        EnemyList = new List<GameObject>();
        for (int i = 0; i < AmountEnemy; i++)
        {
            var enemy = Instantiate(EnemyPrefab);
            EnemyList.Add(enemy);
        }
    }
}
