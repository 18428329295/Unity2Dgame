using UnityEngine;
using System.Collections;

public class MonsterTurnUp : MonoBehaviour {

    public float monTime = 5f;
    public float monDelay = 3f;
    public GameObject[] monster;


	// Use this for initialization
	void Start () {
        InvokeRepeating("Monster", monTime, monDelay);
	}
	
	// Update is called once per frame
	void Monster () {

        int monIndex = Random.Range(0, monster.Length);
        Instantiate(monster[monIndex], transform.position, transform.rotation);


	}
}
