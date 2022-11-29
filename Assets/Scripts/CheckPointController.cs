using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController instance;

    public CheckPoint[] checkPoints;

    public Vector3 spawnPoint;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
       spawnPoint = newSpawnPoint;
    }
    public void DeactiveCheckpoint()
    {
        for(int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].RestCheckPoint();
        }
    }

}
