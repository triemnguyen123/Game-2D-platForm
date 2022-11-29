using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool gem, isHeal;
    private bool isCollected;
    public GameObject pickUpEffect;
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isCollected)
        {
            if (gem)
            {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
                UlController.instance.UpdateGemCount();

                Instantiate(pickUpEffect,transform.position,transform.rotation);
                
            }
            if (isHeal)
            {
                if (PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);

                    Instantiate(pickUpEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
