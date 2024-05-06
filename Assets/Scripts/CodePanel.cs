using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public GameObject preFabFanCtrlBlk;

    private List<GameObject> codeBlocks = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetupBlocks(int fanCt)
    {
        Debug.Log("Setting up code blocks.");

        for (int i = 0; i < fanCt; i++) {
            codeBlocks.Add(Instantiate(preFabFanCtrlBlk, new Vector3(-3.0f + 3.0f * (float)i, -3.65f, 0.0f), Quaternion.identity, transform));
            codeBlocks[i].GetComponent<FanCtrlBlock>().fanId = i+1;
        }
    }

    public void RunCodeBlock()
    {
        StartCoroutine(ControlFan());
    }

    public void DestroyBlocks()
    {
        for (int i = codeBlocks.Count - 1; i >= 0; i--) {
            Destroy(codeBlocks[i]);
            codeBlocks.RemoveAt(i);
        }
    }

    IEnumerator ControlFan()
    {
        foreach (GameObject codeBlk in codeBlocks) {
            if (codeBlk.GetComponent<FanCtrlBlock>().blkEnabled) {
                float timer = codeBlk.GetComponentInChildren<FanCtrlBlockInput>().GetVal();
                GameObject fan = FindObjectOfType<GameManager>().GetFan(codeBlk.GetComponent<FanCtrlBlock>().fanId);
                fan.GetComponent<Fan>().fanEnabled = true;
                yield return new WaitForSeconds(timer);
                fan.GetComponent<Fan>().fanEnabled = false;
            }
        }
    }
}
