using System.Runtime.InteropServices;
using UnityEngine;

public class ReactHandler : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendReactData(int index);

    public static void CallReact(int index)
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        SendReactData(index);
#else
        Debug.Log(index +"is called");
#endif

    }

  

}
