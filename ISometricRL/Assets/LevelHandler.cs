using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public GameObject Hero;
    public Transform HeroSpawnPoint;

    private void Awake()
    {
        var heroObject = Instantiate(Hero);
        heroObject.transform.position = HeroSpawnPoint.position;
    }
}
