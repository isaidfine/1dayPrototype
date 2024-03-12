using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理的命名空间

public class SceneLoader : MonoBehaviour
{
    // 加载第一个场景的方法
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("1"); // 替换为你的第一个场景的名称
    }

    // 加载第二个场景的方法
    public void LoadSecondScene()
    {
        SceneManager.LoadScene("2"); // 替换为你的第二个场景的名称
    }
}