using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Plugins.ButtonSoundsEditor
{
    public class ButtonClickSound : MonoBehaviour, IPointerClickHandler
    {
        public AudioSource AudioSource;
        public AudioClip ClickSound;
        public Text text;

        public void OnPointerClick(PointerEventData eventData)
        {
            PlayClickSound();
        }

        private void PlayClickSound()
        {
            AudioSource.PlayOneShot(ClickSound);
            if (GameObject.Find("Music-button").GetComponentInChildren<Text>().text == "ON")
            {
                GameObject.Find("Music-button").GetComponentInChildren<Text>().text = "OFF";
                //AudioSource.GetComponent<AudioSource>().mute;
            }
            else if (GameObject.Find("Music-button").GetComponentInChildren<Text>().text == "OFF")
            {
                GameObject.Find("Music-button").GetComponentInChildren<Text>().text = "ON";
                //if (!AudioSource.GetComponent<AudioSource>.isPlaying)
                //{
                    //AudioSource.GetComponent<AudioSource>().Play();
                //}
            }
        }
    }

}
