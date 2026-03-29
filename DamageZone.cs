using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int DamageAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController p = collision.GetComponent<PlayerController>();
            if (p != null)
            {
                p.ReceiveDamage(DamageAmount);
            }
        }
    }
}
