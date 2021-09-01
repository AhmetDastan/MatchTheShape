using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    private static GameHandle _instance;
    //public static GameHandle Instance { get { return _instance; } }

    [SerializeField] internal InputManager inputManager;
    [SerializeField] internal MainCamera mainCamera;
    [SerializeField] internal LocatableArea locatableArea;
    [SerializeField] internal UiManagment uiManagment;
    [SerializeField] internal PlayerScript playerScript;
    [SerializeField] internal PlatformScripts platformScripts;
    [SerializeField] internal SaveManager saveManager;
    [SerializeField] internal SoundManager soundManager;
    [SerializeField] internal AdManagerScript adManagerScript;

    [SerializeField] internal GameObject player;
    [SerializeField] internal float platformSpeed = 2;

    public bool isPlayerHasReward = false;
    internal bool isGamePaused = false;
    internal bool isPlayerDead = false;
    internal bool isGameOpeningFirstTime = false;
    internal float soundValue = 1;
    float tempSpeed;
    bool newGame = true;

    void Awake()
    {
        if (_instance == null )
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        isGameOpeningFirstTime = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameOpeningFirstTime = true;
        platformSpeed = 5;
        tempSpeed = platformSpeed;
        StartGame();
        soundManager.AdjustVolume("MainMusic", soundValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOpeningFirstTime)
        {
            isGameOpeningFirstTime = false;
            PauseGame();
            uiManagment.OpenGameMenuPanel();
        }
        if (isPlayerDead)
        {
            if (newGame)
            {
                uiManagment.OpenGameOverPanel();
                PauseGame();
                if (playerScript.bestScore < playerScript.score)
                {
                    saveManager.Save();
                }
                uiManagment.bestScore.ChangeBestScoreText();

                GameObject[] gObject = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
                int layerNum = LayerMask.NameToLayer("Module");
                foreach (GameObject go in gObject)
                {
                    if (go.layer == layerNum)
                    {
                        Destroy(go);
                    }
                }
                newGame = false;
            }
            if (ButtonScript.isRestartButtonPressed)
            {
                ButtonScript.isRestartButtonPressed = false;
                
                isPlayerDead = false;

                
                playerScript.score = 0;
                newGame = true;
                platformSpeed = 5;
                Restart();
            }
            else if (isPlayerHasReward)
            {
                Debug.Log("reward result");
                isPlayerHasReward = false;
                platformScripts.platformManage.isNeedNewModule = true;
                newGame = true;
                isPlayerDead = false;
                uiManagment.CloseGameOverPanel();
                platformSpeed = 5;
                playerScript.gameObject.SetActive(true);
            }
        }

    }


    public void StartGame()
    {
        saveManager.Load();
        uiManagment.ClosedGameMenuPanel();
        uiManagment.scoreScript.UpdateScoreText();
    }

    public void PauseGame()
    {
        isGamePaused = true;
        tempSpeed = platformSpeed;
        platformSpeed = 0;
        playerScript.playerMovement.playerMoveable = false;
        soundManager.AdjustVolume("MainMusic", (soundValue / 3));
    }
    public void ResumeGame()
    {
        isGamePaused = false;
        platformSpeed = tempSpeed;
        playerScript.playerMovement.playerMoveable = true;
        soundManager.AdjustVolume("MainMusic", soundValue);
    }
    public void Restart()
    {
        uiManagment.CloseGameOverPanel();

        saveManager.Load();

        playerScript.LocatePlayer();
        playerScript.gameObject.active = true;
        platformScripts.platformManage.isNeedNewModule = true;
        uiManagment.scoreScript.UpdateScoreText();
        platformSpeed = 5;
    }

}
