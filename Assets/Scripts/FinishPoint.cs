using UnityEngine;

// BoxCollider2DとRigidbody2Dが自動でアタッチされるようにします（必須ではありませんが便利です）
[RequireComponent(typeof(BoxCollider2D))]
public class FinishPoint : MonoBehaviour
{
    private SceneController sceneController;

    void Start()
    {
        // シーン上のSceneControllerインスタンスを検索し、参照を取得します。
        // ※このSceneControllerは、DontDestroyOnLoadされたGameObject（GameManagerなど）に付いている想定です。
        sceneController = GameObject.FindObjectOfType<SceneController>();
        
        if (sceneController == null)
        {
            Debug.LogError("SceneControllerが見つかりません。GameManagerにSceneControllerがアタッチされているか確認してください。");
        }

        // BoxCollider2Dがトリガー（Is Trigger）モードであることを確認します。
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // プレイヤーがトリガー（Is TriggerがONのCollider）に接触したときに一度だけ呼ばれます。
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触した相手がプレイヤーであるかを確認します。
        // ※プレイヤーオブジェクトに「Player」タグが付いていることを前提としています。
        if (collision.CompareTag("Player"))
        {
            // SceneControllerの公開メソッド LoadNextScene() を呼び出し、トランジションを開始します。
            sceneController.LoadNextScene();
            
            // 連続で触れるのを防ぐため、ゴール地点のColliderを無効化します。
            GetComponent<Collider2D>().enabled = false;
        }
    }
}