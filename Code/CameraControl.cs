using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    //[SerializeField]
    //private float timeoffset;
    //[SerializeField]
    //private Vector2 posoffset;
    //private Vector3 velocity;
    public float posX = 3;
    public float posY = 1;


    void Update()
    {
        // cam start postion
        //Vector3 starspos= transform.position;
        //// cam end postion
        //Vector3 endpos = player.transform.position;
        //endpos.x += posoffset.x;
        //endpos.y += posoffset.y;
        //endpos.z = -10;


        transform.position = new Vector3(player.transform.position.x+posX,player.transform.position.y+posY,-10);
        //transform.position = Vector3.SmoothDamp(starspos,endpos, ref velocity, timeoffset);

    }
}
