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

  /* New Player Registry*/
  private void Awake() {
    string[] usernames = {
      "teste"
    };

    string[] emails = {
      "cinthia.ungefehr@estudante.ifb.edu.br"
    };

    for (int i = 0; i < usernames.Length; i++) {
      Debug.Log(usernames[i]);
      PlayFabClientAPI.RegisterPlayFabUser(
        new RegisterPlayFabUserRequest {
          Username = usernames[i],
          Password = "123456",
          Email = emails[i],
          RequireBothUsernameAndEmail = false,
        },
        result => Debug.Log("Account registered succesfully!!!"),
        error => Debug.Log(error.GenerateErrorReport())
      );
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
    loginMessage.text = ErrorHandler(error);
  }

  private void OnPasswordResetError(PlayFabError error) {
    resetPasswordMessage.text = ErrorHandler(error);
  }

  private string ErrorHandler(PlayFabError error) {
    string errorMessage = error.Error switch {
      PlayFabErrorCode.AccountNotFound => "Conta não encontrada",
      PlayFabErrorCode.AccountBanned => "Conta banida",
      PlayFabErrorCode.InvalidUsernameOrPassword => "Usuário ou Senha inválidos",
      PlayFabErrorCode.InvalidParams => "Usuário ou Senha inválidos",
      PlayFabErrorCode.ConnectionError => "Erro de conexão",
      PlayFabErrorCode.ServiceUnavailable => "Erro de conexão",
      PlayFabErrorCode.UnableToConnectToDatabase => "Não é possível conectar ao banco de dados",
      _ => string.Format("Erro {0}: {1} | {2}", error.HttpCode, error.ErrorMessage, error.Error),
    };

    Debug.LogWarning(errorMessage);
    return errorMessage;
  }
}
