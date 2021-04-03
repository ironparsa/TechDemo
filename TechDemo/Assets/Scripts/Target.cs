using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }


    void Die()
    {
        //checks if the object killed is a "target" type or a "powerup".
        Debug.Log(gameObject.name);
        if(gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
        if(gameObject.tag == "PowerUp") 
        {
            Debug.Log(gameObject.name);
            Debug.Log(gameObject.tag);
            PowerUp.PowerUpSelector(gameObject);
        }
    }
}
