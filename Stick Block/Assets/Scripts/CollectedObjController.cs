using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjController : MonoBehaviour
{
    PlayerManager playerManager;
    GameObject collectibleObj;
    Transform sphere;
    void Start()
    {
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        sphere = transform.GetChild(0); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("CollectibleObj"))
        {
            if (!playerManager.collidedList.Contains(other.gameObject))
            {
                other.gameObject.tag = "CollectedObj";
                other.transform.parent = playerManager.collectedPool.transform;
                playerManager.collidedList.Add(other.gameObject);
                other.gameObject.GetComponent<Renderer>().material = playerManager.collectedObjMat;
                other.gameObject.AddComponent<CollectedObjController>();
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            playerManager.collidedList.Remove(gameObject);
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLine"))
        {
            if(playerManager.levelState == PlayerManager.LevelState.Continue)
            {
                playerManager.levelState = PlayerManager.LevelState.Finished;
                playerManager.CallMakeSphere();
            }
        }
        else if (other.gameObject.CompareTag("FinishHole"))
        {
            DropObj();
        }
    }
    public void MakeSphere()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        sphere.gameObject.GetComponent<SphereCollider>().enabled = true;
        sphere.gameObject.GetComponent<MeshRenderer>().enabled = true;
        sphere.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        sphere.gameObject.GetComponent<Renderer>().material = playerManager.collectedObjMat;
    }
    public void DropObj()
    {
        sphere.gameObject.layer = 6;
        sphere.gameObject.GetComponent<SphereCollider>().isTrigger = false;
        sphere.gameObject.AddComponent<Rigidbody>();
        sphere.GetComponent<Rigidbody>().useGravity = true; 
    
    }
}
