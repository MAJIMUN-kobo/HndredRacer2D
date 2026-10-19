using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    // === Public Variables === //
    [Header("=== uGUI設定.")]
    public TextMeshProUGUI RacePlaceText;       // 順位のテキストコンポーネントへの参照
    public TextMeshProUGUI ScoreText;           // スコアのテキストコンポーネントへの参照
    public TextMeshProUGUI HighScoreText;       // ハイスコアのテキストコンポーネントへの参照

    [Header("=== 表示スコア.")]
    public int ViewRacePlace = 0;       // 表示する順位
    public float ViewScore = 0;         // 表示するスコア
    public float ViewHighScore = 0;     // 表示するハイスコア


    void Start()
    {

    }

    void Update()
    {
        RacePraleTextUpdate();      // 順位のテキスト表示の更新を実行
        ScoreTextUpdate();          // スコアのテキスト表示の更新を実行
        HighScoreTextUpdate();      // ハイスコアのテキスト表示の更新を実行
    }

    
    /// <summary>
    /// 順位のテキスト表示を更新する
    /// </summary>
    public void RacePraleTextUpdate()
    {
        // RacePlaceTextが設定されていない場合...
        if (RacePlaceText == null)
        {
            Debug.LogError("インスペクターで RacePlaceText を設定してください。");
            return;     // 強制終了
        }

        // 文字表示の更新
        RacePlaceText.text = ViewRacePlace.ToString("D3");
    }


    /// <summary>
    /// スコアのテキスト表示を更新する
    /// </summary>
    public void ScoreTextUpdate()
    {
        // ScoreTextが設定されていない場合...
        if (ScoreText == null)
        {
            Debug.LogError("インスペクターで ScoreText を設定してください。");
            return;     // 強制終了
        }

        // 文字表示の更新
        ScoreText.text = ViewScore.ToString("F1");
    }


    /// <summary>
    /// ハイスコア表示用のテキストを更新します。HighScoreText が未設定の場合はエラーをログ出力して処理を中断します。
    /// </summary>
    /// <remarks>HighScoreText はインスペクターで割り当ててください。割り当てがないと更新処理は行われません。</remarks>
    public void HighScoreTextUpdate()
    {
        // HighScoreTextが設定されていない場合...
        if (HighScoreText == null)
        {
            Debug.LogError("インスペクターで HighScoreText を設定してください。");
            return;     // 強制終了
        }

        // 文字表示の更新
        HighScoreText.text = ViewHighScore.ToString("F1");
    }

    
    /// <summary>
    /// タイトルシーンへの画面遷移
    /// ※　「タイトルに戻る」ボタンのイベントに設定します。
    /// </summary>
    public void GotoTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
