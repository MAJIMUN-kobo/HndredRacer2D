using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // === Public Variables === //
    public int RacePlace;       // 現在の順位
    public float GameScore;     // 現在のスコア
    public float HighScore;     // ハイスコア

    [Header("=== uGUI 設定")]
    public TextMeshProUGUI RacePlaceText;   // 順位のテキストへの参照
    public TextMeshProUGUI GameScoreText;   // 現在スコアのテキストへの参照
    public TextMeshProUGUI HighScoreText;   // ハイスコアのテキストへの参照


    void Start()
    {
        
    }

    void Update()
    {
        
    }


    /// <summary>
    /// 順位を上げる処理
    /// </summary>
    public void AddRacePlace(int value)
    {
        // 順位を上げる（数値を減らす）
        RacePlace -= value;

        // === 順位のテキストを更新
        if (RacePlaceText == null)
        {
            Debug.LogError("インスペクターでRacePlaceTextを設定してください。");
            return;     // 強制終了
        }

        // 順位を[000]の形式で表示
        RacePlaceText.text = RacePlace.ToString("D3");
    }


    /// <summary>
    /// スコアを加算する処理
    /// </summary>
    public void AddGameScore(float value)
    {
        // スコアを加算
        GameScore += value;

        // ハイスコアの更新を実行
        SetHighScore();

        // === スコアのテキストを更新
        if(GameScoreText == null)
        {
            Debug.LogError("インスペクターでGameScoreTextを設定してください。");
            return;     // 強制終了
        }

        // スコアを[000.0]の形式で表示
        GameScoreText.text = GameScore.ToString("F1");
    }

    public void SetHighScore()
    {
        // ハイスコアよりも現在のスコアが大きい場合...
        if(HighScore <= GameScore)
        {
            // ハイスコアを現在のスコアで上書き
            HighScore = GameScore;
        }
    }
}
