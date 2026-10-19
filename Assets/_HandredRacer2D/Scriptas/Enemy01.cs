using JetBrains.Annotations;
using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    // === Plublic Valiables === //
    [Header("=== マネージャー設定.")]
    public ScoreManager ScoreManager;       // スコア管理クラスの参照（※Start で自動取得します）

    [Header("=== 挙動設定.")]
    public float MoveSpeed = 5f;            // 基本移動速度

    [Header("=== 画面外設定.")]
    public Vector2 OutScreenPoint = new Vector2(15, 10);    // 画面外のサイズ設定


    void Start()
    {
        // === スコア管理クラスの参照を自動設定
        ScoreManager = GameObject.FindAnyObjectByType<ScoreManager>();
        if(ScoreManager == null)
        {
            Debug.LogError("ScoreManager がシーンに存在しません。");
        }
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

        // -Y軸方向にdeltaSpeedの速さでまっすぐ移動
        transform.Translate(0, -deltaSpeed, 0);
    }


    /// <summary>
    /// 画面外処理
    /// </summary>
    public void OutScreen()
    {
        // 現在の座標を取得
        Vector3 position = transform.position;

        // Y座標が [-10] より小さい または Y座標が [10] よりも大きいなら...
        if(position.y <= -OutScreenPoint.y || position.y >= OutScreenPoint.y)
        {
            Dead();     // 死亡処理を実行
        }
    }
    

    /// <summary>
    /// 死亡処理
    /// </summary>
    public void Dead()
    {
        Destroy(gameObject);    // オブジェクト本体を削除する

        // === 順位をあげる
        if (ScoreManager == null)
        {
            Debug.LogError("ScoreManager が設定されていません。");
        }

        // 順位を 1 上げる
        ScoreManager.AddRacePlace(1);
    }
}
