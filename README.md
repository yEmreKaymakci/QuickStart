<div align="center">
  <h1>🥐 MyBakery</h1>
  <p>
    <b>AkademiQ AI Business School eğitimi kapsamında geliştirilmiş modern ve dinamik bir fırın/pastane web projesi.</b>
  </p>
  <br>
</div>

<p align="center">
  <a href="#proje-özellikleri">Proje Özellikleri</a> •
  <a href="#kullanılan-teknolojiler">Kullanılan Teknolojiler</a> •
  <a href="#kurulum">Kurulum</a> •
  <a href="#proje-görselleri">Proje Görselleri</a>
</p>

## 📖 Proje Hakkında

**MyBakery**, bir fırın veya pastanenin ürünlerini, hizmetlerini ve iletişim bilgilerini şık bir şekilde müşterilerine sunmasını sağlayan web uygulamasıdır. İçerik yönetim özellikleriyle dinamik olarak menü, hakkımızda yazısı, çalışanlar ve slider gibi kısımlar güncellenebilir. Kullanıcı dostu arayüzü ve güçlü altyapısıyla işletmelerin dijital vitrini olmak için tasarlanmıştır.

> **Not:** Bu proje, **AkademiQ AI Business School** eğitimi kapsamında geliştirilmiştir.

---

## ✨ Proje Özellikleri

Proje sadece görsel olarak değil, aynı zamanda işlevsel olarak da zenginleştirilmiş yönetim araçlarına sahiptir:

- **Dinamik İçerik Yönetimi:** Ana sayfada yer alan ürünler, hizmetler, çalışan bilgileri ve müşteri yorumları (Testimonials) tamamen admin panelden kontrol edilir.
- **Gelişmiş Bildirim Yönetimi:** Gelen bildirimler ve iletişim mesajları; "Okundu/Okunmadı", "Tür" ve ad/içerik aramasına göre **anlık (AJAX) filtreleme** ile listelenebilir.
- **Toplu İşlemler:** Admin paneldeki listelerde (ör. bildirimlerde) birden çok öğeyi seçerek tek tıkla toplu silme/işlem yapma imkanı.
- **Admin Authentication:** Sisteme yalnızca yetkili (Admin) kullanıcılar, güvenli cookie ve giriş doğrulama (Authentication/Authorization) adımlarından geçerek erişebilir.
- **Dinamik Slider Bağlantısı:** Ana sayfadaki görsel geçişleri (Slider), veritabanından dinamik olarak çekilerek güncellenebilir formattadır.
- **Responsivite:** Tüm bileşenler, Bootstrap altyapısı sayesinde mobil ve tablet cihazlara %100 uyumludur.

---

## 🚀 Kullanılan Teknolojiler

Proje, güncel teknolojiler kullanılarak modern mimari standartlarına uygun olarak inşa edilmiştir:

**Backend:**
- **.NET Core 6 ** (ASP.NET Core Web API & MVC)
- **C#**
- **Entity Framework Core** (ORM)
- **MSSQL** (Veritabanı)
- Katmanlı Mimari (N-Tier Architecture)

**Frontend:**
- **HTML5, CSS3, JavaScript**
- **Bootstrap** (Responsive Tasarım)
- Dinamik Razor Pages (.cshtml)

---

## 🛠️ Kurulum

Projeyi yerel ortamınızda (localhost) çalıştırmak için aşağıdaki adımları izleyebilirsiniz.

### Ön Koşullar
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)

### Kurulum Adımları

1. **Projeyi Klonlayın:**
   `git clone https://github.com/kullaniciadiniz/MyBakery.git`
   `cd MyBakery`

