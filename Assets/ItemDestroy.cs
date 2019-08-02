using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy: MonoBehaviour { 
    //課題用スクリプト
    
    //ItemDestroyを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //UnityちゃんとItemDestroyの距離
    private float difference;



    // Use this for initialization
    void Start(){
        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //UnityちゃんとItemDestroyの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update(){
        //Unityちゃんの位置に合わせてItemDestroyの位置を移動
        this.transform.position = new Vector3(0, 0, this.unitychan.transform.position.z - difference);
    }


    
    //トリガーモードでアイテムと障害物に接触した場合の処理
    void OnTriggerEnter(Collider other){
        //コインに衝突した場合
        if (other.gameObject.tag == "CoinTag")
        {
            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }
        //車に衝突した場合
        if (other.gameObject.tag == "CarTag")
        {
            //接触した車のオブジェクトを破棄
            Destroy(other.gameObject);
        }
        //コーンに衝突した場合
        if (other.gameObject.tag == "TrafficConeTag")
        {
            //接触したコーンのオブジェクトを破棄
            Destroy(other.gameObject);
        }
    }
}
