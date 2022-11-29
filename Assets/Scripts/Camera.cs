using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Camera : MonoBehaviour
{
    internal static object main;
    public Transform target;
    public Transform backGround, middleBackGround;
    public float minHeigh, maxHeigh;

    //private float lastXPos;
    private Vector2 lastPos;
    void Start()
    {
        //lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);

        float clampedY = Mathf.Clamp(target.position.y, minHeigh, maxHeigh);
        transform.position = new Vector3(transform.position.x,clampedY,transform.position.z);*/

        transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y,minHeigh,maxHeigh),transform.position.z);
        
        //float amountToMoveX = transform.position.x - lastXPos; 
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x,transform.position.y - lastPos.y);

        backGround.position = backGround.position + new Vector3(amountToMove.x, amountToMove.y,0f);
        middleBackGround.position += new Vector3(amountToMove.x,amountToMove.y , 0)* .5f;
        lastPos = transform.position;
    }
}
