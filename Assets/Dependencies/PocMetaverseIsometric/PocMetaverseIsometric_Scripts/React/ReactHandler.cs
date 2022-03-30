using System.Runtime.InteropServices;
using UnityEngine;

public class ReactHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CallReactLink(string type, string link);

    [DllImport("__Internal")]
    private static extern void LoadingCompeleted();

    public static void CallReact(string type,string link)
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        CallReactLink(type,link);
#else
        Debug.Log("Calling" + type + "for "+ "" +
            ""+link);
#endif

    }

    public static void FinishModelLoading()
    {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
        Debug.Log("LoadingCompeleted is Called");
        LoadingCompeleted();
#else
        Debug.Log("Loading compeleted");
#endif
    }

}
