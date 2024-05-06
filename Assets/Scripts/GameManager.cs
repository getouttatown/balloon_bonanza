using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject preFabBalloon;
    public GameObject preFabFan;
    public GameObject preFabSpikes;
    public GameObject preFabCrate;
    public GameObject preFabGoal;
    public GameObject preFabPopupWin;
    public GameObject preFabPopupLose;

    public int currentLevel = 1;

    private Vector3 bCoord = new Vector3(-3.5f, 3.3f, 0.0f);
    private GameObject balloon;
    private GameObject goal;
    private GameObject popup = null;
    private List<GameObject> fanList = new List<GameObject>();
    private List<GameObject> spikesList = new List<GameObject>();
    private List<GameObject> crateList = new List<GameObject>();

    private LevelConfig currConfig;


    [System.Serializable]
    public class LevelConfig
    {
        public int levelId;
        public Vector3 balloonCoords;
        public Vector3[] fanCoords;
        public Vector3[] spikeCoords;
        public Vector3[] crateCoords;
        public Vector3 goalCoords;
    }

    private LevelConfig LoadConfigJson()
    {
        //string filePath = "Assets/Configs/level0" + currentLevel + ".json";
        string filePath = Application.dataPath + "/StreamingAssets/level0" + currentLevel + ".json";
        string configData = System.IO.File.ReadAllText(filePath);
        LevelConfig config = JsonUtility.FromJson<LevelConfig>(configData);

        return config;
    }

    private void LoadConfig()
    {
        LevelConfig loadedConfig = LoadConfigJson();

        // Destroy current GameObjects
        Destroy(balloon);
        for (int i = fanList.Count - 1; i >= 0; i--) {
            Destroy(fanList[i]);
            fanList.RemoveAt(i);
        }
        for (int i = spikesList.Count - 1; i >= 0; i--) {
            Destroy(spikesList[i]);
            spikesList.RemoveAt(i);
        }
        for (int i = crateList.Count - 1; i >= 0; i--) {
            Destroy(crateList[i]);
            crateList.RemoveAt(i);
        }
        Destroy(goal);

        // Instantiate loaded GameObjects
        int idx = 0;
        balloon = Instantiate(preFabBalloon, loadedConfig.balloonCoords, Quaternion.identity);
        foreach (var fan in loadedConfig.fanCoords)
        {
            fanList.Add(Instantiate(preFabFan, fan, Quaternion.identity));
            fanList[idx].GetComponent<Fan>().fanId = ++idx;
        }
        foreach (var spike in loadedConfig.spikeCoords)
        {
            spikesList.Add(Instantiate(preFabSpikes, spike, Quaternion.identity));
        }
        foreach (var crate in loadedConfig.crateCoords)
        {
            crateList.Add(Instantiate(preFabCrate, crate, Quaternion.identity));
        }
        goal = Instantiate(preFabGoal, loadedConfig.goalCoords , Quaternion.identity);

    }

    // Start is called before the first frame update
    void Start()
    {
        LoadConfig();

        // Instantiate level objects
        FindObjectOfType<CodePanel>().SetupBlocks(fanList.Count);
    }

    public GameObject GetFan(int id)
    {
        foreach (GameObject fan in fanList)
        {
            if (fan.GetComponent<Fan>().fanId == id)
            {
                return fan;
            }
        }
        return null;
    }
    public void RunLevel()
    {
        FindObjectOfType<Trapdoor>().Open();
        FindObjectOfType<CodePanel>().RunCodeBlock();
    }

    public void StopLevel()
    {
        if (popup != null)
        {
            Destroy(popup);
        }

        Destroy(balloon);
        FindObjectOfType<CodePanel>().DestroyBlocks();
        // reset level
        FindObjectOfType<Trapdoor>().Close();
        Start();
    }

    public void GameOver()
    {
        Debug.Log("Balloon popped! Game over.");
        popup = Instantiate(preFabPopupLose, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    public void LevelComplete()
    {
        Debug.Log("Balloon reached the goal.");
        popup = Instantiate(preFabPopupWin, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        if (++currentLevel > 2) {
            currentLevel = 1;
        }
    }
}
