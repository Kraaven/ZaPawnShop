using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemInfo sample = new ItemInfo();

        sample.ItemName = Random.Range(0, 1000).ToString();
        sample.ItemModel = Random.Range(0, 1000).ToString();

        // Initialize the Skill objects before using them
        sample.Skill1 = new SkillLeveldecision();
        sample.Skill2 = new SkillLeveldecision();
        sample.Skill3 = new SkillLeveldecision();

        sample.Skill1.Level1 = Random.Range(0, 1000).ToString();
        sample.Skill1.Level2 = Random.Range(0, 1000).ToString();
        sample.Skill1.Level3 = Random.Range(0, 1000).ToString();

        sample.Skill2.Level1 = Random.Range(0, 1000).ToString();
        sample.Skill2.Level2 = Random.Range(0, 1000).ToString();
        sample.Skill2.Level3 = Random.Range(0, 1000).ToString();

        sample.Skill3.Level1 = Random.Range(0, 1000).ToString();
        sample.Skill3.Level2 = Random.Range(0, 1000).ToString();
        sample.Skill3.Level3 = Random.Range(0, 1000).ToString();

        File.WriteAllText(Application.dataPath + "/sample.json", JsonConvert.SerializeObject(sample, Formatting.Indented)); 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable] 
public class ItemInfo
{
    public string ItemName;
    public string ItemModel;
    public SkillLeveldecision Skill1;
    public SkillLeveldecision Skill2;
    public SkillLeveldecision Skill3;
}

[Serializable]
public class SkillLeveldecision
{
    public string Level1;
    public string Level2;
    public string Level3;
}
