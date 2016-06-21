using UnityEngine;
using System.Collections;


public class CamFollow : MonoBehaviour {

    public float DistanceX = 5f;
    public float DistanceY = 5f;
    public float SmoothX = 5f;
    public float SmoothY = 5f;

    public Vector2 MaxCamXandY;
    public Vector2 MinCamXandY;

    private Transform player;

    void Awake()
    {
      //  player = GameObject.Find("Hero").transform;
         player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	// Use this for initialization
	void Start () {
	
	}
	

    void Update () {
        FollowPlayer();
	}

    void FollowPlayer()
    {
        float CamNewX = transform.position.x;
        float CamNewY = transform.position.y;
        //计算新摄像机位置
        if (MoveX())
            CamNewX = Mathf.Lerp(transform.position.x, player.position.x, SmoothX * Time.deltaTime);
        if (MoveY())
            CamNewY = Mathf.Lerp(transform.position.y, player.position.y, SmoothY * Time.deltaTime);
        //将新摄像机位置固定在合法范围内
        CamNewX = Mathf.Clamp(CamNewX, MinCamXandY.x, MaxCamXandY.x);
        CamNewY = Mathf.Clamp(CamNewY, MinCamXandY.y, MaxCamXandY.y);
        transform.position = new Vector3(CamNewX, CamNewY, transform.position.z);
    }

    bool MoveX()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > DistanceX;
    }

    bool MoveY()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > DistanceY;
    }


}
