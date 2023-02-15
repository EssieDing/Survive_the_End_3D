using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
 
public class ResolutionManager : MonoBehaviour
{
    private Resolution[] reso;
 
    public Dropdown mDropdown;
 
    private List<Dropdown.OptionData> odList = new List<Dropdown.OptionData>();
 
    void Start()
    {
        reso = Screen.resolutions;
        mDropdown.options.Clear();
        //Screen.SetResolution(800, 600, true);

        for (int i = 0; i < reso.Length; i++)
        {
            odList.Add(new Dropdown.OptionData());
 
            odList[i].text = ShowResolving(reso[i]);
            mDropdown.value = i;
 
            mDropdown.options.Add(odList[i]);
 
            mDropdown.onValueChanged.AddListener(index =>
            {
                mDropdown.captionText.text = ShowResolving(reso[index]);
                Screen.SetResolution(reso[index].width, reso[index].height, true);
            });
 
            mDropdown.captionText.text = "Screen Resolution";
        }
    }
 
    string ShowResolving(Resolution res)
    {
        return res.width + "X" + res.height;
    }
}
