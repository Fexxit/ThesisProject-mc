using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsMenu : MonoBehaviour
{
    GameObject playerObject;

    [SerializeField] TMP_Dropdown resolutionDropDown;
    [SerializeField] Slider mouseSensitivitySlider;
    [SerializeField] TMP_Text sensitivityValueText;

    Resolution[] resolutions;

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSensitivity()
    {
        int newSensitivity = (int)mouseSensitivitySlider.value;
        sensitivityValueText.text = newSensitivity.ToString();
        playerObject.GetComponent<PlayerLook>().mouseSensitivity = newSensitivity;   
    }

    public void ToggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void PopulateResDropDown()
    {
        int currentResIndex = 0;
        List <string> options = new List<string>();
        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            options.Add(resolutions[i].width + "x" + resolutions[i].height);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropDown.ClearOptions();
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void ChangeResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
