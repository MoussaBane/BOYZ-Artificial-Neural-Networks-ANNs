using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Neuron_sc adında bir sınıf tanımlanıyor. Bu sınıf, bir sinir ağı nöronunu temsil eder.
public class Neuron_sc
{
    // Nöronun sahip olduğu giriş sayısı.
    public int numberOfInputs;

    // Nöronun bias değeri; genelde ağırlıkları dengelemek için kullanılır.
    public double bias;

    // Nöronun hesaplanan çıktısı.
    public double output;

    // Hata gradyanı; genelde geri yayılım (backpropagation) sırasında öğrenme için kullanılır.
    public double errorGradient;

    // Nöronun her bir girişi için ayrı ayrı ağırlık değerlerini tutan liste.
    public List<double> weights = new List<double>();

    // Nörona verilen girişlerin değerlerini tutan liste.
    public List<double> inputs = new List<double>();

    // Kurucu metod; bir Neuron_sc nesnesi oluşturulduğunda çağrılır.
    // 'numberOfInputs' parametresi, nöronun kaç giriş alacağını belirtir.
    public Neuron_sc(int numberOfInputs)
    {
        // Bias değeri -1.0 ile 1.0 arasında rastgele bir değer olarak atanıyor.
        bias = UnityEngine.Random.Range(-1.0f, 1.0f);

        // Parametreden gelen giriş sayısı, sınıfın numberOfInputs değişkenine atanıyor.
        this.numberOfInputs = numberOfInputs;

        // Giriş sayısı kadar rastgele ağırlık oluşturuluyor.
        // Her giriş için bir ağırlık değeri gereklidir.
        for (int i = 0; i < numberOfInputs; i++)
        {
            weights.Add(UnityEngine.Random.Range(-1.0f, 1.0f));
        }
    }
}
