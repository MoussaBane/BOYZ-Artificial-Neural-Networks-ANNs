using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANN_sc
{
    public int numberOfInputs;                   // Ağın giriş sayısı.
    public int numberOfOutputs;                  // Ağın çıkış sayısı.
    public int numberOfHiddenLayers;             // Gizli katman sayısı.
    public int numberOfNeuronsPerHiddenLayer;    // Her gizli katmandaki nöron sayısı.
    public double alpha;                         // Öğrenme oranı.
    List<Layer_sc> layers = new List<Layer_sc>(); // Ağın katmanlarını tutan liste.

    // Yapıcı metod: Sinir ağı yapısını başlatır.
    public ANN_sc(int numberOfInputs, int numberOfOutputs,
                  int numberOfHiddenLayers,
                  int numberOfNeuronsPerHiddenLayer,
                  double alpha)
    {
        this.numberOfInputs = numberOfInputs;                       // Giriş sayısını ayarla.
        this.numberOfOutputs = numberOfOutputs;                     // Çıkış sayısını ayarla.
        this.numberOfHiddenLayers = numberOfHiddenLayers;           // Gizli katman sayısını ayarla.
        this.numberOfNeuronsPerHiddenLayer = numberOfNeuronsPerHiddenLayer; // Gizli katman nöron sayısını ayarla.
        this.alpha = alpha;                                         // Öğrenme oranını ayarla.

        // Gizli katman varsa oluştur.
        if (numberOfHiddenLayers > 0)
        {
            layers.Add(new Layer_sc(numberOfNeuronsPerHiddenLayer, numberOfInputs)); // İlk gizli katman.

            // Ek gizli katmanları oluştur.
            for (int i = 0; i < numberOfHiddenLayers - 1; i++)
            {
                layers.Add(new Layer_sc(numberOfNeuronsPerHiddenLayer, numberOfNeuronsPerHiddenLayer));
            }

            // Çıkış katmanını oluştur.
            layers.Add(new Layer_sc(numberOfOutputs, numberOfNeuronsPerHiddenLayer));
        }
        else
        {
            // Gizli katman yoksa girişten direkt çıkış katmanına bağla.
            layers.Add(new Layer_sc(numberOfOutputs, numberOfInputs));
        }
    }

    // Ağın çalıştırılması: Giriş değerlerini alır, işler ve çıktıları döndürür.
    public List<double> Run(List<double> inputValues, List<double> desiredOutput)
    {
        List<double> inputs = new List<double>();   // Girişler.
        List<double> outputs = new List<double>();  // Çıktılar.

        // Giriş sayısını kontrol et.
        if (inputValues.Count != numberOfInputs)
        {
            Debug.Log("ERROR: Number of Inputs must be " + numberOfInputs);
            return outputs; // Hatalı giriş durumu.
        }

        inputs = new List<double>(inputValues); // Girişleri ayarla.

        // Her katmanı sırayla işle.
        for (int i = 0; i < numberOfHiddenLayers + 1; i++)
        {
            if (i > 0)
            {
                inputs = new List<double>(outputs); // Bir önceki katmanın çıktısını giriş yap.
            }
            outputs.Clear(); // Çıktıları temizle.

            // Her nöron için işlemleri uygula.
            for (int j = 0; j < layers[i].numberOfNeurons; j++)
            {
                double N = 0; // Nöronun toplam girdisi.
                layers[i].neurons[j].inputs.Clear(); // Nöron girişlerini temizle.

                // Nöron ağırlıklarını ve girdileri hesapla.
                for (int k = 0; k < layers[i].neurons[j].numberOfInputs; k++)
                {
                    layers[i].neurons[j].inputs.Add(inputs[k]); // Girişi ekle.
                    N += layers[i].neurons[j].weights[k] * inputs[k]; // Ağırlık ve giriş çarpımı.
                }

                N -= layers[i].neurons[j].bias; // Bias çıkar.
                layers[i].neurons[j].output = ActivationFunction(N); // Aktivasyon fonksiyonu uygula.
                outputs.Add(layers[i].neurons[j].output); // Çıkışı ekle.
            }
        }

        UpdateWeights(outputs, desiredOutput); // Ağırlıkları güncelle.

        return outputs; // Sonuçları döndür.
    }

    // Geri yayılım algoritmasıyla ağırlıkları günceller.
    void UpdateWeights(List<double> outputs, List<double> desiredOutput)
    {
        double error; // Hata değeri.

        // Katmanları geriye doğru işle.
        for (int i = numberOfHiddenLayers; i >= 0; i--)
        {
            for (int j = 0; j < layers[i].numberOfNeurons; j++)
            {
                if (i == numberOfHiddenLayers)
                {
                    // Çıkış katmanındaki hata hesaplama.
                    error = desiredOutput[j] - outputs[j];
                    layers[i].neurons[j].errorGradient = outputs[j] * (1 - outputs[j]) * error;
                }
                else
                {
                    // Gizli katmandaki hata hesaplama.
                    layers[i].neurons[j].errorGradient = layers[i].neurons[j].output *
                                                         (1 - layers[i].neurons[j].output);
                    double errorGradSum = 0;

                    // Sonraki katmandan hata katkısı topla.
                    for (int p = 0; p < layers[i + 1].numberOfNeurons; p++)
                    {
                        errorGradSum += layers[i + 1].neurons[p].errorGradient *
                                        layers[i + 1].neurons[p].weights[j];
                    }
                    layers[i].neurons[j].errorGradient *= errorGradSum;
                }

                // Ağırlıkları güncelle.
                for (int k = 0; k < layers[i].neurons[j].numberOfInputs; k++)
                {
                    if (i == numberOfHiddenLayers)
                    {
                        error = desiredOutput[j] - outputs[j];
                        layers[i].neurons[j].weights[k] += alpha * layers[i].neurons[j].inputs[k] *
                                                            error;
                    }
                    else
                    {
                        layers[i].neurons[j].weights[k] += alpha * layers[i].neurons[j].inputs[k] *
                                                            layers[i].neurons[j].errorGradient;
                    }
                }

                // Bias güncelle.
                layers[i].neurons[j].bias += alpha * -1 * layers[i].neurons[j].errorGradient;
            }
        }
    }

    // Aktivasyon fonksiyonu: Sigmoid kullanır.
    double ActivationFunction(double value)
    {
        return Sigmoid(value);
    }

    // Binary step aktivasyon fonksiyonu.
    double Step(double value)
    {
        if (value < 0) return 0;
        else return 1;
    }

    // Sigmoid aktivasyon fonksiyonu.
    double Sigmoid(double value)
    {
        double k = (double)System.Math.Exp(value);
        return k / (1.0f + k);
    }
}
