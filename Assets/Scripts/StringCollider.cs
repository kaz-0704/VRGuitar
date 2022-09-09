using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRGuitar
{
    public class StringCollider : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "")
            {
                Debug.Log("Trigger Enter: " + other.gameObject.name);
            }
        }

        public void PlayChord()
        {
            //float sensitivity = 0.1f;
            //float mouse_move_x = Input.GetAxis("Mouse X") * sensitivity;
            //float mouse_move_y = Input.GetAxis("Mouse Y") * sensitivity;
            //if (mouse_move_y > 0.07 | mouse_move_y < -0.07)
            //{
            //    audioSource.volume = 1.0f;
            //}
            //else
            //{
            //    audioSource.volume = 0.3f;
            //}
            //volumeText.SetText("Volume : " + audioSource.volume);
            //Debug.Log("X: " + mouse_move_x + " Y: " + mouse_move_y + ", volume: " + audioSource.volume);

            //if (Input.GetKey(KeyCode.A))
            //{
            //    if (Input.GetKey(KeyCode.M))
            //    {
            //        audioSource.PlayOneShot(am); chordText.SetText("Am");
            //    }
            //    else
            //        audioSource.PlayOneShot(a); chordText.SetText("A");
            //}
            //else if (Input.GetKey(KeyCode.B)) { audioSource.PlayOneShot(b); chordText.SetText("B"); }
            //else if (Input.GetKey(KeyCode.C)) { audioSource.PlayOneShot(c); chordText.SetText("C"); }
            //else if (Input.GetKey(KeyCode.D)) { audioSource.PlayOneShot(d); chordText.SetText("D"); }
            //else if (Input.GetKey(KeyCode.E))
            //{
            //    if (Input.GetKey(KeyCode.M))
            //    {
            //        audioSource.PlayOneShot(em); chordText.SetText("Em");
            //    }
            //    else
            //        audioSource.PlayOneShot(e); chordText.SetText("E");
            //}
            //else if (Input.GetKey(KeyCode.M)) { if (Input.GetKey(KeyCode.E)) { audioSource.PlayOneShot(em); chordText.SetText("Em"); } }
            //else if (Input.GetKey(KeyCode.F)) { audioSource.PlayOneShot(f); chordText.SetText("F"); }
            //else if (Input.GetKey(KeyCode.G)) { audioSource.PlayOneShot(g); chordText.SetText("G"); }
        }
    }
}

