using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button button;

    void Start()
    {
        button.gameObject.SetActive(false);
        GameField.gameOverEvent += GameOver;
    }

    void GameOver()
    {
        var MassBlock = FindObjectsOfType<Block>();
        foreach(var m in MassBlock)
        {
            Destroy(m.gameObject);
        }
        

        text.transform.position = new Vector3(300, 200, -1);
        text.fontSize = 140;

        button.gameObject.SetActive(true);
    }

    public void RestartGameMethod()
    {       
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        GameField.gameOverEvent -= GameOver;
    }
}
