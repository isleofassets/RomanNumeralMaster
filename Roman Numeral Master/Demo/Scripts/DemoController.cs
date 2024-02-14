using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace RomanNumeralMaster.Demo
{
    [HelpURL("https://assetstore.unity.com/packages/slug/271278")]
    public class DemoController : MonoBehaviour
    {
        [SerializeField]
        private InputField inputField = null;

        [SerializeField]
        private Dropdown dropdown = null;

        [SerializeField]
        private Text text = null, errorText = null;

        private int lastDropdownValue;

        /// <summary>
        /// Called when a mode is selected in the Dropdown.
        /// </summary>
        public void OnModeSelected()
        {
            if (dropdown.value == lastDropdownValue)
                return;
            inputField.text = string.Empty;
            if (dropdown.value == 0)
                inputField.contentType = InputField.ContentType.IntegerNumber;
            else
                inputField.contentType = InputField.ContentType.Alphanumeric;
            lastDropdownValue = dropdown.value;
        }

        /// <summary>
        /// Called when the Convert button is pressed.
        /// </summary>
        public void Convert()
        {
            try
            {
                if (dropdown.value == 0)
                    text.text = RomanConverter.ConvertToRoman(int.Parse(inputField.text));
                else
                    text.text = RomanConverter.ConvertToDecimal(inputField.text).ToString();
            }
            catch (Exception e)
            {
                StopAllCoroutines();
                StartCoroutine(ShowErrorText(e.Message.Split(':')[1].Substring(1)));
            }
        }

        /// <summary>
        /// Coroutine to show the error text for 3 seconds.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IEnumerator ShowErrorText(string text)
        {
            errorText.text = text;
            yield return new WaitForSeconds(3f);
            errorText.text = string.Empty;
        }
    }
}