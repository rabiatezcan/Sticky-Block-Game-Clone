using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Material collectedObjMat; 
    public List<GameObject> collidedList; 

    // Objelerin hareket kontrolleri
    public GameObject collectedPool;
    float movementSpeed;
    float controlSpeed;
    bool isTouching;
    float touchPosX;



    //Objelerin durumu
    public PlayerState playerState;
    public LevelState levelState;
    public enum PlayerState
    {
        Stop, Move
    }
    public enum LevelState
    {
        Continue, Finished
    }

    private void Start()
    {
        collectedPool = GameObject.FindGameObjectWithTag("CollectedPool");
        movementSpeed = 3;
        controlSpeed = 5;
    }
    private void Update()
    {
        GetMouseInput();
    }

    private void FixedUpdate()
    {
        if(playerState == PlayerState.Move)
        {
            collectedPool.transform.position += Vector3.back * movementSpeed * Time.fixedDeltaTime;
        }
        if (isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed * Time.fixedDeltaTime;
        }

        collectedPool.transform.position = new Vector3(-touchPosX, collectedPool.transform.position.y, collectedPool.transform.position.z);
    }

    void GetMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }
    
    public void CallMakeSphere()
    {
        foreach(GameObject obj in collidedList)
        {
            obj.GetComponent<CollectedObjController>().MakeSphere();
        }
    }


}
