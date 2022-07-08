using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public delegate void ShootBall();
    public static event ShootBall ShootEvent;
    [SerializeField] private Button button;
    

    void Start()
    {
        button.gameObject.SetActive(true);        
        
    }

    public void OnClick()
    {
        ShootEvent();
        button.gameObject.SetActive(false);
    }
}
