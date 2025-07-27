using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Missao
{
    public string nome;
    public string descricao;
    public int valor;

    public Missao(string nome, string descricao, int valor)
    {
        this.nome = nome;
        this.descricao = descricao;
        this.valor = valor;
    }
}


public class MissoesContent : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform content;
    public GameObject textoDetalhes;
    private List<Missao> missoes = new List<Missao>();
    public GameObject GUIMenuMissoes;
    public GameObject textoMissaoAtual;

    public void FecharMenuMissoes()
    {
        Debug.Log("FecharMenuMissoes");
        GUIMenuMissoes.SetActive(false);
    }

    public void AceitarMissao()
    {
        if (textoMissaoAtual != null)
        {
            textoMissaoAtual.SetActive(true);
        }
        FecharMenuMissoes();
    }

    void Start()
    {
        if (GUIMenuMissoes != null)
            GUIMenuMissoes.SetActive(false);
            
        if (textoMissaoAtual != null)
            textoMissaoAtual.SetActive(false);
        
        missoes.Add(new Missao("Moonbucks", "Entregue café gelado para o cliente", 30));
        missoes.Add(new Missao("Burger Prince", "Leve o lanche até o castelo", 70));
        missoes.Add(new Missao("Robs Burger", "Cliente espera na praça central", 45));
        missoes.Add(new Missao("MC Donaldinho", "Entrega urgente com batata extra", 60));
        missoes.Add(new Missao("Kulinaria Frango Chique", "Entregue o frango urgente", 60));

        foreach (Missao missao in missoes)
        {
            Missao missaoAtual = missao;

            textoDetalhes.SetActive(true);

            GameObject novoBotao = Instantiate(buttonPrefab, content);

            RectTransform rt = novoBotao.GetComponent<RectTransform>();
            Vector2 size = rt.sizeDelta;
            size.y = 20f;
            rt.sizeDelta = size;

            novoBotao.GetComponentInChildren<TextMeshProUGUI>().text = missaoAtual.nome;

            Button btn = novoBotao.GetComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                textoDetalhes.GetComponentInChildren<TextMeshProUGUI>().text = missaoAtual.descricao.ToString();
                textoMissaoAtual.GetComponentInChildren<TextMeshProUGUI>().text = missao.nome;
            });
        }
    }
}
