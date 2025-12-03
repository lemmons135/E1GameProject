using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // コルーチンのために必須

public class SceneController : MonoBehaviour
{
    // [設定必須] UnityエディターでScene TransitionオブジェクトのAnimatorをアサインします。
    public Animator transitionAnim; 

    // 【修正点】外部（例: FinishPoint.cs）から呼び出すためのpublicメソッド
    public void LoadNextScene()
    {
        // シーンロード処理（コルーチン）を開始
        StartCoroutine(LoadLevel());
    }

    // トランジションアニメーションを含めたシーンロード処理
    IEnumerator LoadLevel()
    {
        // 1. フェードアウトアニメーションの開始
        // AnimatorのTriggerパラメーター「End」を起動
        transitionAnim.SetTrigger("End");

        // 2. アニメーション完了を待機 (アニメーションの長さに合わせて秒数を調整)
        yield return new WaitForSeconds(1f); 

        // 3. 次のシーンをロード
        // 現在のシーンのビルドインデックスに +1 した、次のシーンをロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        // 【補足】DontDestroyOnLoad処理は、GameManagerオブジェクトにこのスクリプトがアタッチされていることを前提としています。
    }
}