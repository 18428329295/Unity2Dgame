using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 2f;
    public float HP = 1;
    private int ForceDirection = 1;
   // public Sprite deadEnemy;

    private Rigidbody2D monster;

    void Awake()
    {
        monster = GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void Update () {
        monster.velocity = new Vector2(ForceDirection * moveSpeed, monster.velocity.y);
        if (HP <= 0)
        {
            Death();
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="Wall")
        {
            ForceDirection *= -1;
            Flip();
        }
        if (coll.gameObject.tag == "Destory")
        {
            Destroy(gameObject);
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
    void Death()
    {
        Debug.Log("123");
    }
    public void Blood()
    {
        HP--;
    }
}
