using System;
using System.Collections.Generic;
using System.IO;

class Grafo {
    public int[,] matrizAdjacencia;
    public List<string> vertices;
    public int qtdVertices;
    public int qtdArestas;

    public Grafo(List<string> vertices) {
        this.vertices = new List<string>();
        this.vertices.AddRange(vertices);
        this.qtdVertices = vertices.Count;
        this.qtdArestas = 0;
        this.matrizAdjacencia = new int[this.qtdVertices, this.qtdVertices];
    }

    public void InserirArestaSimetrica(string origem, string destino) {
        int indiceOrigem = this.vertices.IndexOf(origem);
        int indiceDestino = this.vertices.IndexOf(destino);
        if (origem.Equals(destino, StringComparison.OrdinalIgnoreCase) || indiceOrigem == -1 || indiceDestino == -1) {
            return;
        }

        if (this.matrizAdjacencia[indiceOrigem, indiceDestino] == 0) {
            this.matrizAdjacencia[indiceOrigem, indiceDestino] = 1;
            this.qtdArestas++;
        }
        if (this.matrizAdjacencia[indiceDestino, indiceOrigem] == 0) {
            this.matrizAdjacencia[indiceDestino, indiceOrigem] = 1;
            this.qtdArestas++;
        }
    }

    public void Show() {
        for (int i = 0; i < this.qtdVertices; i++) {
            Console.Write(this.vertices[i] + "\t\t\t");
            for (int j = 0; j < this.qtdVertices; j++) {
                if (this.matrizAdjacencia[i, j] != 0) {
                    Console.Write(this.vertices[j] + "\t\t\t");
                }
            }
            Console.WriteLine();
        }
    }

    public int MostrarGrau(string cidade) {
        int indice = this.vertices.IndexOf(cidade);
        if (indice == -1) return -27;
        int qtd = 0;
        for (int i = 0; i < this.qtdVertices; i++) {
            if (this.matrizAdjacencia[indice, i] != 0) {
                qtd++;
            }
            if (this.matrizAdjacencia[i, indice] != 0) {
                qtd++;
            }
        }
        return qtd;
    }
}
