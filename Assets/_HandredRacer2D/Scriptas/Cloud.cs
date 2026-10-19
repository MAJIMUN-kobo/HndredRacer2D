using UnityEngine;

public class Cloud : MonoBehaviour
{
    // === Pulbic Valiables === //
    [Header("=== 挙動設定.")]
    public float MoveSpeed = 5f;        // 基本移動速度

    [Header("=== 画面外設定.")]
    public Vector2 OutScreenPoint = new Vector2(15, 10);    // 画面外のサイズ設定


    void Start()
    {
        
    }

    void Update()
    {
        Movement();     // 移動処理の実行
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
        Vector3 position = transform.position;

        // Y座標が [-10] より小さい または Y座標が [10] よりも大きいなら...
        if (position.y <= -OutScreenPoint.y || position.y >= OutScreenPoint.y)
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
    }
}
