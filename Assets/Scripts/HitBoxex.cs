using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxex : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Destroy(collision.gameObject);
            GMScript.GetItem();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            GMScript.HurtDamage();
        }
        else
        {
        }
    }
}
