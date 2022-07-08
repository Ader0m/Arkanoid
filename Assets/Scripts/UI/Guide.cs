using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Guide : MonoBehaviour
{
    [SerializeField] private Image left;
    [SerializeField] private Image right;
    [SerializeField] private float showTime;


    void Start()
    {
        showTime = Time.time + showTime;
        left.gameObject.SetActive(true);
        right.gameObject.SetActive(true);
    }
   
    void Update()
    {
        if (Time.time > showTime)
        {
            left.gameObject.SetActive(false);
            right.gameObject.SetActive(false);          
        }      
    }
}
