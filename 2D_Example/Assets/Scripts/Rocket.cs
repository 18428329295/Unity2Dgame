using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

    public GameObject explosion;

    void OnExplode()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
        Instantiate(explosion, transform.position, rotation);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall" || col.gameObject.tag == "Fore")
        {
            OnExplode();
            Destroy(gameObject);
        } 
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy>().Blood();
            OnExplode();
            Destroy(gameObject);
        }
        
    }
}
