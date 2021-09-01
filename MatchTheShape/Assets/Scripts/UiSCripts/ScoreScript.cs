using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] internal UiManagment uiManagment;
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScoreText()
    {
        if (uiManagment.gameHandle.playerScript.bestScore > uiManagment.gameHandle.playerScript.score)
        {
            textMeshPro.text = uiManagment.gameHandle.playerScript.score.ToString() + " / " + uiManagment.gameHandle.playerScript.bestScore.ToString();
        }else textMeshPro.text = uiManagment.gameHandle.playerScript.score.ToString();
    }

}
