using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlBird : Bird
{
    [SerializeField]
    public float power = 50f;
    public float radius = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Obstacle")
        {
            SetState(BirdState.HitSomething);
            Explode();
        }
    }

    private void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D benda in objects){
            if (benda.GetComponent<Rigidbody2D>()== null)
            {
                continue;
            }
            else
            {
                Vector2 direction = benda.transform.position - transform.position;
                benda.GetComponent<Rigidbody2D>().AddForce(direction * power);
            }
        }
    }
}
