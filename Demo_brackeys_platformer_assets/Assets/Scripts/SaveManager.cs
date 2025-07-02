using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;// 单例模式实例
    public SaveData activeSave; // 当前激活的存档数据

    public bool hasLoaded; // 是否已加载存档数据
    public bool hasSave;// 是否有存档数据
    void Awake()
    {
        instance = this; // 初始化单例实例
        Load(); // 尝试加载存档数据
    }
    void Start()
    {

    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K)) // 按下S键保存存档
        //{
        //    Save();
        //}
        //if (Input.GetKeyDown(KeyCode.L)) // 按下L键加载存档
        //{
        //    Load();
        //}
        //if (Input.GetKeyDown(KeyCode.J)) // 按下D键删除存档
        //{
        //    DeleteSaveData();
        //}
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath; // 存档文件路径

        var serializer = new XmlSerializer(typeof(SaveData)); // 创建XML序列化器
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create); // 创建文件流
        serializer.Serialize(stream, activeSave); // 序列化存档数据到文件
        stream.Close(); // 关闭文件流
        hasSave = true;
        hasLoaded = false; // 设置已加载标志为false
        Debug.Log("存档已保存到: " + dataPath + "/" + activeSave.saveName + ".save"); // 输出存档保存路径
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath; // 存档文件路径

        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData)); // 创建XML序列化器
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open); // 创建文件流
            activeSave = serializer.Deserialize(stream) as SaveData; // 反序列化存档数据
            stream.Close(); // 关闭文件流

            Debug.Log("存档已加载: " + dataPath + "/" + activeSave.saveName + ".save"); // 输出存档加载路径
            hasLoaded = true; // 设置已加载标志
            hasSave = false; // 设置有存档标志
        }
    }

    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath; // 存档文件路径
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save"); // 删除存档文件
            Debug.Log("存档已删除: " + dataPath + "/" + activeSave.saveName + ".save"); // 输出存档删除路径
        }


    }
}

[System.Serializable]
public class SaveData
{
    public string saveName; // 存档名称 

    public Vector3 respawnPosition; // 玩家重生位置

    public bool doorOpen; // 门是否打开

    public int lives; // 玩家生命值

    public int deathCount; // 玩家死亡次数
}
