using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControl : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;

    private void Awake()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < spawnPoint.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, spawnPoint.transform.position.z);
        }
    }
}
