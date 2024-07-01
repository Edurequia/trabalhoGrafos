using System;
using System.Collections.Generic;
using System.IO;

public class Principal {
    public static void Main(string[] args) {
        List<string> cidades = new List<string>();

        using (StreamReader sr = new StreamReader("cidades.csv")) {
            string line = sr.ReadLine();
            string[] connections = line.Split(' ');

            foreach (string connection in connections) {
                string[] parts = connection.Split('@');
                if (!cidades.Contains(parts[0])) {
                    cidades.Add(parts[0]);
                }
                if (!cidades.Contains(parts[1])) {
                    cidades.Add(parts[1]);
                }
            }

            cidades.Sort();

            Grafo grafo_rs = new Grafo(cidades);
            foreach (string connection in connections) {
                string[] parts = connection.Split('@');
                grafo_rs.InserirArestaSimetrica(parts[0], parts[1]);
            }

            grafo_rs.Show();

            string cidade = "Itaara";
            Console.WriteLine("Grau da cidade de " + cidade + ": " + grafo_rs.MostrarGrau(cidade));
        }
    }
}
