using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    [SerializeField]
    private Text scoretext;
    void Start()
    {
        scoretext.text = GMScript.score.ToString();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Title");
        }
    }
}
