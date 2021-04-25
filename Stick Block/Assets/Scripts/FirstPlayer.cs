using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FirstPlayer : MonoBehaviour
{
    PlayerManager playerManager;
    Rigidbody rigidbody;
    public Canvas canvas; 
    bool isGrounded;
    
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>(); 
        rigidbody = GetComponent<Rigidbody>();
        GetComponent<Renderer>().material = playerManager.collectedObjMat;
        playerManager.collidedList.Add(gameObject);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { 
            Grounded();
        }
    }
    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        canvas.enabled = false;
        Destroy(this, 1);
    }


}
