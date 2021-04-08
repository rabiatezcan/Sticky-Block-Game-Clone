using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : MonoBehaviour
{
    PlayerManager playerManager;
    Rigidbody rigidbody;
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
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Grounded();
        }
    }

    void Grounded()
    {
        isGrounded = true;
        playerManager.playerState = PlayerManager.PlayerState.Move;
        rigidbody.useGravity = false;
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this, 1);
    }


}
