using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // コルーチンを使用するため追加

public class SceneController : MonoBehaviour
{
    // 次のシーンをロードする前のフェードアニメーションを制御するためのAnimator
    [SerializeField] private Animator transitionAnim; 

    // ゲーム開始時、シーンを跨いでも破棄されないようにする
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // 次のシーンをロードする public メソッド
    public void LoadNextScene()
    {
        // 現在のシーンのインデックスを取得
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // 次のシーンのインデックスを計算
        int nextSceneIndex = currentSceneIndex + 1;

        // 次のシーンのインデックスがビルド設定のシーン数を超えていないかチェック
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // コルーチンを開始し、アニメーションとロード処理を非同期で実行
            StartCoroutine(LoadLevel(nextSceneIndex));
        }
        else
        {
            // ゲーム終了、または最初のシーンに戻るなどの処理
            Debug.Log("End of levels.");
            // 必要に応じて最初のシーンをロード（例：0番目のシーン）
            // StartCoroutine(LoadLevel(0));
        }
    }

    // シーンロードをアニメーションと同期させるコルーチン
    // 動画の [05:01] あたりから登場するロジック
    IEnumerator LoadLevel(int levelIndex)
    {
        // 1. フェードアウト（Level End）アニメーションを再生
        // Animatorの「End」Triggerを起動し、画面を黒くするアニメーションを開始
        transitionAnim.SetTrigger("End"); 

        // 2. アニメーションが終了するまで待機
        // アニメーションの長さに合わせて待ち時間を調整（動画では約1秒のアニメーション）
        yield return new WaitForSeconds(1f); 

        // 3. 次のシーンをロード
        SceneManager.LoadScene(levelIndex);

        // 4. フェードイン（Level Start）アニメーションを再生
        // 新しいシーンがロードされた後、画面の黒を解除するアニメーションを開始
        // SceneTransitionオブジェクトはDontDestroyOnLoadで保持されているため、新しいシーンでも動作する
        transitionAnim.SetTrigger("Start"); // 動画にはStart Triggerの言及がないが、Level Startアニメーションを再生するためこのTriggerが必要。
                                            // 動画のタイムスタンプ [05:15] で「after I will play the level start animation」と説明されている。
    }
}