using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // === Public Variables === //
    [Header("=== マネージャー設定.")]
    public int FrameRate = 30;          // ゲームのフレームレート設定
    public GameManager GameManager;     // ゲーム管理クラスの参照

    [Header("=== 挙動設定.")]
    public float MoveSpeed = 5f;        // 基本移動速度の設定

    [Header("=== 画面外設定.")]
    public Vector2 OutScreenPoint = new Vector2(15, 5);    // 画面外のサイズ設定

    void Start()
    {
        Application.targetFrameRate = FrameRate;            // ゲームのフレームレートを設定
    }


    void Update()
    {
        OutScreen();    // 画面外処理を実行
        Movement();     // 移動処理を実行
    }


    /// <summary>
    /// 移動処理
    /// </summary>
    public void Movement()
    {
        // 移動速度を フレーム単位 から 時間単位 に変換
        float deltaSpeed = MoveSpeed * Time.deltaTime;

        if(Keyboard.current.wKey.isPressed)
        {   
            // x軸:0, y軸:deltaSpeed, z軸:0 で移動させる
            transform.Translate(0, deltaSpeed, 0);
        }
        if(Keyboard.current.aKey.isPressed)
        {
            // x軸:-deltaSpeed, y軸:0, z軸:0 で移動させる
            transform.Translate(-deltaSpeed, 0, 0);
        }
        if(Keyboard.current.dKey.isPressed)
        {
            // x軸:deltaSpeed, y軸:0, z軸:0 で移動させる
            transform.Translate(deltaSpeed, 0, 0);
        }
        if(Keyboard.current.sKey.isPressed)
        {
            // x軸:0, y軸:-deltaSpeed, z軸:0 で移動させる
            transform.Translate(0, -deltaSpeed, 0);
        }
    }


    /// <summary>
    /// 画面外処理
    /// </summary>
    public void OutScreen()
    {
        // 現在の座標を取得
        Vector3 position = transform.position;

        // Y座標が [-5] より小さいなら...
        if (position.y <= -OutScreenPoint.y)
        {
            // 移動速度の分だけ、少し上に移動させる
            position.y += MoveSpeed * Time.deltaTime;
        }

        // Y座標が[5] よりも大きいなら...
        if (position.y >= OutScreenPoint.y)
        {
            // 移動速度の分だけ、少し下に移動させる
            position.y -= MoveSpeed * Time.deltaTime;
        }

        // 座標を更新する
        transform.position = position;
    }


    /// <summary>
    /// 死亡処理
    /// </summary>
    public void Dead()
    {
        if (GameManager == null)
        {
            Debug.LogError("インスペクターで GameManager を設定してください。");
            return;     // 強制終了
        }

        GameManager.GameOver();     // ゲームオーバーにする
    }


    void OnCollisionEnter2D(Collision2D hitObject)
    {
        // === 衝突したオブジェクトのタグが「Enemy」なら...
        if(hitObject.transform.tag == "Enemy")
        {
            Dead();
        }
    }
}
