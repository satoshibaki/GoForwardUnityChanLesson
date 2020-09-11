using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    private AudioSource audioSource;

    public AudioClip Block;

    // Start is called before the first frame update
    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0,0);



        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnCollisionEnter2D(Collision2D other)
    {

        //地面及びキューブに衝突した場合、音出す
        if (other.gameObject.tag == "CubePrefab" || other.gameObject.tag == "ground")
        {
            audioSource.PlayOneShot(Block);
            GetComponent<AudioSource>().volume =1;
        }

        //ユニティちゃんに衝突した場合、音出さない
        if (other.gameObject.tag == "UnityChan2D")
        {
            GetComponent<AudioSource>().volume = 0;
        }

    }
}
