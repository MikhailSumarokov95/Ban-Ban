using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using GameScore;

public static class GSPrefs {

    const string jsonKey = "json-data";
    static Dictionary<string, object> dictionary = null;

    public static void Save() {
        if (dictionary == null) return;
        if (dictionary.Count == 0) return;
        string jsonData = JsonConvert.SerializeObject(dictionary);
        if (Application.isEditor) {
            PlayerPrefs.SetString(jsonKey, jsonData);
            PlayerPrefs.Save();
        }
        else {
            GS_Player.Set(jsonKey, jsonData);
            GS_Player.Sync();
        }
    }

    static void CheckDictionary() {
        if (dictionary != null) return;
        string jsonString = Application.isEditor ?
            PlayerPrefs.GetString(jsonKey, "empty") :
            GS_Player.GetString(jsonKey);
        if (jsonString == "empty") dictionary = new();
        else {
            dictionary = JsonConvert.DeserializeObject<
                Dictionary<string, object>
            >(jsonString);
        }
    }

    static object Getter(string key, object defaultValue) {
        CheckDictionary();
        return dictionary.GetValueOrDefault(key, defaultValue);
    }

    static void Setter(string key, object value) {
        CheckDictionary();
        if (!dictionary.ContainsKey(key)) {
            dictionary.Add(key, value);
            return;
        }
        dictionary[key] = value;
    }

    public static bool HasKey(string key) {
        CheckDictionary();
        return dictionary.ContainsKey(key);
    }

    public static void DeleteKey(string key) {
        if (!HasKey(key)) return;
        dictionary.Remove(key);
    }

    public static void DeleteAll() {
        dictionary.Clear();
        if (Application.isEditor) {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
        else {
            GS_Player.Set(jsonKey, "empty");
            GS_Player.Sync();
        }
    }

    public static string GetString(string key, string defaultValue = "") {
        if (HasKey(key)) return Base64Decode(
            (string)Getter(key, defaultValue)
        );
        else return defaultValue;
    }
    public static int GetInt(string key, int defaultValue = 0) => Convert.ToInt32(Getter(key, defaultValue));
    public static float GetFloat(string key, float defaultValue = 0.0f) => Convert.ToSingle(Getter(key, defaultValue));

    public static void SetString(string key, string value) {
        Setter(key, Base64Encode(value));
    }
    public static void SetInt(string key, int value) => Setter(key, value);
    public static void SetFloat(string key, float value) => Setter(key, value);

    public static string Base64Encode(string plainText) {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData) {
        byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

}