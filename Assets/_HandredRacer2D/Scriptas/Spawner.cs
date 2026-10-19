using UnityEngine;

public class Spawner : MonoBehaviour
{
    // === Public Valiables === //
    [Header("=== 出現設定.")]
    public GameObject SpawnPrefab;      // 出現させるプレハブ
    public float Interval = 1f;         // インターバルの設定値
    public float IntervalTimer = 0f;    // インターバルのタイマー（Updateで加算）
    public float RandomXMin = 0f;       // X軸のランダムな出現座標の最小値
    public float RandomXMax = 0f;       // X軸のランダムな出現座標の最大値
    public float RandomYMin = 0f;       // Y軸のランダムな出現座標の最小値
    public float RandomYMax = 0f;       // Y軸のランダムな出現座標の最大値


    void Start()
    {
        
    }


    void Update()
    {
        Spawn();        // 生成処理の実行
    }

    /// <summary>
    /// プレハブに指定したオブジェクトの生成処理
    /// </summary>
    public void Spawn()
    {
        // インターバルの時間を加算し続ける
        IntervalTimer += Time.deltaTime;

        // タイマーの時間がIntervalに設定した値より大きくなったら...
        if(IntervalTimer >= Interval)
        {
            // 生成するための座標を作る
            Vector3 position = Vector3.zero;
            position.x = Random.Range(RandomXMin, RandomXMax);
            position.y = Random.Range(RandomYMin, RandomYMax);

            // SpawnPrefab に設定したオブジェクトを生成する
            Instantiate(SpawnPrefab, position, Quaternion.identity);

            // インターバルのタイマーをリセット
            IntervalTimer = 0f;
        }
    }
}
