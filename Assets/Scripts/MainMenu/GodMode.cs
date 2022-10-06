using UnityEngine;
using UnityEditor;

public class GodMode : MonoBehaviour
{
    public static bool goodMode;

    private void Start()
    {
        GodMode.goodMode = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & GodMode.goodMode)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1000);
            ResetItems();
        }

        if (Input.GetKeyDown(KeyCode.R) & GodMode.goodMode)
        {
            PlayerPrefs.SetInt("Gold", 0);
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.SetInt("ColorLevel", 0);

            DataLoader.ReloadData("SI_SimpleData_Test4.txt");
            DataLoader.ReloadData("SI__BlockData_Test4.txt");

            ResetItems();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GodMode.goodMode = !GodMode.goodMode;
            }
        }
    }

    private void ResetItems()
    {
        PrefLoader[] objs = ScriptableObject.FindObjectsOfType<PrefLoader>();
        foreach (PrefLoader obj in objs)
        {
            obj.Realod();
        }
    }

    //[MenuItem("Varriables/God Mode/On")]
    public static void GoodModeOn()
    {
        GodMode.goodMode = true;
    }

    //[MenuItem("Varriables/God Mode/Off")]
    //[RuntimeInitializeOnLoadMethod]
    public static void GoodModeOff()
    {
        GodMode.goodMode = false;
    }
}
