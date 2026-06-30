using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserMoves : MonoBehaviour
{
    // 移動速度
    [SerializeField] private float moveSpeed = 0.1f;
    // ジャンプの高さ
    [SerializeField] private float jumpHight = 0.1f;

    // 動かすオブジェクト
    [SerializeField] private GameObject gameobje = null;

    void Awake()
    {
        //自身の取得
        gameobje = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 現在のキーボード情報の取得
        var kb = Keyboard.current;

        // 現在地の取得兼変数宣言
        Vector3 curPos = Vector3.zero;

        // 右移動
        if (kb.dKey.isPressed) { curPos.x += moveSpeed; }

        // 左移動
        if (kb.aKey.isPressed) { curPos.x -= moveSpeed; }

        // 奥移動
        if (kb.wKey.isPressed) { curPos.y += moveSpeed; }

        // 手前移動
        if (kb.sKey.isPressed) { curPos.y -= moveSpeed; }

        // ジャンプ
        if (kb.spaceKey.isPressed) { curPos.z += jumpHight; }

        // 正規化
        Vector3 dir = new Vector3(curPos.x, curPos.z, curPos.y).normalized;

        // 移動の適応
        transform.position += dir * Time.deltaTime;
    }
}
