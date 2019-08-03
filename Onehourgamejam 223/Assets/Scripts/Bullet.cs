using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Fuck");
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().GameOver();
        }
        Die();
    }

    void Die()
    {
        Destroy(this);
    }
}
