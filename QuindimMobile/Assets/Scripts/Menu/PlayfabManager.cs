using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour {
  [SerializeField] private TMP_InputField usernameInput;
  [SerializeField] private TMP_InputField passwordInput;
  [SerializeField] private TMP_InputField emailInput;

  [SerializeField] private TMP_Text loginMessage;
  [SerializeField] private TMP_Text resetPasswordMessage;

  [SerializeField] private Canvas loginCanvas;
  [SerializeField] private MainMenu mainMenu;

  private void Start() {
    if (!PlayFabClientAPI.IsClientLoggedIn()) {
      loginCanvas.gameObject.SetActive(true);
    }
  }

  public void LoginButton() {
    FindObjectOfType<AudioManager>().Play("Click");
    var request = new LoginWithPlayFabRequest {
      Username = usernameInput.text,
      Password = passwordInput.text
    };
    PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginError);
  }

  private void OnLoginSuccess(LoginResult result) {
    Debug.Log("Successfull login!");
    loginMessage.text = "";
    loginCanvas.gameObject.SetActive(false);
  }

  public void UserCurrentLevel() {
    var request = new GetUserDataRequest() {
      Keys = new List<string> { "Level Name" }
    };
    PlayFabClientAPI.GetUserData(request, OnSuccess, error => Debug.Log(error.GenerateErrorReport()));
  }

  private void OnSuccess(GetUserDataResult result) {
    Debug.Log("User data retrieved successfully!");
    if (result.Data != null && result.Data.ContainsKey("Level Name")) {
      SceneManager.LoadScene(result.Data["Level Name"].Value);
    } else {
      SceneManager.LoadScene("Level 01");
    }
    FindObjectOfType<AudioManager>().Stop("MenuTheme");
  }

  public void ResetPasswordButton() {
    FindObjectOfType<AudioManager>().Play("Click");
    var request = new SendAccountRecoveryEmailRequest {
      Email = emailInput.text,
      TitleId = "5639D",
    };
    PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnPasswordResetError);
  }

  private void OnPasswordReset(SendAccountRecoveryEmailResult result ) {
    Debug.Log("Password reset mail sent!");
    resetPasswordMessage.text = "E-mail enviado com sucesso";
    FindObjectOfType<ScreenManager>().BackToLogin();
  }
  private void OnLoginError(PlayFabError error) {
    loginMessage.text = "Usu�rio e/ou senha incorretos";
    Debug.Log(error.GenerateErrorReport());
  }

  private void OnPasswordResetError(PlayFabError error) {
    resetPasswordMessage.text = "Endere�o de e-mail inv�lido";
    Debug.Log(error.GenerateErrorReport());
  }
}
