# BOYZ-Artificial-Neural-Networks-ANNs
Bilgisayar Oyunlarda Yapay Zeka Dersinin Ödev-6 Artificial Neural Networks (ANNs)

## ANNs

• Perceptron’un yeteneklerini genişletmek için çok sayıda perceptron’u bir arada kullanabiliriz.

• Ortaya çıkan yapı yapay sinir ağları (artificial neural networks) olarak adlandırılır ve daha karmaşık problemleri çözebilir.

• Perceptron’lar üç veya daha fazla katman ile organize edilebilir. Bir katman girdi, bir veya daha fazla gizli katman ve bir çıktı katmanından oluşur.

• Her katmanın kendi perceptron’ları bulunur. Katman bazında perceptron sayısı aynı veya farklı olabilir. Her katmanın çıktıları sonraki katmanın girdilerini oluşturur.

• Ortaya çıkan ağın tamamında tek perceptron’da olduğu gibi girdiler alınır, ağırlıklarla çarpılır, bias eklenir ve sonuç üzerinde aktivasyon fonksiyonu uygulanır. Elde edilen sonuçlar sonraki katmandaki  perceptron’lara aktarılır.

 • Buişlemçıktı katmanından çıktı elde edilinceye kadar devam eder. Elde edilen çıktı ile eğitim setindeki beklenen çıktı karşılaştırılır ve hata hesaplanır.

## ANNs Kodlama

• Bu aşamada, bir yapay sinir ağını sıfırdan kodlayarak XOR fonksiyonunun hesaplanması için eğiteceğiz.

• XOR fonksiyonu tek perceptron kullanıldığında epoch sayısını arttırmamıza rağmen eğitilememişti.

• 2D veya 3D bir proje oluşturarak sonuçları console ekranına yazdıracağız. Dört C# script’i oluşturalım: Neuron, Layer, Brain, ANN.

• Boş bir oyun nesnesi oluşturalım: Brain ve Brain_sc script’ini bu nesneye ekleyelim.

## ANN - Kodun Çalıştırılması

• Oyunu başlatın. Eğitim tamamlanacak ve sum of squared error yazdırılacak. Bu değerin 0.001 gibi düşük bir değer olmasını bekliyoruz. Binary step fonksiyon ile test ederek farkı görebiliriz.

• Binary step fonksiyonu kullanmadığımız için sonuçlar tam 0 veya tam 1 olmayacak ancak elde ettiğimiz sonuçları yuvarlayabiliriz. Sıfır ve bire oldukça yakın sonuçlar bekliyoruz.

• Oyunu durdurun ve eğitim oranını 0.1’e düşürerek tekrar çalıştırın. Sonuçları inceleyin. Eğitimin tamamlanmadığını sum of squared error ve XOR fonksiyonu sonuçlarından görebiliriz.

• Alpha değeri büyük olduğunda bazen sonuçlar saklama alanı sınırını aşabilir ve NaN çıktısı ile karşılaşabiliriz. Bu durumda (floating point ya da double max değeri aşılmıştır ve) alpha değeri azaltılmalıdır.
 
• ŞimdiXNORiçineğitimsetini değiştirelim ve test edelim.
 
