using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GlobalLoadManager : MonoBehaviour
{
    private static GlobalLoadManager instance;

    public static GlobalLoadManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GlobalLoadManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GlobalLoadManager";
                    instance = go.AddComponent<GlobalLoadManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    public void LoadScene(int sceneID)
    {
        
        // Carregar a cena de carregamento primeiro
        SceneManager.LoadScene("Carregamento");

        // Iniciar a corrotina para carregar a cena final após um atraso ou progresso concluído
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    private IEnumerator LoadSceneAsync(int sceneID)
    {
        // Aguardar um pequeno atraso (para mostrar a tela de carregamento)
        yield return new WaitForSeconds(0.5f);

        // Carregar a cena final de forma assíncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneID);

        // Permitir que a cena seja ativada imediatamente
        asyncOperation.allowSceneActivation = true;

        // Aguardar até que a cena esteja completamente carregada
        while (!asyncOperation.isDone)
        {
            // Aqui você pode atualizar uma barra de progresso, se necessário
            // float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            // UpdateProgressBar(progress);
            
            yield return null;
        }
    }
}