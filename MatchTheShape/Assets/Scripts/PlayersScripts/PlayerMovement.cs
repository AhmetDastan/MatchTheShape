using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerScript playerScript;

    internal bool playerMoveable = true;


    private void FixedUpdate()
    {
        if(playerMoveable)
            PlayerMove();
    }


    void PlayerMove()
    {
        if (playerScript.gameHandle.inputManager.isLeftSliding )
        {
            if (gameObject.transform.position.x > 0)
            {
                gameObject.transform.position = new Vector3(playerScript.gameHandle.locatableArea.locatableCell[1], -3, gameObject.transform.position.z);
            }
            else if (gameObject.transform.position.x > -0.5f) 
            {
                gameObject.transform.position = new Vector3(playerScript.gameHandle.locatableArea.locatableCell[0], -3, gameObject.transform.position.z);
            }
            
            playerScript.gameHandle.inputManager.isLeftSliding = false;

        }

        if (playerScript.gameHandle.inputManager.isRightSliding)
        {
            if (gameObject.transform.position.x < 0)
            {
                gameObject.transform.position = new Vector3(playerScript.gameHandle.locatableArea.locatableCell[1], -3, gameObject.transform.position.z);
            }
            else if (gameObject.transform.position.x < 0.5f)
            {
                gameObject.transform.position = new Vector3(playerScript.gameHandle.locatableArea.locatableCell[2], -3, gameObject.transform.position.z);
            }
            
            playerScript.gameHandle.inputManager.isRightSliding = false;
        }
    }
}
