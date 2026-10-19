using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // === Public Variables === //
    public ScoreManager ScoreManager;   // スコア管理クラスの参照


    void Start()
    {
        if (ScoreManager == null)
        {
            Debug.LogError("ScoreManager をインスペクターに設定してください。");
            return;     // 強制終了
        }

        ScoreManager.RacePlace = 100;   // 順位は100位からスタート
        ScoreManager.AddRacePlace(0);   // 描画も合わせて更新
    }


    void Update()
    {
        AddTimeScore();     // 時間でのスコア加算を実行
    }


    /// <summary>
    /// 時間でスコアが増え続ける処理
    /// </summary>
    public void AddTimeScore()
    {
        if(ScoreManager == null)
        {
            Debug.LogError("ScoreManager をインスペクターに設定してください。");
            return;     // 強制終了
        }

        // 秒間 1 ずつスコアが増える
        ScoreManager.AddGameScore(Time.deltaTime);
    }


    /// <summary>
    /// ゲームクリア処理をまとめるメソッド
    /// </summary>
    public void GameClear()
    {
        SceneManager.sceneLoaded += OnScoreReceiveLoaded;   // 読み込み後の処理を登録
        SceneManager.LoadScene("ClearScene");               // 「クリア画面」に遷移
    }


    /// <summary>
    /// ゲームオーバー処理をまとめるメソッド
    /// </summary>
    public void GameOver()
    {
        SceneManager.sceneLoaded += OnScoreReceiveLoaded;   // 読み込み後の処理を登録
        SceneManager.LoadScene("OverScene");                // 「オーバー画面」に遷移
    }

    /// <summary>
    /// タイトルシーンへの画面遷移
    /// ※　「タイトルに戻る」ボタンのイベントに設定します。
    /// </summary>
    public void GotoTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }


    /// <summary>
    /// 「リザルト画面」に遷移した後のゲームクリア処理
    /// </summary>
    private void OnScoreReceiveLoaded(Scene scene, LoadSceneMode mode)
    {
        // === シーン読み込み後に実行される

        // シーンから ResultManager を取得する
        ResultManager result = GameObject.FindAnyObjectByType<ResultManager>();
        if(result == null)
        {
            Debug.LogError("遷移先に ResultManager が存在しません。");
            return;     // メソッドを強制終了
        }

        // 「リザルト画面」にスコアの情報を送る
        result.ViewScore = ScoreManager.GameScore;
        result.ViewHighScore = ScoreManager.HighScore;

        // 連続で実行されないように、登録を解除
        SceneManager.sceneLoaded -= OnScoreReceiveLoaded;
    }
}
