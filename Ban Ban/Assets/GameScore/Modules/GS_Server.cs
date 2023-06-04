using System;
using System.Runtime.InteropServices;
using UnityEngine;
namespace GameScore
{
    public class GS_Server : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern string GSServerTime();

        public static DateTime Time()
        {
            if (Application.isEditor) return DateTime.Now;
            else return DateTime.Parse(GSServerTime(), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
