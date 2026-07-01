///---------------------------------
/// 画面タップで動かす
///---------------------------------
using UnityEngine;
using UnityEngine.InputSystem;

public class TapMove : MonoBehaviour
{
    // ジャンプ力
    [SerializeField] float jumpPower = 1.0f;

    // Rigidbody
    Rigidbody rb = null;
    // 今押されているか
    bool curPush = false;
    // 押されている時間
    [SerializeField] float pushTime = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Rigidbodyの取得
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // 現在のマウスの取得
        var mouse = Mouse.current;

        // 押されているか
        if(mouse.leftButton.isPressed)
        {
            // 押している時間を加算
            pushTime += Time.deltaTime;
            // 押されているので、フラグを立てる
            curPush = true;
        }

        // 今押されておらず、フラグが立っているなら飛ぶ
        else if(curPush == true)
        {
            // ジャンプ処理
            Jump();

            // 押している時間のリセット
            pushTime = 0.0f;
            // 押されていないので、フラグを折る
            curPush = false;
        }
    }

    // ジャンプ処理
    private void Jump()
    {
       // ジャンプ力の計算
       float power = pushTime * jumpPower;

        // 高く跳ねる山なり（上を強く）
        Vector3 dir = (Vector3.up * 2f + transform.forward).normalized;

        // // 遠くまで低く飛ぶ（前を強く）
        // Vector3 dir = (Vector3.up + transform.forward * 2f).normalized;
        
        rb.AddForce(dir * power, ForceMode.Impulse);
   }
}
