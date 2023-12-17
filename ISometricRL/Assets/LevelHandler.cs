using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject Hero;
    public GameObject Enemy;

    public Transform HeroSpawnPoint;
    public List<Transform> EnemySpawnPoints;

    public Transform EnemiesParent;

    private void Awake()
    {
        var heroObject = Instantiate(Hero);
        heroObject.transform.position = HeroSpawnPoint.position;

        EnemySpawnPoints.ForEach(point =>
        {
            var enemy = Instantiate(Enemy, EnemiesParent);
            enemy.transform.position = point.position;
        });
    }
}
