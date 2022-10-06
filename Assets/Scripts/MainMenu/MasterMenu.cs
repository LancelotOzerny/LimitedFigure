using UnityEngine;

public class MasterMenu : MonoBehaviour
{
    /// <summary>
    /// Метод, который позволяет открыть каку-либо сцену по индексу
    /// </summary>
    /// <param name="index">индекс открываемой сцены</param>
    public void OpenScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Метод, который позволяет открыть страницу по ссылке. Требуется для открытия соц сетей
    /// </summary>
    /// <param name="url">ссылка на страницу</param>
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    /// <summary>
    /// Метод, который позволяет изменить активность какого-либо объекта
    /// </summary>
    /// <param name="obj">объект, активность которого мы хотим изменить</param>
    public void ChangeActive(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    /// <summary>
    /// Метод, который позволяет закрытьь приложение
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
