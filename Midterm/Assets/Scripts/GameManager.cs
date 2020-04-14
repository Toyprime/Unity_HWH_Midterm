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



    public IEnumerator MoveChest()
    {
        //前:forward
        //右:right
        //上:up
        //for 迴圈(初始值 條件 蝶帶器 - 每次回圈結束要執行的動作)
        for (int i = 0; i < 5; i++)
        {
            chest.position -= chest.forward * 0.1f;
            yield return new WaitForSeconds(0.01f);

        }
        chest.GetComponent<MeshCollider>().enabled = false;
    }

    //事件:開始 - 撥放時執行一次，初始化或遊戲一開始需要的內容
    private void Start()
    {
        //LightEffect();                    //呼叫自定義方法:一般呼叫
        StartCoroutine(LightEffect());      //呼叫協程方式

    }
}