2. **Veritabanı Bağlantısını Güncelleyin:**
   [MyBakery.WepApi/Context/MyBakeryContext.cs](cci:7://file:///c:/Users/lenovo/source/repos/MyBakery/MyBakery.WepApi/Context/MyBakeryContext.cs:0:0-0:0) içerisindeki connection string alanını kendi SQL sunucunuza (Server=...) göre düzenleyin.

3. **Veritabanını Oluşturun:**
   Visual Studio'da **Package Manager Console** (PM) penceresini açın. Default project olarak `MyBakery.WepApi` seçili olduğundan emin olun ve aşağıdaki komutu çalıştırarak tabloları oluşturun:
   `Update-Database`

4. **Projeyi Çalıştırın:**
   Hem API hem de WebUI projelerinin ayağa kalkması gereklidir. Visual Studio'da Çözüm (Solution) ismine sağ tıklayıp "Set Startup Projects..." diyerek "Multiple startup projects" seçeneğini aktif edin. `MyBakery.WepApi` ve `MyBakery.WebUI` için "Start" seçeneğini işaretleyin ve projeyi başlatın (F5).

<br>
<div align="center">
  Eğitim sürecindeki destekleri için <b>AkademiQ AI Business School</b>'a teşekkürler! 🎓
</div>

---

## 📸 Proje Görselleri

*(Bu kısımdaki görselleri proje içinden aldığınız ekran görüntüleri ile repo'nuzdaki `images` klasörünüze yükleyerek güncelleyebilirsiniz)*

### 🏠 Ana Sayfa (WebUI)

<div align="center">
  
  <p><strong>Ana Sayfa Genel Bakış</strong></p>
  
  ![SliderUI](https://github.com/user-attachments/assets/00937435-72b6-40a2-a727-89634fb14c1b)
  <br><br>
  
  <p><strong>Hakkımızda</strong></p>
  
  ![Hakkımızda](https://github.com/user-attachments/assets/a308a309-ebaf-4cfa-909c-74f2ed6ba320)
  <br><br>

  <p><strong>Özellikler</strong></p>

  ![ÖzelliklerUI](https://github.com/user-attachments/assets/70268cec-bf8d-4e4d-ac2c-36bfd54d0fdb)
  <br><br>

  <p><strong>Hizmetler</strong></p>

  ![HizmetlerUI](https://github.com/user-attachments/assets/fee97db6-7cb3-4af0-91ba-0881ca820b76)
  <br><br>

  <p><strong>SSS</strong></p>

  ![SSSUI](https://github.com/user-attachments/assets/c4501bc6-5e77-4f1b-af4c-61cb6a20e3c8)
  <br><br>

  <p><strong>Referanslar</strong></p>

  ![ReferanslarUI](https://github.com/user-attachments/assets/8fd5ac39-ef94-4214-9f47-003309fa2e4b)
  <br><br>

  <p><strong>İletişim</strong></p>

  ![İletişimUI](https://github.com/user-attachments/assets/15737a40-15a3-492b-8bb0-ace09aac1488)
  <br><br>

</div>

---

### ⚙️ Yönetim Paneli (Admin)

<div align="center">
  
  <p><strong>Admin Dashboard (İstatistik Ekranı)</strong></p>

  ![Dashboard](https://github.com/user-attachments/assets/23d654c4-49e8-48ae-b9b5-e599fe88a429)
  <br><br>

  <p><strong>Gelişmiş Bildirim/Mesaj Filtreleme</strong></p>

  ![NoticaitonIndex](https://github.com/user-attachments/assets/0cdc1a85-6886-4214-9954-07eb8af0afe6)
  <br><br>

  <p><strong>Navbar Bildirimleri</strong></p>
  
![NavbarNotification](https://github.com/user-attachments/assets/696998ea-adf9-4f1f-b9ed-b7b32a794866)
  <br><br>

  <p><strong>Arama Çubuğu</strong></p>

![SubscribeSearch](https://github.com/user-attachments/assets/1bd6edcb-d43e-4982-a29b-0c5fa9452841)
  <br><br>

  <p><strong>Hakkımda</strong></p>

![AboutIndex](https://github.com/user-attachments/assets/a4a0a098-1ff3-43a5-a761-6d5d6d1aca3a)
  <br><br>

  <p><strong>Hakkımda Oluşturma</strong></p>

![AboutCreate](https://github.com/user-attachments/assets/f0f1abf9-bf80-4278-b97d-bbcea0dc4020)
  <br><br>

  <p><strong>Hakkımda Güncelleme</strong></p>

![AboutUpdate](https://github.com/user-attachments/assets/0c3d84f1-6983-4c27-82b1-f11d3a59ce60)
  <br><br>

  <p><strong>İçerik İnceleme</strong></p>

![AboutFullpage](https://github.com/user-attachments/assets/dda74d98-2be6-4a22-a4a7-dee158c883b7)
  <br><br>

  <p><strong>Kayıt Olma</strong></p>

![Register](https://github.com/user-attachments/assets/4430a4b9-fe12-45f8-a1de-b9b6adaa80c3)
  <br><br>

  <p><strong>Giriş</strong></p>

![Login](https://github.com/user-attachments/assets/452ff8a6-605f-465f-80b4-79c8456836bc)
  <br><br>

</div>
