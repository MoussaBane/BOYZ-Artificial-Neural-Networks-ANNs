using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain_sc : MonoBehaviour
{
    ANN_sc ann;                     // Yapay sinir ağı nesnesi.
    double sumSquareError = 0;      // Toplam kare hata değişkeni.

    void Start()
    {
        // Ağ yapısının parametreleri.
        int numberOfInputs = 2;                     // Giriş sayısı.
        int numberOfOutputs = 1;                    // Çıkış sayısı.
        int numberOfHiddenLayers = 1;               // Gizli katman sayısı.
        int numberOfNeuronsPerHiddenLayer = 2;      // Her gizli katmandaki nöron sayısı.
        double alpha = 0.8;                         // Öğrenme oranı.

        int epoch = 1000;                           // Eğitim döngüsü sayısı.

        // Yapay sinir ağı nesnesini oluştur.
        ann = new ANN_sc(numberOfInputs, numberOfOutputs,
                         numberOfHiddenLayers,
                         numberOfNeuronsPerHiddenLayer,
                         alpha);

        List<double> result; // Çıkış sonuçlarını tutmak için liste.

        // Eğitim süreci.
        for (int i = 0; i < epoch; i++)
        {
            sumSquareError = 0; // Toplam kare hatayı sıfırla.

            // Eğitim verileriyle ağı eğit ve hataları hesapla.
            result = Train(1, 1, 0);
            sumSquareError += Mathf.Pow((float)result[0] - 0, 2); // Hata hesaplama.

            result = Train(1, 0, 1);
            sumSquareError += Mathf.Pow((float)result[0] - 1, 2);

            result = Train(0, 1, 1);
            sumSquareError += Mathf.Pow((float)result[0] - 1, 2);

            result = Train(0, 0, 0);
            sumSquareError += Mathf.Pow((float)result[0] - 0, 2);
        }

        Debug.Log("SSE: " + sumSquareError); // Toplam kare hatayı yazdır.

        // Eğitim sonrası doğruluk testi.
        result = Train(1, 1, 0);
        Debug.Log(" 1 1 " + result[0]);

        result = Train(1, 0, 1);
        Debug.Log(" 1 0 " + result[0]);

        result = Train(0, 1, 1);
        Debug.Log(" 0 1 " + result[0]);

        result = Train(0, 0, 0);
        Debug.Log(" 0 0 " + result[0]);
    }

    // Eğitim fonksiyonu: Ağın girişlerini ve beklenen çıkışını işler.
    List<double> Train(double input1, double input2, double output)
    {
        List<double> inputs = new List<double>() { input1, input2 };    // Girişleri listele.
        List<double> outputs = new List<double>() { output };          // Beklenen çıktıyı listele.
        return (ann.Run(inputs, outputs));                             // Sinir ağını çalıştır ve çıktıları döndür.
    }
}
