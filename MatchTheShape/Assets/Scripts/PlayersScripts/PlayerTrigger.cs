using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] PlayerScript playerScript;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != playerScript.playerTag)
        {
            gameObject.active = false;
            playerScript.gameHandle.isPlayerDead = true;
            playerScript.gameHandle.soundManager.Play("PlayerDeath");
        }
        else if(collision.tag == playerScript.playerTag)
        {
            playerScript.score += 1;
            playerScript.gameHandle.uiManagment.scoreScript.UpdateScoreText();
            playerScript.gameHandle.soundManager.Play("CorrectLine");


            playerScript.gameHandle.platformScripts.platformManage.isNeedNewModule = true;

            DefineBarrierSpeed();
        }
    }

    void DefineBarrierSpeed()
    {
        if (playerScript.score < 50)
        {
            playerScript.gameHandle.platformSpeed *= 1.01f;
        }
        else if (playerScript.score > 100 && playerScript.score < 200)
        {
            playerScript.gameHandle.platformSpeed *= 1.015f;
        }
        else if (playerScript.score > 200 && playerScript.score < 300)
        {
            playerScript.gameHandle.platformSpeed *= 1.019f;
        }
    }
}
