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
    public GameObject buttonPrefab; // Prefab do botão que será instanciado
    public Transform content;       // Content do Scroll View

    private List<Missao> missoes = new List<Missao>();

    void Start()
    {
        // Adiciona missões à lista
        missoes.Add(new Missao("Moonbucks", "Entregue café gelado para o cliente", 30));
        missoes.Add(new Missao("Burger Prince", "Leve o lanche até o castelo", 50));
        missoes.Add(new Missao("Robs Burger", "Cliente espera na praça central", 45));
        missoes.Add(new Missao("MC Donaldinho's", "Entrega urgente com batata extra", 60));

        foreach (Missao missao in missoes)
        {
            // Instancia o botão
            GameObject novoBotao = Instantiate(buttonPrefab, content);

            // Altera altura do botão se necessário
            RectTransform rt = novoBotao.GetComponent<RectTransform>();
            Vector2 size = rt.sizeDelta;
            size.y = 60f;
            rt.sizeDelta = size;

            // Define o texto do botão (pode usar só o nome)
            novoBotao.GetComponentInChildren<TextMeshProUGUI>().text = missao.nome;

            // Adiciona comportamento ao botão
            Button btn = novoBotao.GetComponent<Button>();
            btn.onClick.AddListener(() =>
            {
                Debug.Log($"Missão: {missao.nome}\nDescrição: {missao.descricao}\nValor: {missao.valor}");
            });
        }
    }
}
