using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;       //引用 系統.集合 API:延遲 - 微軟 API

public class GameManager : MonoBehaviour
{
    [Header("燈光群組")]
    public GameObject groupLight;
    [Header("會動的桶子")]
    public Transform chest;
    [Header("會動的椅子")]
    public Transform chair;
    [Header("會動的箱子")]
    public Transform box;
    [Header("會動的鐵籠")]
    public Transform cage;
    [Header("喇叭")]
    public AudioSource aud;
    [Header("桶子移動音效")]
    public AudioClip soundWoodMove;
    [Header("箱子移動音效")]
    public AudioClip soundBoxMove;
    [Header("椅子移動音效")]
    public AudioClip soundChairMove;
    [Header("鐵籠音效")]
    public AudioClip soundCageMove;
    [Header("敲門音效")]
    public AudioClip soundKnock;
    [Header("開門音效")]
    public AudioClip soundOpen;
    [Header("門動畫控制器")]
    public Animator aniDoor;

    private int countDoor;  //看到門的次數

    private int countChest; //看到桶子的次數


    public void LookDoor()
    {
        countDoor++;        //遞增1

        if (countDoor == 1)
        {
            aud.PlayOneShot(soundKnock, 2.5f);
        }
        else if (countDoor == 2)
        {
            aud.PlayOneShot(soundOpen, 2.5f);
            aniDoor.SetTrigger("開門觸發器");
        }
    }

    //燈光閃爍效果
    public IEnumerator LightEffect()
    {
        groupLight.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        groupLight.SetActive(true);
    }


    //開始移動桶子
    public void StarMoveChest()
    {
        StartCoroutine(MoveChest());
    }
    //移動桶子
    public IEnumerator MoveChest()
    {
        //GetComponen<泛型>() 取得元件:可以取得物件在屬性面板的所有元件
        //enable 元件啟動或停止:true 啟動.false 停止
        chest.GetComponent<MeshCollider>().enabled = false;

        //喇叭.播放一次音效(音效.音量)
        aud.PlayOneShot(soundWoodMove, 2.5f);

        //前:forward
        //右:right
        //上:up
        //for 迴圈(初始值 條件 蝶帶器 - 每次回圈結束要執行的動作)
        for (int i = 0; i < 5; i++)
        {
            chest.position -= chest.forward * 0.1f;
            yield return new WaitForSeconds(0.01f);

        }

    }


    //開始移動椅子
    public void StarMoveChair()
    {
        StartCoroutine(MoveChair());
    }
    //移動椅子
    public IEnumerator MoveChair()
    {
        chair.GetComponent<MeshCollider>().enabled = false;

        aud.PlayOneShot(soundChairMove, 2.5f);

        for (int i = 0; i < 5; i++)
        {
            chair.position -= chair.forward * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }


    //開始移動箱子
    public void StarMoveBox()
    {
        StartCoroutine(MoveBox());
    }
    //移動箱子
    public IEnumerator MoveBox()
    {
        box.GetComponent<MeshCollider>().enabled = false;

        aud.PlayOneShot(soundBoxMove, 2.5f);

        for (int i = 0; i < 10; i++)
        {
            box.position += box.right * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }


    //開始移動鐵籠
    public void StarMoveCage()
    {
        StartCoroutine(MoveCage());
    }
    //移動鐵籠
    public IEnumerator MoveCage()
    {
        cage.GetComponent<MeshCollider>().enabled = false;

        aud.PlayOneShot(soundCageMove, 2.5f);

        for (int i = 0; i < 25; i++)
        {
            cage.position -= cage.up * 0.1f;
            yield return new WaitForSeconds(0.01f);
        }
    }


    //事件:開始 - 撥放時執行一次，初始化或遊戲一開始需要的內容
    private void Start()
    {
        //LightEffect();                    //呼叫自定義方法:一般呼叫
        StartCoroutine(LightEffect());      //呼叫協程方式

    }
}
