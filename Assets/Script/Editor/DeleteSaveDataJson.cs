using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class DeleteSaveDataJson
{
    [MenuItem("Data/Delete")]
    static void DeleteSaveData()
    {
        var saveData = new PlayerSaveData(string.Empty, 0);
        JsonSaveUtility.Save(saveData);
    }
}
