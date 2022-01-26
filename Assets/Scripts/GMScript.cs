using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GMScript : MonoBehaviour
{
    public static float time_damage = 0f;
    private float timea = 0f;
    [SerializeField]
    private GameObject[] STAR;
    [SerializeField]
    private GameObject[] DISASTAR;
    [SerializeField]
    private GameObject items_par;

    [SerializeField]
    private Image[] life_image_data;
    public static Image[] life_image=new Image[5];

    [SerializeField]
    private Slider timelimit_slider;

    [SerializeField]
    private Text score_text;

    //ゲームのデータ
    public static int score = 0;
    public static int life = 5;

    [SerializeField]
    private AudioSource audioSource;
    public static AudioSource audioSource_use;
    [SerializeField]
    private AudioClip ac_get;
    public static AudioClip ac_get_use;
    [SerializeField]
    private AudioClip ac_dmg;
    public static AudioClip ac_dmg_use;

    void Start()
    {
        ac_get_use = ac_get;
        ac_dmg_use = ac_dmg;
        audioSource_use = audioSource;
        for (int i = 0; i < 5; i++)
        {
            life_image[i] = life_image_data[i];
        }
        for (int i = 0; i < 60; i++)
        {
            GenerateItems(true).GetComponent<Rotator>().time = i;
            GenerateItems(false).GetComponent<Rotator>().time = i;
        }
    }

    private void FixedUpdate()
    {
        time_damage += Time.deltaTime;
        timea += Time.deltaTime;

        float td = 15.0f;
        float t1 = 1.0f;

        if (timea > t1)
        {
            GenerateItems(true);
            GenerateItems(false);
            timea -= t1;
        }
        if (time_damage > td)
        {
            HurtDamage();
        }
        timelimit_slider.value = time_damage;
        score_text.text = score + " Point";
    }

    private GameObject GenerateItems(bool good)
    {
        Vector3 pos = GetPlacaablePos();
        GameObject obj;
        if (good)
        {
            obj = (GameObject)Instantiate(STAR[Random.Range(0, STAR.Length)],
            pos, Quaternion.Euler(-90, 0, 0), items_par.transform);
        }
        else
        {
            obj = (GameObject)Instantiate(DISASTAR[Random.Range(0, DISASTAR.Length)],
               pos, Quaternion.Euler(-90, 0, 0), items_par.transform);
        }
        obj.layer = Random.Range(8, 11 + 1);
        return obj;
    }

    private Vector3 GetPlacaablePos()
    {
        float r = 150.0f;
        Vector3 pos;
        int cnt = 0;
        do
        {
            pos = new Vector3(Random.Range(-r, r), Random.Range(1.0f, 10.0f), Random.Range(-r, r));
        } while (!(Physics.CheckCapsule(new Vector3(pos.x, pos.y - 1, pos.z), new Vector3(pos.x, pos.y - 2, pos.z), 1) &&
        !Physics.CheckSphere(pos, 1.0f)) && cnt++ < 50);
        return pos;
    }

    public static void GetItem()
    {
        score++;
        time_damage = 0f;
        audioSource_use.PlayOneShot(ac_get_use);
    }
    public static void HurtDamage()
    {
        life--;
        life_image[life].gameObject.SetActive(false);
        time_damage = 0f;
        audioSource_use.PlayOneShot(ac_dmg_use);
        if(life<=0)
        {
            SceneManager.LoadScene("End");
        }
    }
}
