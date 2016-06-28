using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public Rigidbody2D rocket;
    public float speed = 20f;

    private Playcontrol playctrl;
    private Animator anim;

    void Awake()
    {
        anim =transform.root.gameObject.GetComponent<Animator>();
        playctrl=transform.root.GetComponent<Playcontrol>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
             GetComponent<AudioSource>().Play();
             anim.SetTrigger("shoot");
            if(playctrl.heroFaceRight)
            {
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
	
	}
}
