using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private Collider collid;
    private float rangeSqr;
    private bool isDead;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        collid = gameObject.GetComponent<Collider>();
        rangeSqr = 5;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.Find("Player").transform;
        float distanceSqr = (transform.position - player.position).sqrMagnitude;
        if (distanceSqr < rangeSqr && !isDead){
            anim.SetBool("isAttacking", true);
        }else{
            anim.SetBool("isAttacking", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Sword"){
             anim.SetTrigger("onDeath");
             isDead = true;
        }
    }
}
