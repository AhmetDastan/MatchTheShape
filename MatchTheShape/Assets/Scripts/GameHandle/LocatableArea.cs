using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocatableArea : MonoBehaviour
{
    [SerializeField] internal GameHandle gameHandle;

    internal float[] locatableCell = new float[3];
    internal bool[] isEnableCells = new bool[3];
    internal bool areCellsAvailable = true;
    // Start is called before the first frame update
    void Awake()
    {
        defineLocatableCell();
    }


    void defineLocatableCell()
    {
        locatableCell[0] = -gameHandle.mainCamera.MainCameraResolution.mainCamScreenBounds.x / 2f;
        locatableCell[1] = 0;
        locatableCell[2] = gameHandle.mainCamera.MainCameraResolution.mainCamScreenBounds.x / 2f;

        isEnableCells[0] = true;
        isEnableCells[1] = true;
        isEnableCells[2] = true;
    }

    public void ResetEnalableSituation()
    {
        isEnableCells[0] = true;
        isEnableCells[1] = true;
        isEnableCells[2] = true;

        areCellsAvailable = true;
    }

    public void ChangeToFalseEnalableSituation(int t)
    {
        isEnableCells[t] = false;
        int temp = 0;
        foreach(bool b in isEnableCells)
        {
            if(b == false)
            {
                temp++;
            }
            else if (b == true) break;
        }
        if(temp == isEnableCells.Length)
        {
            areCellsAvailable = false;
        }
    }

    public int FindRandomEmptyCell()
    {
        int temp = 0;
        if (areCellsAvailable)
        {
            temp = Random.Range(0, 3);
            if (isEnableCells[temp])
            {
                isEnableCells[temp] = false;
                return temp;
            }
            else if (temp == 0)
            {
                if (isEnableCells[2])
                {
                    isEnableCells[2] = false;
                    return 2;
                }
                else if (isEnableCells[1])
                {
                    isEnableCells[1] = false;
                    return 1;
                }
            }
            else if (temp == 2)
            {
                if (isEnableCells[0])
                {
                    isEnableCells[0] = false;
                    return 0;
                }
                else if (isEnableCells[1])
                {
                    isEnableCells[1] = false;
                    return 1;
                }
            }
            else if (temp == 1)
            {
                if (isEnableCells[0])
                {
                    isEnableCells[0] = false;
                    return 0;
                }
                else if (isEnableCells[2])
                {
                    isEnableCells[2] = false;
                    return 2;
                }
            }
        }else 
        {
            Debug.Log("bos deger yok");
            return -1;
        }
         return -1;
    }
}
