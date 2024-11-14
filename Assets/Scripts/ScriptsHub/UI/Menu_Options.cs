using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Lean.Localization;

public class Menu_Options : MonoBehaviour
{
    [Header("Game_UI")]

    [Header("Audio")]

    [Header("Video")]
    [SerializeField] private TMP_Dropdown resolutionDropDown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    private bool isFullScreen;

    /*[Header("Lean location")]
    [SerializeField] private TMP_Dropdown dropdownLanguage;
    [SerializeField] private TextMeshProUGUI dropdownLabel;*/
    

    private void Start()
    {
        
        #region Resolution
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropDown.ClearOptions();
        currentRefreshRate = (float)Screen.currentResolution.refreshRateRatio.value;
        Debug.Log("RefreshRate: "+currentRefreshRate);
        //this is the actual loop check
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (!filteredResolutions.Any(x => x.width == resolutions[i].width && x.height == resolutions[i].height))  //check if resolution already exists in list
            {
                filteredResolutions.Add(resolutions[i]);  //add resolution to list if it doesn't exist yet
            }
        }
        for (int i = 0; i < resolutions.Length; i++)
        {
            if ((float)resolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }
        filteredResolutions.Sort((a, b) => {
            if (a.width != b.width)
                return b.width.CompareTo(a.width);
            else
                return b.height.CompareTo(a.height);
        });
        List<string> options = new List<string>();
        for(int i = 0;i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" +filteredResolutions[i].height+" "+ filteredResolutions[i].refreshRateRatio.value.ToString("0.##") + "Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height && (float)filteredResolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        SetResolution(currentResolutionIndex);
        #endregion
        
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,FullScreenMode.Windowed,resolution.refreshRateRatio);
    }
    public void SetFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

}
