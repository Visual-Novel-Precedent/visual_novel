using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections.Generic;

namespace Novel {
    public class RegistationController : MonoBehaviour
    {
        public static RegistationController instance;
        public TMP_InputField email;
        public TMP_InputField password;

        public TMP_InputField name;

        public TMP_Text text_error;
        public UnityAction<string> error;

        void OnEnable() {
            this.error += HandleError;
        }

        void OnDisable() {
            this.error += HandleError;
        }

        void Awake() {
            instance = this;
        }

        void Start()
        {
            instance = this;
        }


        public void Authorize() {
                HttpClient.instance.Request<SignResponse>(HttpRequestType.Post,
                HttpClient.signup_url, 
                new Dictionary<string, string>(){{"email", email.text}, {"password", password.text}, {"name", name.text}}, 
                UserController.instance.authorized, 
                error
            );
            
        }

        public void HandleError(string text) {
            text_error.text = text;
        }

        
    }
}