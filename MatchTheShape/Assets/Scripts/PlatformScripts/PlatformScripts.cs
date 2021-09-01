using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScripts : MonoBehaviour
{
    [SerializeField] internal GameHandle gameHandle;

    BoxCollider2D boxCollider2D;
    Rigidbody2D rigidbody2D;

    [SerializeField] internal PlatformManage platformManage;

    [SerializeField] private float platformSpeed = 1;

    // Start is called before the first frame update
    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


}
