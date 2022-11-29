using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private SpriteRenderer SpR;
    public Sprite signOff, signOn;
    void Start()
    {
        SpR = GetComponent<SpriteRenderer>();
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            CheckPointController.instance.DeactiveCheckpoint();
            SpR.sprite = signOn;

            CheckPointController.instance.setSpawnPoint(transform.position);
        }
    }
    public void RestCheckPoint()
    {
        SpR.sprite = signOff;

    }
}
