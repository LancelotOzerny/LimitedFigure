using UnityEngine;

public class MasterMenu : MonoBehaviour
{
    /// <summary>
    /// �����, ������� ��������� ������� ����-���� ����� �� �������
    /// </summary>
    /// <param name="index">������ ����������� �����</param>
    public void OpenScene(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    /// <summary>
    /// �����, ������� ��������� ������� �������� �� ������. ��������� ��� �������� ��� �����
    /// </summary>
    /// <param name="url">������ �� ��������</param>
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    /// <summary>
    /// �����, ������� ��������� �������� ���������� ������-���� �������
    /// </summary>
    /// <param name="obj">������, ���������� �������� �� ����� ��������</param>
    public void ChangeActive(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }

    /// <summary>
    /// �����, ������� ��������� �������� ����������
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }
}
