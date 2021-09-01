using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] internal UiManagment uiManagment;
    private TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    public void ChangeBestScoreText()
    {
        uiManagment.gameHandle.saveManager.Load();
        string t = "Bestt Score " + uiManagment.gameHandle.playerScript.bestScore.ToString();
        textMeshPro.text = t;

    /*if (uiManagment.gameHandle.playerScript.bestScore > uiManagment.gameHandle.playerScript.score)
        {
            string t = "Bestt Score " + uiManagment.gameHandle.playerScript.score.ToString();
            textMeshPro.text = t;
        }
        else
        {
            Debug.Log("bestscore" + uiManagment.gameHandle.playerScript.bestScore.ToString());
            string t = "Bestt Score " + uiManagment.gameHandle.playerScript.bestScore.ToString();
            textMeshPro.text = t;
        }*/

    }
}
