using System.Collections.Generic;
using System.IO;

public class DataLoader
{
    public List<string> data = new List<string>();

    /// <summary>
    /// �������� ������ �� �����
    /// </summary>
    /// <param name="path">���� � �����</param>
    public void LoadData(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    data.Add(str);
                }
            }
        }
        catch(FileNotFoundException)
        {
            SaveData(path);
        }
    }

    /// <summary>
    /// ���������� ������ � ����
    /// </summary>
    /// <param name="path">���� � �����</param>
    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path))
        {
            foreach (string s in data)
            {
                sw.WriteLine(s);
            }
        }
    }

    /// <summary>
    /// ���������� �����, �� ���� ���� �������������� �������� ������
    /// </summary>
    /// <param name="path"></param>
    static public void ReloadData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path)) 
        {
            sw.Write("restart");
        }
    }
}
