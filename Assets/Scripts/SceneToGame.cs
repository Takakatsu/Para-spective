using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToGame : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public static AudioSource audioSource_use;
    [SerializeField]
    private AudioClip ac_act;
    public static AudioClip ac_act_use;
    private void Start()
    {
        audioSource_use = audioSource;
        ac_act_use = ac_act;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void ChangeScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        audioSource_use.PlayOneShot(ac_act_use);
        Invoke("chsc", 1);
    }

    public void chsc()
    {
        SceneManager.LoadScene("MyStage");
    }
}
