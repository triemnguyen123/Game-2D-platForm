using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    public float invisibleLength;
    private float invisibleCounter;
    public SpriteRenderer spR;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        spR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invisibleCounter > 0)
        {
            invisibleCounter -= Time.deltaTime;
            if(invisibleCounter < 0)
            {
                spR.color = new Color(spR.color.r, spR.color.g, spR.color.b, 1f);
            }
        }
       
    }
    public void DealDamage()
    {
        if (invisibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);
                Instantiate(deathEffect,transform.position,transform.rotation);
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invisibleCounter = invisibleLength;
                spR.color = new Color(spR.color.r,spR.color.g,spR.color.b,.5f);
                PlayerController.instance.KnockBack();
            }
            UlController.instance.UpdateHealthDisplay();
            
        }
    }
    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UlController.instance.UpdateHealthDisplay();
    }

    
  
 
}
