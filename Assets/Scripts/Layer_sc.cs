using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Layer_sc adında bir sınıf tanımlanıyor. Bu sınıf, bir sinir ağı katmanını temsil eder.
public class Layer_sc
{
    // Katmandaki nöron sayısını tutar.
    public int numberOfNeurons;

    // Katmandaki nöronları temsil eden bir liste. Her eleman bir Neuron_sc nesnesidir.
    public List<Neuron_sc> neurons = new List<Neuron_sc>();

    // Kurucu metod; bir Layer_sc nesnesi oluşturulduğunda çağrılır.
    // 'numberOfNeurons' katmanda kaç nöron olacağını, 'numberOfInputs' ise her nöronun kaç giriş alacağını belirtir.
    public Layer_sc(int numberOfNeurons, int numberOfInputs)
    {
        // Parametreden gelen nöron sayısı, sınıfın değişkenine atanır.
        this.numberOfNeurons = numberOfNeurons;

        // Nöron sayısı kadar döngü oluşturulur.
        for (int i = 0; i < numberOfNeurons; i++)
        {
            // Her bir nöron için yeni bir Neuron_sc nesnesi oluşturulur ve listeye eklenir.
            // 'numberOfInputs', bu nöronun kaç giriş alacağını belirtir.
            neurons.Add(new Neuron_sc(numberOfInputs));
        }
    }
}
