using System.Collections;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //UnityちゃんのZ座標
    private float unityPosZ;
    //アイテム生成位置
    private float itemPos;



    // Use this for initialization
    void Start () {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        
        /*
        //発展課題実施のため以下は非表示にした

        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetz = Random.Range(-5, 6);
                    //60%コイン配置：30%車配置：10%何もなし
                    if(1<=item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetz);
                    }else if(7<=item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetz);
                    }
                }
            }
        }
        */
    }

    // Update is called once per frame
    void Update(){
        //発展課題

        //Unityちゃんの現在地を呼び出す
        this.unityPosZ = unitychan.transform.position.z;

        //アイテム生成位置
        this.itemPos = this.unityPosZ + 45;

        //Unityちゃんがスタート位置手前45になったらアイテムを生成
        if (this.unityPosZ >= startPos - 45)
        {
            //アイテムの生成範囲を設定
            if (startPos <= this.itemPos && this.itemPos <= goalPos)
            {
                //スタート位置から15毎にアイテムを生成する位置がUnityちゃんと40～50離れた距離になっているか判定
                if (this.itemPos < (startPos += 15))
                {
                    //どのアイテムを出すのかをランダムに設定
                    int num = Random.Range(1, 11);
                    if (num <= 2)
                    {
                        //コーンをx軸方向に一直線に生成
                        for (float j = -1; j <= 1; j += 0.4f)
                        {
                            GameObject cone = Instantiate(conePrefab) as GameObject;
                            cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.itemPos);
                        }
                    }
                    else
                    {
                        //レーンごとにアイテムを生成
                        for (int j = -1; j <= 1; j++)
                        {
                            //アイテムの種類を決める
                            int item = Random.Range(1, 11);
                            //アイテムを置くz座標のオフセットをランダムに設定
                            int offsetz = Random.Range(-5, 6);
                            //60%コイン配置：30%車配置：10%何もなし
                            if (1 <= item && item <= 6)
                            {
                                //コインを生成
                                GameObject coin = Instantiate(coinPrefab) as GameObject;
                                coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.itemPos + offsetz);
                            }
                            else if (7 <= item && item <= 9)
                            {
                                //車を生成
                                GameObject car = Instantiate(carPrefab) as GameObject;
                                car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.itemPos + offsetz);
                            }
                        }
                    }
                }
            }
        }
    }
}
