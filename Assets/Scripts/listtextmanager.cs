using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class listtextmanager: MonoBehaviour
{
    //public GameObject listtext;
    // Start is called before the first frame update
    private TMP_Text listtext;
    private List<string> boxlist;
    void Start()
    {
        listtext = GetComponentInChildren<TMP_Text>();
        boxlist = new List<string>();
        boxlist.Add("Box 1,Wheight 5kg, Size 1 X 1 X1 m ");
        //boxlist.Add("Box 2,Wheight 10kg, Size 2 X 1 X 0.5 m ");
        //boxlist.Add("Box 3,Wheight 15kg, Size 1 X 2 X 1 m ");
        for (int i = 0; i < boxlist.Count; i++)
        {
            listtext.text = boxlist[i];
        }

    }


    public void UpdateText(int boxnumber)
    {
        boxlist[boxnumber] = "<s>" + boxlist[boxnumber] +"</s>";

    }
}
