using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要

public class ResetGame : MonoBehaviour
{
    // リセットボタンが押されたときに呼ばれるメソッド
    public void OnResetButtonPressed()
    {
        // 現在のシーンを再読み込みして、ゲームをリセット
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
