using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesignManager : MonoBehaviour
{
    // Container Objects
    public GameObject preFabBalloonCont;
    public GameObject preFabFanCont;
    public GameObject preFabSpikesCont;
    public GameObject preFabCrateCont;
    public GameObject preFabGoalCont;

    private GameObject balloon;
    private GameObject fan;
    private GameObject spikes;
    private GameObject crate;
    private GameObject goal;
    private List<GameObject> fanList = new List<GameObject>();
    private List<GameObject> spikesList = new List<GameObject>();
    private List<GameObject> crateList = new List<GameObject>();

    private Vector3 defaultBalloon = new Vector3(-4.5f, 4.5f, 0.0f);
    private Vector3 defaultFan = new Vector3(-7.5f, 3.5f, 0.0f);
    private Vector3 defaultSpikes = new Vector3(-7.5f, 1.5f, 0.0f);
    private Vector3 defaultCrate = new Vector3(-7.5f, -0.5f, 0.0f);
    private Vector3 defaultGoal = new Vector3(8.0f, -0.75f, 0.0f);

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

    public LevelConfig LoadConfigJson()
    {
        //string filePath = "Assets/Configs/customLevel.json";
        string filePath = Application.persistentDataPath + "/customLevel.json";
        Debug.Log(filePath);
        string configData = System.IO.File.ReadAllText(filePath);
        LevelConfig config = JsonUtility.FromJson<LevelConfig>(configData);

        return config;
    }

    public void SaveConfigJson(LevelConfig config)
    {
        string configData = JsonUtility.ToJson(config);
        string filePath = Application.persistentDataPath + "/customLevel.json";
        Debug.Log(filePath);
        //string filePath = "Assets/Configs/customLevel.json";
        System.IO.File.WriteAllText(filePath, configData);
    }

    public void LoadConfig()
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
        balloon = Instantiate(preFabBalloonCont, loadedConfig.balloonCoords, Quaternion.identity);
        foreach (var fan in loadedConfig.fanCoords)
        {
            fanList.Add(Instantiate(preFabFanCont, fan, Quaternion.identity));
        }
        foreach (var spike in loadedConfig.spikeCoords)
        {
            spikesList.Add(Instantiate(preFabSpikesCont, spike, Quaternion.identity));
        }
        foreach (var crate in loadedConfig.crateCoords)
        {
            crateList.Add(Instantiate(preFabCrateCont, crate, Quaternion.identity));
        }
        goal = Instantiate(preFabGoalCont, loadedConfig.goalCoords , Quaternion.identity);

    }

    public void SaveConfig()
    {
        LevelConfig levelConf = new LevelConfig();
        levelConf.balloonCoords = balloon.GetComponent<Transform>().position;

        levelConf.fanCoords = new Vector3[fanList.Count];
        for (int i = 0; i < fanList.Count; i++) {
            levelConf.fanCoords[i] = fanList[i].GetComponent<Transform>().position;
        }

        levelConf.spikeCoords = new Vector3[spikesList.Count];
        for (int i = 0; i < spikesList.Count; i++) {
            levelConf.spikeCoords[i] = spikesList[i].GetComponent<Transform>().position;
        }

        levelConf.crateCoords = new Vector3[crateList.Count];
        for (int i = 0; i < crateList.Count; i++) {
            levelConf.crateCoords[i] = crateList[i].GetComponent<Transform>().position;
        }

        levelConf.goalCoords = goal.GetComponent<Transform>().position;

        SaveConfigJson(levelConf);
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("Scenes/StartMenu");
        Debug.Log("This should have loaded the Start Menu");
    }

    // Start is called before the first frame update
    void Start()
    {
        balloon = Instantiate(preFabBalloonCont, defaultBalloon, Quaternion.identity);
        fan = Instantiate(preFabFanCont, defaultFan, Quaternion.identity);
        spikes = Instantiate(preFabSpikesCont, defaultSpikes, Quaternion.identity);
        crate = Instantiate(preFabCrateCont, defaultCrate, Quaternion.identity);
        goal = Instantiate(preFabGoalCont, defaultGoal, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (fan.GetComponent<ContainerCtrl>().placed) {
            fanList.Add(fan);
            fan = Instantiate(preFabFanCont, defaultFan, Quaternion.identity);
        }
        if (spikes.GetComponent<ContainerCtrl>().placed) {
            spikesList.Add(spikes);
            spikes = Instantiate(preFabSpikesCont, defaultSpikes, Quaternion.identity);
        }
        if (crate.GetComponent<ContainerCtrl>().placed) {
            crateList.Add(crate);
            crate = Instantiate(preFabCrateCont, defaultCrate, Quaternion.identity);
        }
    }
}
