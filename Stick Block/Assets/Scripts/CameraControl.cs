using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 cameraPos;
    private Transform collectedPool;
    private Vector3 cameraOffset = new Vector3(0,0, 5.21f);
    PlayerManager playerManager;
    float smoothSpeed = 0.125f; 
    private void Awake()
    {
        collectedPool = GameObject.FindGameObjectWithTag("CollectedPool").transform;
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();

    }
    void LateUpdate()
    {
        if(playerManager.levelState == PlayerManager.LevelState.Continue)
        {
            cameraPos = collectedPool.position + cameraOffset;
            Vector3 smoothedSpeed = Vector3.Lerp(transform.position, cameraPos, smoothSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, smoothedSpeed.z);
        }
           
    }
}
