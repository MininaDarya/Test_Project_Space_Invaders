using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>() && !collision.gameObject.GetComponent<Gun_Behaviour>()) {
            Destroy(this.gameObject);
        }
    }
}
