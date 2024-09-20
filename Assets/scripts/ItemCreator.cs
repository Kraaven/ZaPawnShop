using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GLTFast;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class ItemCreator : MonoBehaviour
{
    // private GltfImport loader;
    private Dictionary<string, GameObject> itemDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //loader = new GltfImport();
        string[] itemList = Directory.GetFiles(Application.streamingAssetsPath + "/Items", "*.json");

        foreach (var itempath in itemList)
        {
            print(itempath);
            var dat = JsonConvert.DeserializeObject<ItemInfo>(File.ReadAllText(itempath));
            print(dat);
            if (dat != null)
            {
                if (File.Exists(Application.streamingAssetsPath + "/Models/" + dat.ItemModel))
                {
                    CreateObject(Application.streamingAssetsPath + "/Models/" + dat.ItemModel, dat);
                }
                else
                {
                    print("Associated 3D model does not exist");
                }
            }
            else
            {
                print("Json not Valid");
            }
        }
        itemDictionary = new Dictionary<string, GameObject>();
        
        
    }

    async void CreateObject(string path, ItemInfo itemData)
    {
        try
        {
            var loader = new GltfImport();
            Debug.Log($"Attempting to load model from path: {path}");
            bool success = await loader.Load(path); 
            if (success)
            {
                GameObject loadedObject = new GameObject(itemData.ItemName, new[] { typeof(Item) });
                await loader.InstantiateSceneAsync(loadedObject.transform);
                itemDictionary[itemData.ItemName] = loadedObject;
                loadedObject.SetActive(false);
                Debug.Log($"Successfully loaded item: {itemData.ItemName}");
            }
            else
            {
                Debug.LogError($"Failed to load model at path: {path}. Loader.Load returned false.");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Exception occurred while loading model: {ex.Message}");
            Debug.LogError($"Stack trace: {ex.StackTrace}");
        }
    }

}
