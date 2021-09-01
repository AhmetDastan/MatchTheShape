using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManage : MonoBehaviour
{
    Vector2 cameraBoundPos;

    [SerializeField] internal PlatformScripts platformScripts;
    [SerializeField] internal GameObject[] barrierPrefabs;

    internal bool isNeedNewModule = false;
    internal float nextLineSec = 2;
    int playersTagID = 0;


    private void Start()
    {
        isNeedNewModule = true;
        cameraBoundPos = new Vector2(0, platformScripts.gameHandle.mainCamera.MainCameraResolution.mainCamScreenBounds.y +5);
    }


    // Update is called once per frame
    void Update()
    {
        ManageModulePrefabs(); 
    }


    void ManageModulePrefabs()
    {
        if (isNeedNewModule && !platformScripts.gameHandle.isGamePaused)
        {
            Debug.Log("manage odule");
            isNeedNewModule = false;
            platformScripts.gameHandle.locatableArea.ResetEnalableSituation();

            CreateModule();
        }

    }

    void CreateModule()
    {
        int emptyCell = platformScripts.gameHandle.locatableArea.FindRandomEmptyCell();

        playersTagID = FindPrefabBarrierWithTag(platformScripts.gameHandle.playerScript.playerTag);

        cameraBoundPos.x = platformScripts.gameHandle.locatableArea.locatableCell[emptyCell];

        Instantiate(barrierPrefabs[playersTagID], cameraBoundPos, Quaternion.identity);

        for (int i = 0; i < 2; i++)
        {
            PutBarrier();
        }
    }

    void PutBarrier()
    {
        int emptyCell = platformScripts.gameHandle.locatableArea.FindRandomEmptyCell();

        if (emptyCell == -1)
        {
            Debug.Log("There is no space ");
        }
        else
        {
            int whichBarrier = Random.Range(0, barrierPrefabs.Length);
            if (whichBarrier == playersTagID)
            {
                if(playersTagID != 0) whichBarrier--;
                else if(playersTagID == 0) whichBarrier++;
            }
            cameraBoundPos.x = platformScripts.gameHandle.locatableArea.locatableCell[emptyCell];

            Instantiate(barrierPrefabs[whichBarrier], cameraBoundPos, Quaternion.identity);
        } 
    }

    public int FindPrefabBarrierWithTag(string tag)
    {
        for (int i = 0; i < barrierPrefabs.Length; i++)
        {
            if (barrierPrefabs[i].tag == tag)
            {
                return i;
            }
        }
        Debug.Log(" That tag was not find " + tag);
        return 0;
    }
}
