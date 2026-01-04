using System.Numerics;
using UnityEngine;

public class Hole : MonoBehaviour
{

    // どのボールを吸い寄せるかタグで指定
    public string targetTag;

    // ボールが入っているか
    bool isHolding;

    public bool IsHolding()
    {
        return isHolding;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            isHolding = false;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRigidbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // もしRigidbodyがついていないオブジェクトなら、何もしないで中断
        if (r == null)
        {
            return;
        }

        // ボールがどの方向にあるかを計算
        UnityEngine.Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();
        

        // タグに応じてボールに力を加える
        if (other.gameObject.tag == targetTag)
        {
            // 中心地点でボールを止めるために速度を減速させる
            r.linearVelocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
}
