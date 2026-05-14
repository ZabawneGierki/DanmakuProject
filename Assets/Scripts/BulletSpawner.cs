using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{


    [SerializeField] private Pattern pattern;


    private void Start()
    {
        StartCoroutine(pattern.ShootPattern(transform));
    }


}
