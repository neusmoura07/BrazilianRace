using UnityEngine;
using UnityEngine.UI;

public class btnativar : MonoBehaviour
{
    public Sprite imagemMusicaLigada; // Imagem quando a música está ativada
    public Sprite imagemMusicaDesligada; // Imagem quando a música está desativada
    public Image imagemToggle; // Referência à imagem do botão
    public AudioSource fonteMusica; // Referência ao AudioSource que toca a música

    private bool musicaLigada = true; // Estado inicial da música

    void Start()
    {
        // Inicializa a imagem do botão com o estado inicial
        AtualizarImagemBotao(); 
    }

    // Método para alternar o estado da música
    public void AlternarMusica()
    {
        musicaLigada = !musicaLigada; // Alterna o estado

        if (musicaLigada)
        {
            fonteMusica.Play(); // Toca a música se estiver ativada
        }
        else
        {
            fonteMusica.Pause(); // Pausa a música se estiver desativada
        }

        AtualizarImagemBotao(); // Atualiza a imagem do botão
    }

    // Atualiza a imagem do botão de acordo com o estado da música
    void AtualizarImagemBotao()
    {
        if (musicaLigada)
        {
            imagemToggle.sprite = imagemMusicaLigada;
        }
        else
        {
            imagemToggle.sprite = imagemMusicaDesligada;
        }
    }
}